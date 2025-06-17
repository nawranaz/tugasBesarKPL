using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TubesKPL_KitaBelajar.Controllers;

namespace TestNotifikasiPengingat
{
    [TestClass]
    public class Test1
    {
        [TestMethod]
        public void TampilkanPengingat_Bulan6()
        {
            int bulan = 6;
            int tahun = 2024;

            using StringWriter sw = new();
            Console.SetOut(sw);

            NotifikasiPengingat.TampilkanPengingat(bulan, tahun);

            string output = sw.ToString();

            Assert.IsTrue(output.Contains("Reminder Belajar 6, 2024"));
            Assert.IsTrue(output.Contains("Jadwal hari ke-1 : Membaca materi dan mengerjakan kuis bab 4!"));
            Assert.IsTrue(output.Contains("Jadwal hari ke-7 : Membaca materi dan mengerjakan kuis bab 5!"));
            Assert.IsTrue(output.Contains("Jadwal hari ke-14 : Membaca materi dan mengerjakan kuis bab 6!"));
            Assert.IsTrue(output.Contains("Jadwal hari ke-28 : Evaluasi kuis bulanan!"));
        }

        [TestMethod]
        public void GetHariPerBulan_FebruariLeapYear_Return29()
        {
            int bulan = 2;
            int tahun = 2024;

            int result = (int)typeof(NotifikasiPengingat)
                .GetMethod("GetHariPerBulan", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                .Invoke(null, new object[] { bulan, tahun });

            Assert.AreEqual(29, result);
        }

        [TestMethod]
        public void GetHariPerBulan_FebruariNonLeapYear_Return28()
        {
            int bulan = 2;
            int tahun = 2023;

            int result = (int)typeof(NotifikasiPengingat)
                .GetMethod("GetHariPerBulan", System.Reflection.BindingFlags.NonPublic | System.Reflection.BindingFlags.Static)
                .Invoke(null, new object[] { bulan, tahun });

            Assert.AreEqual(28, result);
        }
    }
}
