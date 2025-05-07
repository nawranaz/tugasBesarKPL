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
                Console.WriteLine(result ? "\nLogin berhasil!\n" : "\n Login gagal.");

                if (result)
                {
                    LatihanSoalController.StartLatihan();

                    TampilkanMenuPengingat();
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

        static void TampilkanMenuPengingat()
        {
            Console.WriteLine("\n=== MENU PENGINGAT BELAJAR ===");

            while (true)
            {
                Console.Write("Masukkan bulan (1–12) untuk melihat pengingat atau ketik 'Q' untuk keluar: ");
                string input = Console.ReadLine()?.Trim().ToUpper();

                if (input == "Q")
                {
                    Console.WriteLine("Terima kasih! Sampai jumpa.");
                    break;
                }

                if (int.TryParse(input, out int bulan) && bulan >= 1 && bulan <= 12)
                {
                    int tahun = DateTime.Now.Year;
                    NotifikasiPengingat.TampilkanPengingat(bulan, tahun);
                }
                else
                {
                    Console.WriteLine("Input tidak valid. Masukkan angka 1–12 atau 'Q' untuk keluar.");
                }
            }
        }
    }
}
