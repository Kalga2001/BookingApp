using BookingApp.DataContext;
using BookingApp.Helpers;
using BookingApp.Models;

namespace BookingApp.TemplateMethod.Services
{
    public class PasswordResetUserService : UserActionService
    {
        protected override bool ValidateRequest(CustomActionRequest request)
        {
            var resetPasswordRequest = request as ResetPassword;
            return resetPasswordRequest != null &&
                   !string.IsNullOrEmpty(resetPasswordRequest.Email) &&
                   !string.IsNullOrEmpty(resetPasswordRequest.NewPassword);
        }

        protected override CustomResponse ExecuteAction(CustomActionRequest request)
        {
            var resetPasswordRequest = request as ResetPassword;
            using (var _bookingDbContext = new BookingAppDbContext())
            {
                var existingUser = _bookingDbContext.User.FirstOrDefault(x => x.Email == resetPasswordRequest.Email);

                if (existingUser != null)
                {
                    existingUser.Password = resetPasswordRequest.NewPassword;
                    _bookingDbContext.User.Update(existingUser);
                    _bookingDbContext.SaveChanges();

                    return new CustomResponse { Code = 200, Message = "Password updated successfully" };
                }
                else
                {
                    return new CustomResponse { Code = 404, Message = "User not found" };
                }
            }
        }
    }
}
