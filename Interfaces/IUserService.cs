using BookingApp.Helpers;
using BookingApp.Models;

namespace BookingApp.Interfaces
{
    public interface IUserService
    {
        public CustomResponse Login(Login login);
        public CustomResponse Register(Register register);
        public CustomResponse ResetPassword(ResetPassword resetPassword);
        public int GetUserID(string email);
    }
}
