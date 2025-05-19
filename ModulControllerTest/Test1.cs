using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using System.Text;
using System.Collections.Generic;
using TubesKPL_KitaBelajar.Controllers;
using TubesKPL_KitaBelajar.Library.Model;

using System.Text.Json;

namespace TestModul
{
    [TestClass]
    public class ModulControllerTest
    {
        [TestMethod]
        public void Test_TampilkanModul_TanpaRekomendasi()
        {
            // Setup dummy data
            var dummyModul = new List<ModulPembelajaran>
            {
                new ModulPembelajaran
                {
                    Judul = "Judul 1",
                    Deskripsi = "Deskripsi 1",
                    Konten = "Konten 1",
                    MataPelajaran = "Matematika"
                },
                new ModulPembelajaran
                {
                    Judul = "Judul 2",
                    Deskripsi = "Deskripsi 2",
                    Konten = "Konten 2",
                    MataPelajaran = "Fisika"
                }
            };

            string dataPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(dataPath);

            File.WriteAllText(Path.Combine(dataPath, "modul.json"), JsonSerializer.Serialize(dummyModul));
            File.WriteAllText(Path.Combine(dataPath, "userProgress.json"), "[]"); // Kosongkan progress

            // Simulasi input pengguna: pilih Mata Pelajaran ke-2 (yaitu Matematika)
            var input = new StringReader("2\n");
            var output = new StringWriter();
            Console.SetIn(input);
            Console.SetOut(output);

            // Jalankan metode yang diuji
            ModulController.TampilkanModul();

            string hasilOutput = output.ToString();

            // Validasi output
            Assert.IsTrue(hasilOutput.Contains("Daftar Mata Pelajaran"));
            Assert.IsTrue(hasilOutput.Contains("Matematika"));
            Assert.IsTrue(hasilOutput.Contains("Judul 1"));
            Assert.IsTrue(hasilOutput.Contains("Deskripsi 1"));
            Assert.IsTrue(hasilOutput.Contains("Konten 1"));
        }





    }
}
