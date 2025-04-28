using BookingApp.DataContext;
using BookingApp.Entity;
using BookingApp.Helpers;
using BookingApp.Models;

public class RegisterUserService : UserActionService
{
    private readonly UserFactory _userFactory;

    public RegisterUserService(UserFactory userFactory)
    {
        _userFactory = userFactory;
    }

    protected override bool ValidateRequest(CustomActionRequest request)
    {
        var registerRequest = request as Register;
        return registerRequest != null && !string.IsNullOrEmpty(registerRequest.Email);
    }

    protected override CustomResponse ExecuteAction(CustomActionRequest request)
    {
        var registerRequest = request as Register;
        User user = _userFactory.CreateUser(registerRequest.UserName, registerRequest.Email, registerRequest.Password);
        UserRole userRole = _userFactory.CreateUserRole(user);
        using (var _bookingDbContext = new BookingAppDbContext())
        {
            _bookingDbContext.User.Add(user);
            _bookingDbContext.UserRole.Add(userRole);
            _bookingDbContext.SaveChanges();
        }
        return new CustomResponse { Code = 201, Message = "User created" };
    }
}