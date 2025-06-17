using Microsoft.VisualStudio.TestTools.UnitTesting;
using TubesKPL_KitaBelajar.Library.Services;
using TubesKPL_KitaBelajar.Library.Model;
using System;

namespace TestLogin
{
    [TestClass]
    public class AuthServiceTests
    {
        private AuthService authService;

        [TestInitialize]
        public void Setup()
        {
            authService = new AuthService();
            Environment.SetEnvironmentVariable("VALID_USERNAME", "kelompok2");
            Environment.SetEnvironmentVariable("VALID_PASSWORD", "suksestubes");
        }

        [TestMethod]
        public void LoginBerhasilMakaTrue()
        {
            var user = new User
            {
                Username = "kelompok2",
                Password = "suksestubes"
            };

            bool result = authService.Login(user);

            Assert.IsTrue(result);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void LoginUserNullMakaThrowsException()
        {
            authService.Login(null);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LoginUsernameKosongThrowsException()
        {
            var user = new User
            {
                Username = "",
                Password = "suksestubes"
            };

            authService.Login(user);
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void LoginPasswordKosongMakaThrowsException()
        {
            var user = new User
            {
                Username = "kelompok2",
                Password = ""
            };

            authService.Login(user);
        }

        [TestMethod]
        public void LoginPasswordSalahMakaReturnsFalse()
        {
            var user = new User
            {
                Username = "kelompok2",
                Password = "salahpassword"
            };

            bool result = authService.Login(user);

            Assert.IsFalse(result);
        }

        [TestMethod]
        public void LoginUsernameSalahMakaReturnsFalse()
        {
            var user = new User
            {
                Username = "userlain",
                Password = "suksestubes"
            };

            bool result = authService.Login(user);

            Assert.IsFalse(result);
        }
    }
}
