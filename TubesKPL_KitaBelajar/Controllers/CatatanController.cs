using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Threading.Tasks;
using TubesKPL_KitaBelajar.Model;

namespace TubesKPL_KitaBelajar.Controllers
{
    public class CatatanController
    {
        private static string defaultFolder;
        private static List<Catatan> indexList;
        private const string configFile = "Data/config.json";
        private const string indexFile = "Data/index.json";

        public static void StartModulCatatan()
        {
            defaultFolder = LoadConfig();
            indexList = LoadIndex();

            bool running = true;
            while (running)
            {
                Console.WriteLine("\nMODUL CATATAN");
                Console.WriteLine("1. Tambah Catatan Baru");
                Console.WriteLine("2. Lihat Semua Catatan");
                Console.WriteLine("3. Keluar");
                Console.Write("Pilih menu (1-3): ");

                string command = Console.ReadLine();

                switch (command)
                {
                    case "1":
                        TambahCatatan();
                        break;
                    case "2":
                        LihatCatatan();
                        break;
                    case "3":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Pilihan tidak valid.");
                        break;
                }
            }
        }

        private static string LoadConfig()
        {
            var configText = File.ReadAllText(configFile);
            var config = JsonSerializer.Deserialize<Config>(configText);



            return config.DefaultFolder;
        }

        private static List<Catatan> LoadIndex()
        {
            if (!File.Exists(indexFile))
                return new List<Catatan>();

            string jsonString = File.ReadAllText(indexFile);
            return JsonSerializer.Deserialize<List<Catatan>>(jsonString);
        }

        private static void SimpanIndex()
        {
            var jsonString = JsonSerializer.Serialize(indexList, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(indexFile, jsonString);
        }

        private static void TambahCatatan()
        {
            Console.Write("\nMasukkan Judul Catatan: ");
            string judul = Console.ReadLine();

            Console.Write("Masukkan Isi Catatan: ");
            string isi = Console.ReadLine();

            Console.Write($"Masukkan folder penyimpanan (enter untuk default: {defaultFolder}): ");
            string customFolder = Console.ReadLine();
            string folder = string.IsNullOrWhiteSpace(customFolder) ? defaultFolder : customFolder;

            if (!Directory.Exists(folder))
                Directory.CreateDirectory(folder);

            string filePath = Path.Combine(folder, $"{judul}.json");

            var newCatatan = new Catatan
            {
                Judul = judul,
                Isi = isi,
                Tanggal = DateTime.Now,
                FilePath = filePath
            };


            var jsonString = JsonSerializer.Serialize(newCatatan, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, jsonString);


            indexList.Add(newCatatan);
            SimpanIndex();

            Console.WriteLine($"Catatan berhasil disimpan di {filePath}");
        }

        private static void LihatCatatan()
        {
            Console.WriteLine("\nDaftar Catatan");
            if (indexList.Count == 0)
            {
                Console.WriteLine("Belum ada catatan.");
                return;
            }

            int nomor = 1;
            foreach (var c in indexList)
            {
                Console.WriteLine($"\n{nomor++}. {c.Judul}");
                Console.WriteLine($"   Lokasi file: {c.FilePath}");
                Console.WriteLine($"   Tanggal: {c.Tanggal:dd/MM/yyyy}");
                Console.WriteLine($"   Isi: {c.Isi}");
            }
        }

    }
}