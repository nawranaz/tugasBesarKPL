using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TubesKPL_KitaBelajar.Controllers
{
    class VideoEdukasi
    {
        // Representasi data video menggunakan class
        public class Video
        {
            public string Judul { get; set; }
            public string Deskripsi { get; set; }
            public string FilePath { get; set; }
        }

        public static void RunVideo()
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
                },
                {
                    "IPA", new List<Video>
                    {
                        new Video { Judul = "Sistem Pernapasan", Deskripsi = "Proses pernapasan manusia", FilePath = "video/pernapasan.mp4" },
                        new Video { Judul = "Fotosintesis", Deskripsi = "Proses fotosintesis pada tumbuhan", FilePath = "video/fotosintesis.mp4" }
                    }
                }
            };

            Console.WriteLine("\n=== Video ===");
            Console.WriteLine("Kategori Tersedia: ");
            int num = 1;
            foreach (var kategori in videoTable.Keys)
            {
                Console.WriteLine($"{num}. {kategori}");
                num++;
            }

            Console.Write("Masukkan kategori video: ");
            string inputKategori = Console.ReadLine();
            int inputKategoriIndex;
            if (int.TryParse(inputKategori, out inputKategoriIndex) && inputKategoriIndex >= 1 && inputKategoriIndex <= videoTable.Count)
            {
                inputKategori = videoTable.Keys.ElementAt(inputKategoriIndex - 1);
            }

            if (videoTable.ContainsKey(inputKategori))
            {
                var videos = videoTable[inputKategori];
                Console.WriteLine($"\nDaftar video untuk kategori '{inputKategori}':");

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
                    //System.Diagnostics.Process.Start("explorer", selectedVideo.FilePath);
                    // uncomment untuk memutar video dari file path
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