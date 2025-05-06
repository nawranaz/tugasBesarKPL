using System;
using TubesKPL_KitaBelajar.Model;
using TubesKPL_KitaBelajar.Services;
using TubesKPL_KitaBelajar.Controllers;

namespace TubesKPL_KitaBelajar
{
    class Program
    {
        static void Main(string[] args)
        {
            
            User user = GetUserInput();
            IAuthService authService = new AuthService();

            try
            {
                bool result = authService.Login(user);
                Console.WriteLine(result ? "Login berhasil!" : "Login gagal.");

                if (result)
                {
              
                    LatihanSoalController.StartLatihan();
                }
                else
                {
                    Console.WriteLine("Login gagal. Program akan keluar.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
            }
        }

        static User GetUserInput()
        {
            Console.Write("Masukkan username: ");
            string username = Console.ReadLine();

            Console.Write("Masukkan password: ");
            string password = Console.ReadLine();

            return new User
            {
                Username = username,
                Password = password
            };
        }
    }
}