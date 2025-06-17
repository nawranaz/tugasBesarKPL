using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TubesKPL_KitaBelajar.Library.Model;

namespace RekomendasiTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Rekomendasi_DiberikanJikaNilaiKurangDari70()
        {
            var progressList = new List<UserProgress>
            {
                new UserProgress { NamaMateri = "Matematika", Nilai = 60 },
                new UserProgress { NamaMateri = "Bahasa Inggris", Nilai = 80 },
                new UserProgress { NamaMateri = "IPA", Nilai = 50 }
            };

            var rekomendasi = new RekomendasiMateri(progressList);
            var hasil = rekomendasi.GetRekomendasi();

            CollectionAssert.AreEqual(new List<string> { "Matematika", "IPA" }, hasil);
        }

        [TestMethod]
        public void TidakAdaRekomendasiJikaSemuaLulus()
        {
            var progressList = new List<UserProgress>
            {
                new UserProgress { NamaMateri = "Matematika", Nilai = 70 },
                new UserProgress { NamaMateri = "Bahasa Inggris", Nilai = 90 }
            };

            var rekomendasi = new RekomendasiMateri(progressList);
            var hasil = rekomendasi.GetRekomendasi();

            Assert.AreEqual(0, hasil.Count);
        }

        [TestMethod]
        public void NamaMateriKosongTidakDirekomendasikan()
        {
            var progressList = new List<UserProgress>
            {
                new UserProgress { NamaMateri = "", Nilai = 30 },
                new UserProgress { NamaMateri = null, Nilai = 20 },
                new UserProgress { NamaMateri = "IPA", Nilai = 40 }
            };

            var rekomendasi = new RekomendasiMateri(progressList);
            var hasil = rekomendasi.GetRekomendasi();

            CollectionAssert.AreEqual(new List<string> { "IPA" }, hasil);
        }

        [TestMethod]
        public void ListKosongMenghasilkanRekomendasiKosong()
        {
            var rekomendasi = new RekomendasiMateri(new List<UserProgress>());
            var hasil = rekomendasi.GetRekomendasi();

            Assert.AreEqual(0, hasil.Count);
        }

        [TestMethod]
        public void KonstruktorNullListTidakError()
        {
            var rekomendasi = new RekomendasiMateri(null);
            var hasil = rekomendasi.GetRekomendasi();

            Assert.AreEqual(0, hasil.Count);
        }
    }
}
