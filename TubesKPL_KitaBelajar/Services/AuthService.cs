using System;
using TubesKPL_KitaBelajar.Model;

namespace TubesKPL_KitaBelajar.Services
{
    public class AuthService : IAuthService
    {
        public bool Login(User user)
        {
            
            if (user == null)
                throw new ArgumentNullException(nameof(user), "User tidak boleh null");

            if (string.IsNullOrWhiteSpace(user.Username))
                throw new ArgumentException("Username tidak boleh kosong");

            if (string.IsNullOrWhiteSpace(user.Password))
                throw new ArgumentException("Password tidak boleh kosong");

            
            string validUsername = Environment.GetEnvironmentVariable("VALID_USERNAME") ?? "kelompok2";
            string validPassword = Environment.GetEnvironmentVariable("VALID_PASSWORD") ?? "suksestubes";

            return user.Username == validUsername && user.Password == validPassword;
        }
    }
}
