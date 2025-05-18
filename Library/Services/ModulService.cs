using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace TubesKPL_KitaBelajar.Library.Services
{
    public static class ModulService
    {
        public static List<T> LoadData<T>(string fileName)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", fileName);

            if (!File.Exists(filePath))
                return new List<T>();

            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<List<T>>(json);
        }
    }
}
