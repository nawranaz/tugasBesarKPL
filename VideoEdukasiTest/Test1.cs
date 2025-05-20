using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.IO;
using TubesKPL_KitaBelajar.Controllers;

namespace VideoEdukasiTest
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TampilkanVideo()
        {
            var simulatedInput = new StringReader(
                "4\n" +
                "1\n" +
                "1\n"
            );

            var output = new StringWriter();

            Console.SetIn(simulatedInput);
            Console.SetOut(output);

            VideoEdukasi.RunVideo();

            string hasilOutput = output.ToString();

            Assert.IsTrue(hasilOutput.Contains("Daftar video untuk kategori"));
            Assert.IsTrue(hasilOutput.Contains("Memutar"));

        }

        [TestMethod]
        public void InputInvalid()
        {
            var simulatedInput = new StringReader(
                "5\n" +
                "\n" 
            );
            var output = new StringWriter();

            Console.SetIn(simulatedInput);
            Console.SetOut(output);

            VideoEdukasi.RunVideo();

            string hasilOutput = output.ToString();
            Console.WriteLine(hasilOutput);
            Assert.IsFalse(hasilOutput.Contains("Kategori tidak ditemukan!"));
        }
    }
}
