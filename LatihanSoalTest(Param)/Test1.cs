using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;
using System;
using System.Reflection;
using TubesKPL_KitaBelajar.Controllers;

namespace LatihanSoalTest_Param_
{
    [TestClass]
    public sealed class Test1
    {
        private class DummyData
        {
            public string Name { get; set; }
            public int Score { get; set; }
        }

        [TestMethod]
        public void LatihanSoalParam()
        {
            // Arrange
            string fileName = "dummy_merge.json";
            string testDir = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data");
            Directory.CreateDirectory(testDir);
            string filePath = Path.Combine(testDir, fileName);

            var originalData = new List<DummyData>
            {
                new DummyData { Name = "kelompok2", Score = 100 }
            };

            // Act - Save
            var saveMethod = typeof(LatihanSoalController)
                .GetMethod("SaveDataToJson", BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(typeof(List<DummyData>));
            saveMethod.Invoke(null, new object[] { originalData, fileName });

            // Act - Load
            var loadMethod = typeof(LatihanSoalController)
                .GetMethod("LoadDataFromJson", BindingFlags.NonPublic | BindingFlags.Static)
                .MakeGenericMethod(typeof(List<DummyData>));
            var loadedData = (List<DummyData>)loadMethod.Invoke(null, new object[] { fileName });

            // Assert
            Assert.IsNotNull(loadedData);
            Assert.AreEqual(1, loadedData.Count);
            Assert.AreEqual("kelompok2", loadedData[0].Name);
            Assert.AreEqual(100, loadedData[0].Score);
        }
    }
}
