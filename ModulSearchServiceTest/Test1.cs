using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using TubesKPL_KitaBelajar.Library.Model;
using TubesKPL_KitaBelajar.Library.Services;

namespace TestModul
{
    [TestClass]
    public class ModulSearchServiceTest
    {
        
        private List<ModulPembelajaran> modulList = new();


        [TestInitialize]
        public void Setup()
        {
            modulList = new List<ModulPembelajaran>
            {
                new ModulPembelajaran {
                    MataPelajaran = "Matematika",
                    Judul = "Perkalian dan Aplikasi dalam Kehidupan Sehari-hari",
                    Deskripsi = "Modul ini menjelaskan konsep dasar perkalian serta penerapannya.",
                    Konten = "- Perkalian adalah operasi matematika dasar. Contoh: 4 x 20 = 80.\n- Jika seseorang memberi 8 jeruk ke 15 orang, maka total jeruk = 15 x 8 = 120."
                },
                new ModulPembelajaran {
                    MataPelajaran = "IPA",
                    Judul = "Ciri-Ciri Hewan dan Perubahan Wujud Benda",
                    Deskripsi = "Mengenal hewan dan sumber energi serta wujud benda.",
                    Konten = "- Ayam berkokok, kambing mengembik.\n- Energi manusia berasal dari makanan.\n- Es mencair menjadi air (perubahan mencair)."
                },
                new ModulPembelajaran {
                    MataPelajaran = "Bahasa Inggris",
                    Judul = "Weather and Seasons",
                    Deskripsi = "Memahami cuaca dan musim dalam Bahasa Inggris.",
                    Konten = "- Rainy = hujan, Windy = berangin, Sunny = cerah.\n- Snow terjadi di musim dingin (winter).\n- I cannot play outside because it is rainy."
                },
                new ModulPembelajaran {
                    MataPelajaran = "IPS",
                    Judul = "Lingkungan dan Jenis-Jenis Pasar",
                    Deskripsi = "Mempelajari jenis lingkungan dan pasar dalam kehidupan sosial.",
                    Konten = "- Lingkungan alam terbentuk secara alami.\n- Pasar induk menjual barang dalam jumlah besar.\n- Pasar harian menjual kebutuhan setiap hari."
                }
            };
        }

        [TestMethod]
        public void CariModul_KeywordDalamJudul_ReturnsMatematikaModul()
        {
            var result = ModulSearchService.CariModul(modulList, "Perkalian");
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Perkalian dan Aplikasi dalam Kehidupan Sehari-hari", result[0].Judul);
        }

        [TestMethod]
        public void CariModul_KeywordDalamKonten_ReturnsIPAmodul()
        {
            var result = ModulSearchService.CariModul(modulList, "berkokok");
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Ciri-Ciri Hewan dan Perubahan Wujud Benda", result[0].Judul);
        }

        [TestMethod]
        public void CariModul_KeywordTidakAda_ReturnsEmpty()
        {
            var result = ModulSearchService.CariModul(modulList, "Trigonometri");
            Assert.AreEqual(0, result.Count);
        }

        [TestMethod]
        public void CariModul_KeywordCaseInsensitive_ReturnsBahasaInggrisModul()
        {
            var result = ModulSearchService.CariModul(modulList, "weather");
            Assert.AreEqual(1, result.Count);
            Assert.AreEqual("Weather and Seasons", result[0].Judul);
        }

        [TestMethod]
        public void CariModul_KeywordPadaBeberapaModul_ReturnsMultipleResults()
        {
            var result = ModulSearchService.CariModul(modulList, "Pasar");
            Assert.AreEqual(1, result.Count); // Karena hanya IPS berisi kata "Pasar"
            Assert.AreEqual("Lingkungan dan Jenis-Jenis Pasar", result[0].Judul);
        }
    }
}
