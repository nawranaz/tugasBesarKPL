using System;
using System.Collections.Generic;

namespace VideoEdukasiApp
{
    class Program
    {
        // Representasi data video menggunakan class
        public class Video
        {
            public string Judul { get; set; }
            public string Deskripsi { get; set; }
            public string FilePath { get; set; }
        }

        static void Main(string[] args)
        {
            // Table-driven: daftar video disimpan dalam Dictionary berdasarkan kategori
            Dictionary<string, List<Video>> videoTable = new Dictionary<string, List<Video>>
            {
                {
                    "Matematika", new List<Video>
                    {
                        new Video { Judul = "Penjumlahan dan Pengurangan", Deskripsi = "Belajar operasi tambah dan kurang", FilePath = "video/penjumlahan.mp4" },
                        new Video { Judul = "Perkalian Dasar", Deskripsi = "Belajar perkalian untuk anak SD", FilePath = "video/perkalian.mp4" }
                    }
                },
                {
                    "Bahasa Inggris", new List<Video>
                    {
                        new Video { Judul = "Alphabet", Deskripsi = "Belajar huruf A sampai Z", FilePath = "video/alphabet.mp4" },
                        new Video { Judul = "Greetings", Deskripsi = "Belajar sapaan dasar dalam Bahasa Inggris", FilePath = "video/greetings.mp4" }
                    }
                }
            };

            Console.WriteLine("=== Video ===");
            Console.WriteLine("Kategori Tersedia: ");
            foreach (var kategori in videoTable.Keys)
            {
                Console.WriteLine($"- {kategori}");
            }

            Console.Write("\nMasukkan kategori video: ");
            string inputKategori = Console.ReadLine();
            int inputKategoriIndex;
            if (int.TryParse(inputKategori, out inputKategoriIndex) && inputKategoriIndex >= 1 && inputKategoriIndex <= videoTable.Count)
            {
                inputKategori = videoTable.Keys.ElementAt(inputKategoriIndex - 1);
            }

            if (videoTable.ContainsKey(inputKategori))
            {
                var videos = videoTable[inputKategori];
                Console.WriteLine($"\nDaftar video untuk kategori '{inputKategori}':\n");

                for (int i = 0; i < videos.Count; i++)
                {
                    Console.WriteLine($"{i + 1}. {videos[i].Judul} - {videos[i].Deskripsi}");
                }

                Console.Write("\nMasukkan nomor video yang ingin diputar: ");
                string pilihan = Console.ReadLine();
                int index;

                if (int.TryParse(pilihan, out index) && index >= 1 && index <= videos.Count)
                {
                    var selectedVideo = videos[index - 1];
                    Console.WriteLine($"\nMemutar: {selectedVideo.Judul}");
                    System.Diagnostics.Process.Start("explorer", selectedVideo.FilePath);
                }
                else
                {
                    Console.WriteLine("Nomor tidak valid!");
                }
            }
            else
            {
                Console.WriteLine("Kategori tidak ditemukan!");
            }

            Console.WriteLine("\nTekan apa saja untuk keluar...");
            Console.ReadKey();
        }
    }
}
