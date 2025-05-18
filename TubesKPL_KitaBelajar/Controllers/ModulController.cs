using System;
using System.Linq;
using TubesKPL_KitaBelajar.Services;
using TubesKPL_KitaBelajar.Model;
using System.Collections.Generic;
<<<<<<< Updated upstream
=======
using TubesKPL_KitaBelajar.Library.Services;
using TubesKPL_KitaBelajar.Library.Model;
using System.Text.Json;

>>>>>>> Stashed changes

namespace TubesKPL_KitaBelajar.Controllers
{
    public static class ModulController
    {
        public static void TampilkanModul()
        {
            var modulList = ModulService.LoadData<ModulPembelajaran>("modul.json");

            if (modulList.Count == 0)
            {
                Console.WriteLine("\nBelum ada modul pembelajaran yang tersedia.");
                return;
            }

            var rekomendasiMateri = GetMateriRekomendasi();
            if (rekomendasiMateri.Any())
            {
                Console.WriteLine("\n📌 Rekomendasi Materi untuk Diulang (berdasarkan hasil latihan soal):");
                foreach (var materi in rekomendasiMateri)
                {
                    Console.WriteLine($"- {materi}");
                }
                Console.WriteLine("👉 Disarankan untuk membaca ulang modul materi tersebut.\n");
            }

            Console.WriteLine("\n Daftar Mata Pelajaran yang Tersedia");
            var mapelUnik = modulList
                .Select(m => m.MataPelajaran)
                .Distinct()
                .ToList();

            for (int i = 0; i < mapelUnik.Count; i++)
            {
                Console.WriteLine($"{i + 1}. {mapelUnik[i]}");
            }

            Console.Write("\nPilih nomor mata pelajaran: ");
            string input = Console.ReadLine()?.Trim();

            if (!int.TryParse(input, out int pilihan) || pilihan < 1 || pilihan > mapelUnik.Count)
            {
                Console.WriteLine("Pilihan tidak valid.");
                return;
            }

            string mapelDipilih = mapelUnik[pilihan - 1];

            var modulTerkait = modulList
                .Where(m => string.Equals(m.MataPelajaran, mapelDipilih, StringComparison.OrdinalIgnoreCase))
                .ToList();

            Console.WriteLine($"\nModul untuk Mata Pelajaran: {mapelDipilih}");
            foreach (var modul in modulTerkait)
            {
                Console.WriteLine($"\nJudul     : {modul.Judul}");
                Console.WriteLine($"Deskripsi : {modul.Deskripsi}");
                Console.WriteLine($"Konten    : {modul.Konten}");
            }
        }
<<<<<<< Updated upstream
=======

        public static void CariModulDariInput()
        {
            Console.Write("Masukkan kata kunci: ");
            string keyword = Console.ReadLine()?.Trim();

            if (string.IsNullOrWhiteSpace(keyword) || keyword.Length < 3)
            {
                Console.WriteLine("Kata kunci terlalu pendek atau tidak valid. Minimal 3 karakter.");
                return;
            }

            List<ModulPembelajaran> semuaModul;
            try
            {
                semuaModul = ModulService.LoadData<ModulPembelajaran>("modul.json");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Terjadi kesalahan saat memuat data modul: {ex.Message}");
                return;
            }

            if (semuaModul == null || semuaModul.Count == 0)
            {
                Console.WriteLine("Data modul kosong atau tidak ditemukan.");
                return;
            }

            var hasil = ModulSearchService.CariModul(semuaModul, keyword);

            if (hasil.Count == 0)
            {
                Console.WriteLine("Tidak ditemukan modul dengan kata kunci tersebut.");
            }
            else
            {
                Console.WriteLine($"\nDitemukan {hasil.Count} modul:");
                foreach (var modul in hasil)
                {
                    string judul = modul?.Judul ?? "(Tidak ada judul)";
                    string mapel = modul?.MataPelajaran ?? "(Tidak ada mapel)";
                    Console.WriteLine($"- {judul} ({mapel})");
                }
            }
        }
        private static List<string> GetMateriRekomendasi()
        {
            try
            {
                string path = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", "userProgress.json");
                if (!File.Exists(path)) return new List<string>();

                string json = File.ReadAllText(path);
                var progressList = JsonSerializer.Deserialize<List<UserProgress>>(json);

                var service = new RekomendasiMateri(progressList);
                return service.GetRekomendasi();
            }
            catch
            {
                return new List<string>();
            }
        }

>>>>>>> Stashed changes
    }
}
