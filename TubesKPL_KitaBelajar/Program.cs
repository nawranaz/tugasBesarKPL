using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TubesKPL_KitaBelajar.Model;
using TubesKPL_KitaBelajar.Services;
using TubesKPL_KitaBelajar.Controllers;
using System.Diagnostics;

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
                        Console.WriteLine("Q. Keluar");
                        Console.Write("Pilih menu: ");

                        string input = Console.ReadLine()?.Trim().ToUpper();

                        
                        if (string.IsNullOrEmpty(input))
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
                            case "Q":
                                Console.WriteLine("Terima kasih, sampai jumpa!");
                                break;
                            default:
                                Console.WriteLine("Pilihan tidak valid.");
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

        static async Task KirimKomentarKeAPI(string username)
        {
            Console.WriteLine("\n=== Forum Diskusi ===");
            Console.Write("Masukkan komentar: ");
            string isi = Console.ReadLine();

            Komentar komentar = new Komentar
            {
                Username = username,
                IsiKomentar = isi,
                Tanggal = DateTime.Now
            };

            using var client = new HttpClient();
            var url = "https://localhost:7173/api/forum";

            try
            {
                var response = await client.PostAsJsonAsync(url, komentar);

                if (response.IsSuccessStatusCode)
                {
                    Console.WriteLine("Komentar berhasil dikirim ke forum!");
                }
                else
                {
                    Console.WriteLine($"Gagal kirim komentar. Status: {response.StatusCode}");
                }
            }
            catch (HttpRequestException ex)
            {
                Console.WriteLine($"Gagal koneksi ke API: {ex.Message}");
            }
        }
    }
}
