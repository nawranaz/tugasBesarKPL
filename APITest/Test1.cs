using Microsoft.VisualStudio.TestTools.UnitTesting;
using TubesKPL_KitaBelajar_API;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;

namespace TesAPI
{
    [TestClass]
    public sealed class Test1
    {
        [TestMethod]
        public void TambahKomentar()
        {
            // Buat controller
            var controller = new ForumController();

            // Buat komentar
            var komentarBaru = new Komentar
            {
                Username = "pemula",
                IsiKomentar = "Halo ini test dari pemula"
            };

            // Tambahkan komentar ke controller
            var hasilPost = controller.PostKomentar(komentarBaru);

            // Ambil semua komentar
            var hasilGet = controller.GetKomentar();
            var okResult = hasilGet.Result as OkObjectResult;
            var daftarKomentar = okResult.Value as List<Komentar>;

            // Cek hasilnya
            Assert.IsNotNull(daftarKomentar);
            Assert.AreEqual(1, daftarKomentar.Count);
            Assert.AreEqual("pemula", daftarKomentar[0].Username);
        }
    }
}
