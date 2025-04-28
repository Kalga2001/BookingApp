using BookingApp.DataContext;
using BookingApp.Helpers;
using BookingApp.Models;

public class LoginUserService : UserActionService
{
    protected override bool ValidateRequest(CustomActionRequest request)
    {
        var loginRequest = request as Login;
        return loginRequest != null && !string.IsNullOrEmpty(loginRequest.Email) && !string.IsNullOrEmpty(loginRequest.Password);
    }

    protected override CustomResponse ExecuteAction(CustomActionRequest request)
    {
        var loginRequest = request as Login;
        using (var _bookingDbContext = new BookingAppDbContext())
        {
            string hashedPassword = HashPassword.Hash(loginRequest.Password);
            var user = _bookingDbContext.User.FirstOrDefault(x => x.Email == loginRequest.Email && x.Password == hashedPassword && x.IsActive);

            if (user != null)
            {
                return new CustomResponse { Code = 200, Message = "Successful login" };
            }
            else
            {
                return new CustomResponse { Code = 404, Message = "User not found" };
            }
        }
    }
}