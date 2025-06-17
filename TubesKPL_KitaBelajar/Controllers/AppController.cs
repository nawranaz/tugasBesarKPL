using System;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using TubesKPL_KitaBelajar.Library.Model;
using TubesKPL_KitaBelajar.Library.Services;

namespace TubesKPL_KitaBelajar.Controllers
{
    public class AppController
    {
        private User currentUser;
        private IAuthService authService = new AuthService();

        public bool Login(string username, string password)
        {
            if (string.IsNullOrWhiteSpace(username) || string.IsNullOrWhiteSpace(password))
                return false;

            currentUser = new User { Username = username, Password = password };
            return authService.Login(currentUser);
        }

        public string[] GetMenu()
        {
            return new string[]
            {
                "1. Latihan Soal",
                "2. Modul Pembelajaran",
                "3. Video Pembelajaran",
                "4. Notifikasi Pengingat",
                "5. Forum Diskusi",
                "6. Catatan",
                "Q. Keluar"
            };
        }

        public void StartLatihan()
        {
            // Buat instance dari LatihanSoalController
            var latihanSoalController = new LatihanSoalController();

            // Hubungkan delegasi jika diperlukan
            latihanSoalController.ShowToUser = (msg) => Console.WriteLine(msg);
            latihanSoalController.GetUserInput = () => Console.ReadLine();
            latihanSoalController.ShowSoalKeUser = (question, options) =>
            {
                Console.WriteLine(question);
                for (int i = 0; i < options.Length; i++)
                {
                    Console.WriteLine($"{(char)('A' + i)}. {options[i]}");
                }
            };
            latihanSoalController.TampilkanHasil = (benar, salah, nilai) =>
            {
                Console.WriteLine($"Benar: {benar}, Salah: {salah}, Nilai: {nilai}");
            };

            // Mulai latihan
            latihanSoalController.StartLatihan(); // Memanggil metode dari instance
        }

        public void ShowModul()
        {
            ModulController.TampilkanModul();
        }

        public void RunVideo()
        {
            VideoEdukasi.RunVideo();
        }

        public void ShowPengingat(int bulan, int tahun)
        {
            NotifikasiPengingat.TampilkanPengingat(bulan, tahun);
        }

        public async Task<bool> KirimKomentar(string isiKomentar)
        {
            if (currentUser == null) return false;

            Komentar komentar = new Komentar
            {
                Username = currentUser.Username,
                IsiKomentar = isiKomentar,
                Tanggal = DateTime.Now
            };

            using var client = new HttpClient();
            var url = "https://localhost:7173/api/forum";

            try
            {
                var response = await client.PostAsJsonAsync(url, komentar);
                return response.IsSuccessStatusCode;
            }
            catch
            {
                return false;
            }
        }

        public void StartCatatan()
        {
            CatatanController.StartModulCatatan();
        }
    }
}
