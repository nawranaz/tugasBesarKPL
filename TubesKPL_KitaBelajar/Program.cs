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
                    string pilihan;
                    do
                    {
                        Console.WriteLine("\n=== MENU UTAMA ===");
                        Console.WriteLine("1. Latihan Soal");
                        Console.WriteLine("2. Modul Pembelajaran");
                        Console.WriteLine("3. Video Pembelajaran");
                        Console.WriteLine("4. Notifikasi Pengingat");
                        Console.WriteLine("5. Catatan");
                        Console.WriteLine("Q. Keluar");
                        Console.Write("Pilih menu: ");
                        pilihan = Console.ReadLine()?.Trim().ToUpper();

                        switch (pilihan)
                        {
                            case "1":
                                LatihanSoalController.StartLatihan();
                                break;
                            case "2":
                                ModulController.TampilkanModul();
                                break;
                            case "3":
                                VideoEdukasi.RunVideo();
                                break;
                            case "4":
                                Console.Write("Masukkan bulan (1-12): ");
                                int bulan = int.Parse(Console.ReadLine());
                                Console.Write("Masukkan tahun: ");
                                int tahun = int.Parse(Console.ReadLine());
                                NotifikasiPengingat.TampilkanPengingat(bulan, tahun);
                                break;
                            case "5":
                                CatatanController.StartModulCatatan();
                                break;
                            case "Q":
                                Console.WriteLine("Terima kasih, sampai jumpa!");
                                break;
                            default:
                                Console.WriteLine("Pilihan tidak valid.");
                                break;
                        }

                    } while (pilihan != "Q");
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
