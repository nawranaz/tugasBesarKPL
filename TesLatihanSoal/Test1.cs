using TubesKPL_KitaBelajar.Controllers;

namespace TesLatihanSoal
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void Test_AlurUtamaLatihanSoal()
        {
            var simulatedInput = new StringReader(
                "M\n" +
                "1\n" +
                "A\n" +
                "B\n" +
                "C\n" +
                "D\n" +
                "Q\n"
            );

            var output = new StringWriter();

            Console.SetIn(simulatedInput);
            Console.SetOut(output);

            LatihanSoalController.StartLatihan();

            string hasilOutput = output.ToString();

            Assert.IsTrue(hasilOutput.Contains("LATIHAN SOAL"));
            Assert.IsTrue(hasilOutput.Contains("Pilih Mata Pelajaran"));
            Assert.IsTrue(hasilOutput.Contains("Soal 1"));
            Assert.IsTrue(hasilOutput.Contains("Latihan Selesai"));
        }
    }
}
