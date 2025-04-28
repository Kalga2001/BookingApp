using BookingApp.DataContext;
using BookingApp.Entity;
using BookingApp.Helpers;
using System.Security.Cryptography;
using System.Text;

public class UserFactory
{
    public User CreateUser(string userName, string email, string password)
    {
        string hashedPassword = HashPassword.Hash(password);

        return new User
        {
            UserName = userName,
            Email = email,
            Password = hashedPassword,
            IsActive = true
        };
    }

    public UserRole CreateUserRole(User user)
    {
        using (var _bookingDbContext = new BookingAppDbContext())
        {
            return new UserRole
            {
                RoleID = 2,
                User = user
            };
        }
    }

}

