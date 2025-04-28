using BookingApp.DataContext;
using BookingApp.Helpers;
using BookingApp.Interfaces;
using BookingApp.Models;
using BookingApp.TemplateMethod.Services;

namespace BookingApp.Services
{
    public class UserService : IUserService
    {
        private readonly UserFactory _userFactory;

        public UserService(UserFactory userFactory)
        {
            _userFactory = userFactory;
        }

        public CustomResponse Login(Login login)
        {
            using (var _bookingDbContext = new BookingAppDbContext())
            {
                var loginService = new LoginUserService();
                return loginService.PerformAction(login);
            }
        }

        public CustomResponse Register(Register register)
        {
            using (var _bookingDbContext = new BookingAppDbContext())
            {
                if(register.Password != register.ConfirmPassword)
                {
                    return new CustomResponse
                    {
                        Code = 400,
                        Message = "Password and Confirm Password do not match."
                    };
                }

                var existingUser = _bookingDbContext.User.FirstOrDefault(x => x.Email == register.Email);

                if(existingUser != null)
                {
                    return new CustomResponse
                    {
                        Code = 400,
                        Message = "User already exists with this email."
                    };
                }

                var registerService = new RegisterUserService(_userFactory);
                return registerService.PerformAction(register);
            }
        }

        public CustomResponse ResetPassword(ResetPassword resetPassword)
        {
            using (var _bookingDbContext = new BookingAppDbContext())
            {
                var passwordResetService = new PasswordResetUserService();
                return passwordResetService.PerformAction(resetPassword);
            }
        }

        public int GetUserID(string email)
        {
            using (var _bookingDbContext = new BookingAppDbContext())
            {
                return _bookingDbContext.User.FirstOrDefault(x => x.Email == email && x.IsActive).UserID;
            }
        }
    }
}
