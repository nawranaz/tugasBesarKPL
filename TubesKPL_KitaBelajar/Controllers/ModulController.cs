using System;
using System.Linq;
using TubesKPL_KitaBelajar.Library.Services;
using TubesKPL_KitaBelajar.Library.Model;
using System.Collections.Generic;


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
    }
}
