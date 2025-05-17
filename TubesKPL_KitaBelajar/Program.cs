using System;
using TubesKPL_KitaBelajar.Model;
using TubesKPL_KitaBelajar.Services;
using TubesKPL_KitaBelajar.Controllers;

namespace TubesKPL_KitaBelajar
{
    class Program
    {
        //enum pada teknik automata
        enum AppState
        {
            LOGIN,
            MENU,
            LATIHAN_SOAL,
            MODUL,
            VIDEO,
            PENGINGAT,
            CATATAN,
            EXIT
        }

        static void Main(string[] args)
        {
            AppState state = AppState.LOGIN;
            User user = null;
            IAuthService authService = new AuthService();

            while (state != AppState.EXIT)
            {
                switch (state)
                {
                    case AppState.LOGIN:
                        user = GetUserInput();
                        bool result = authService.Login(user);
                        Console.WriteLine(result ? "\nLogin berhasil!\n" : "\nLogin gagal.");

                        state = result ? AppState.MENU : AppState.EXIT;
                        break;

                    case AppState.MENU:
                        Console.WriteLine("\n=== MENU UTAMA ===");
                        Console.WriteLine("1. Latihan Soal");
                        Console.WriteLine("2. Modul Pembelajaran");
                        Console.WriteLine("3. Video Pembelajaran");
                        Console.WriteLine("4. Notifikasi Pengingat");
                        Console.WriteLine("5. Catatan");
                        Console.WriteLine("Q. Keluar");
                        Console.Write("Pilih menu: ");

                        string input = Console.ReadLine()?.Trim().ToUpper();

                        state = input switch
                        {
                            "1" => AppState.LATIHAN_SOAL,
                            "2" => AppState.MODUL,
                            "3" => AppState.VIDEO,
                            "4" => AppState.PENGINGAT,
                            "5" => AppState.CATATAN,
                            "Q" => AppState.EXIT,
                            _ => AppState.MENU
                        };
                        break;

                    case AppState.LATIHAN_SOAL:
                        LatihanSoalController.StartLatihan();
                        state = AppState.MENU;
                        break;

                    case AppState.MODUL:
                        ModulController.TampilkanModul();
                        state = AppState.MENU;
                        break;

                    case AppState.VIDEO:
                        VideoEdukasi.RunVideo();
                        state = AppState.MENU;
                        break;

                    case AppState.PENGINGAT:
                        Console.Write("Masukkan bulan (1-12): ");
                        if (int.TryParse(Console.ReadLine(), out int bulan) && bulan >= 1 && bulan <= 12)
                        {
                            Console.Write("Masukkan tahun: ");
                            if (int.TryParse(Console.ReadLine(), out int tahun))
                            {
                                NotifikasiPengingat.TampilkanPengingat(bulan, tahun);
                            }
                        }
                        else
                        {
                            Console.WriteLine("Input tidak valid.");
                        }
                        state = AppState.MENU;
                        break;

                    case AppState.CATATAN:
                        CatatanController.StartModulCatatan();
                        state = AppState.MENU;
                        break;
                }
            }

            Console.WriteLine("Terima kasih, sampai jumpa!");
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
