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
                Console.WriteLine(result ? "\nLogin berhasil!\n" : "\nLogin gagal.");

                if (result)
                {
                    Console.WriteLine("1. Latihan Soal");
                    Console.WriteLine("2. Modul Pembelajaran");
                    Console.Write("Pilih menu: ");
                    string pilihan = Console.ReadLine();

                    switch (pilihan)
                    {
                        case "1":
                            LatihanSoalController.StartLatihan();
                            break;
                        case "2":
                            ModulController.TampilkanModul();
                            break;
                        default:
                            Console.WriteLine("Pilihan tidak valid.");
                            break;
                    }

                    Console.WriteLine("\nTekan sembarang tombol untuk keluar...");
                    Console.ReadKey();
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
            Console.WriteLine("=== LOGIN ===");
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
