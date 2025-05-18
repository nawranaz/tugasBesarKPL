using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

using TubesKPL_KitaBelajar.Library.Model;


namespace TubesKPL_KitaBelajar.Controllers
{
    public static class LatihanSoalController
    {
        enum State { START, SELECT_SUBJECT, IN_PROGRESS, COMPLETED, EXIT };

        private static Dictionary<string, List<SoalLatihan>> soalListByMatpel;
        private static List<JawabanLatihan> jawabanList;
        private static string selectedSubject;
        private static State currentState;

        public static void StartLatihan()
        {
            soalListByMatpel = LoadDataFromJson<Dictionary<string, List<SoalLatihan>>>("soal.json");
            jawabanList = LoadDataFromJson<List<JawabanLatihan>>("jawaban.json");
            currentState = State.START;

            while (currentState != State.EXIT)
            {
                switch (currentState)
                {
                    case State.START:
                        ShowStartMenu();
                        break;
                    case State.SELECT_SUBJECT:
                        SelectSubject();
                        break;
                    case State.IN_PROGRESS:
                        StartSoal();
                        break;
                    case State.COMPLETED:
                        ShowCompletionMessage();
                        break;
                }
            }
        }

        private static void ShowStartMenu()
        {
            Console.WriteLine("\n=== LATIHAN SOAL ===");
            Console.WriteLine("Tekan 'M' untuk memulai latihan atau 'E' untuk keluar.");
            string command = Console.ReadLine()?.ToUpper().Trim();

            if (command == "M") currentState = State.SELECT_SUBJECT;
            else if (command == "E") currentState = State.EXIT;
            else Console.WriteLine("Perintah tidak valid.");
        }

        private static void SelectSubject()
        {
            Console.WriteLine("\nPilih Mata Pelajaran:");
            Console.WriteLine("1. Matematika");
            Console.WriteLine("2. IPA");
            Console.WriteLine("3. Bahasa Inggris");
            Console.WriteLine("4. IPS");
            Console.Write("Masukkan pilihan (1-4): ");

            string input = Console.ReadLine()?.Trim();
            switch (input)
            {
                case "1": selectedSubject = "Matematika"; break;
                case "2": selectedSubject = "IPA"; break;
                case "3": selectedSubject = "Bahasa Inggris"; break;
                case "4": selectedSubject = "IPS"; break;
                default:
                    Console.WriteLine("Pilihan tidak valid."); return;
            }

            currentState = State.IN_PROGRESS;
        }

        private static void StartSoal()
        {
            Console.WriteLine($"\n=== Latihan {selectedSubject} ===");

            List<SoalLatihan> selectedSoalList = soalListByMatpel[selectedSubject];

            for (int i = 0; i < selectedSoalList.Count; i++)
            {

                var soal = selectedSoalList[i];

                Console.WriteLine($"\nSoal {i + 1}:\n{soal.Question}");

                char[] abcd = { 'A', 'B', 'C', 'D' };
                for (int j = 0; j < soal.Options.Length; j++)
                {
                    Console.WriteLine($"{abcd[j]}. {soal.Options[j]}");
                }

                char jawaban;
                while (true)
                {
                    Console.Write("Jawaban (A–D): ");
                    string input = Console.ReadLine()?.ToUpper()?.Trim();
                    if (input is "A" or "B" or "C" or "D")
                    {
                        jawaban = input[0];
                        break;
                    }
                    Console.WriteLine("Masukkan hanya A, B, C, atau D.");
                }

                if (jawaban == jawabanList[i].Answer[0])
                    Console.WriteLine("Jawaban benar!");
                else
                    Console.WriteLine($"Salah. Jawaban benar: {jawabanList[i].Answer}");
            }

            currentState = State.COMPLETED;
        }

        private static void ShowCompletionMessage()
        {
            Console.WriteLine("Latihan Selesai! Tekan 'Q' untuk keluar.");
            string command = Console.ReadLine()?.ToUpper().Trim();
            if (command == "Q") currentState = State.EXIT;
        }

        // ✅ Generic loader
        private static T LoadDataFromJson<T>(string fileName)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", fileName);
            string json = File.ReadAllText(filePath);
            return JsonSerializer.Deserialize<T>(json);
        }

        private static void Shuffle<T>(List<T> list)
        {
            Random rng = new();
            int n = list.Count;
            while (n > 1)
            {
                n--;
                int k = rng.Next(n + 1);
                (list[n], list[k]) = (list[k], list[n]);
            }
        }
    }
}
