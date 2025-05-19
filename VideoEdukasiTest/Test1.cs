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
                "1\n" +
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
    }
}
