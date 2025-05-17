using System;
using TubesKPL_KitaBelajar.Model;
using TubesKPL_KitaBelajar.Services;
using TubesKPL_KitaBelajar.Controllers;
using System.Diagnostics;

namespace TubesKPL_KitaBelajar
{
    class Program
    {
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
                        try
                        {
                            user = GetUserInput();

                            
                            if (string.IsNullOrWhiteSpace(user.Username) || string.IsNullOrWhiteSpace(user.Password))
                            {
                                Console.WriteLine("Username atau password tidak boleh kosong.");
                                state = AppState.LOGIN;
                                break;
                            }

                            bool result = authService.Login(user);
                            Console.WriteLine(result ? "\nLogin berhasil!\n" : "\nLogin gagal.");

                            state = result ? AppState.MENU : AppState.EXIT;
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Terjadi kesalahan saat login: {ex.Message}");
                            state = AppState.EXIT;
                        }
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

                        
                        if (string.IsNullOrEmpty(input))
                        {
                            Console.WriteLine("Input tidak boleh kosong.");
                            state = AppState.MENU;
                            break;
                        }

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
                        try
                        {
                            LatihanSoalController.StartLatihan();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Terjadi kesalahan: {ex.Message}");
                        }
                        state = AppState.MENU;
                        break;

                    case AppState.MODUL:
                        try
                        {
                            ModulController.TampilkanModul();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Terjadi kesalahan saat menampilkan modul: {ex.Message}");
                        }
                        state = AppState.MENU;
                        break;

                    case AppState.VIDEO:
                        try
                        {
                            VideoEdukasi.RunVideo();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Terjadi kesalahan saat menjalankan video: {ex.Message}");
                        }
                        state = AppState.MENU;
                        break;

                    case AppState.PENGINGAT:
                        try
                        {
                            Console.Write("Masukkan bulan (1-12): ");
                            string bulanStr = Console.ReadLine();

                            if (!int.TryParse(bulanStr, out int bulan) || bulan < 1 || bulan > 12)
                            {
                                Console.WriteLine("Bulan tidak valid.");
                                break;
                            }

                            Console.Write("Masukkan tahun: ");
                            string tahunStr = Console.ReadLine();

                            if (!int.TryParse(tahunStr, out int tahun))
                            {
                                Console.WriteLine("Tahun tidak valid.");
                                break;
                            }

                            NotifikasiPengingat.TampilkanPengingat(bulan, tahun);
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Kesalahan pada pengingat: {ex.Message}");
                        }
                        state = AppState.MENU;
                        break;

                    case AppState.CATATAN:
                        try
                        {
                            CatatanController.StartModulCatatan();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Kesalahan pada modul catatan: {ex.Message}");
                        }
                        state = AppState.MENU;
                        break;
                }

                
                Debug.Assert(Enum.IsDefined(typeof(AppState), state), "State tidak valid!");
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
