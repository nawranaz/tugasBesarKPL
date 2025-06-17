using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using TubesKPL_KitaBelajar.Library.Model;

namespace TubesKPL_KitaBelajar.Controllers
{
    public class LatihanSoalController
    {
        // Menggunakan enum untuk representasi state dengan jelas
        private enum State { START, SELECT_SUBJECT, IN_PROGRESS, COMPLETED, EXIT }

        // Struktur data utama
        private Dictionary<string, List<SoalLatihan>> soalListByMatpel;
        private List<JawabanLatihan> jawabanList;
        private List<UserProgress> userProgressList;

        private string selectedSubject;
        private State currentState;
        private int currentIndex;
        private int jumlahBenar;
        private List<SoalLatihan> soalAktif;

        // Delegasi: memisahkan logika controller dengan tampilan (UI)
        public Action<string> ShowToUser;
        public Func<string> GetUserInput;
        public Action<string, string[]> ShowSoalKeUser;
        public Action<int, int, int> TampilkanHasil;

        // Hindari magic string: mapping input angka ke nama pelajaran
        private static readonly Dictionary<string, string> KodeMapel = new()
        {
            { "1", "Matematika" },
            { "2", "IPA" },
            { "3", "Bahasa Inggris" },
            { "4", "IPS" }
        };

        public LatihanSoalController()
        {
            LoadData();
            userProgressList = new List<UserProgress>();
            currentState = State.START;
        }

        // Entry point latihan
        public void StartLatihan() => RunNextState();

        // Automata state machine untuk transisi antar tahap
        public void RunNextState()
        {
            switch (currentState)
            {
                case State.START:
                    ShowStartMenu(); break;
                case State.SELECT_SUBJECT:
                    SelectSubjectInteractive(); break;
                case State.IN_PROGRESS:
                    TampilkanSoal(); break;
                case State.COMPLETED:
                    Selesai(); break;
            }
        }

        // Menampilkan menu awal
        private void ShowStartMenu()
        {
            ShowToUser?.Invoke("=== LATIHAN SOAL ===\nTekan 'M' untuk memulai atau 'E' untuk keluar.");
            var command = GetUserInput?.Invoke()?.ToUpper()?.Trim();

            if (string.IsNullOrEmpty(command)) return;

            // Gunakan switch expression modern untuk efisiensi
            currentState = command switch
            {
                "M" => State.SELECT_SUBJECT,
                "E" => State.EXIT,
                _ => currentState
            };

            RunNextState();
        }

        // Mode interaktif untuk CLI
        private void SelectSubjectInteractive()
        {
            ShowToUser?.Invoke("Pilih Mata Pelajaran:\n1. Matematika\n2. IPA\n3. Bahasa Inggris\n4. IPS");
            var input = GetUserInput?.Invoke()?.Trim();

            if (string.IsNullOrEmpty(input)) return;

            // Validasi input dan hindari nested switch-case
            if (!KodeMapel.TryGetValue(input, out selectedSubject) || !soalListByMatpel.ContainsKey(selectedSubject))
            {
                ShowToUser?.Invoke("Pilihan tidak valid.");
                return;
            }

            MulaiSoal();
        }

        // Untuk penggunaan GUI (langsung dari tombol)
        public void SelectSubject(string subject)
        {
            if (string.IsNullOrWhiteSpace(subject) || !soalListByMatpel.ContainsKey(subject))
            {
                ShowToUser?.Invoke("Mata pelajaran tidak ditemukan.");
                return;
            }

            selectedSubject = subject;
            MulaiSoal();
        }

        // Menginisialisasi soal dan state
        private void MulaiSoal()
        {
            soalAktif = soalListByMatpel[selectedSubject];
            currentIndex = 0;
            jumlahBenar = 0;
            currentState = State.IN_PROGRESS;
            RunNextState();
        }

        // Untuk GUI menampilkan soal secara manual
        public SoalLatihan GetCurrentQuestion()
        {
            return (currentIndex < soalAktif.Count) ? soalAktif[currentIndex] : null;
        }

        // Menampilkan soal ke pengguna
        private void TampilkanSoal()
        {
            if (currentIndex < soalAktif.Count)
            {
                var soal = soalAktif[currentIndex];
                ShowSoalKeUser?.Invoke(soal.Question, soal.Options);
            }
            else
            {
                currentState = State.COMPLETED;
                RunNextState();
            }
        }

        // Proses penilaian dan feedback akhir
        private void Selesai()
        {
            int total = soalAktif.Count;
            int nilai = (int)((double)jumlahBenar / total * 100);

            TampilkanHasil?.Invoke(jumlahBenar, total - jumlahBenar, nilai);

            // Update atau tambahkan progress user
            var existing = userProgressList.FirstOrDefault(p => p.NamaMateri == selectedSubject);
            if (existing != null)
                existing.Nilai = nilai;
            else
                userProgressList.Add(new UserProgress { NamaMateri = selectedSubject, Nilai = nilai });

            SaveDataToJson(userProgressList, "userProgress.json");
            currentState = State.EXIT;
        }

        // Mengevaluasi jawaban pengguna
        public void KirimJawaban(string jawabanUser)
        {
            if (currentState != State.IN_PROGRESS || currentIndex >= soalAktif.Count)
                return;

            if (string.IsNullOrWhiteSpace(jawabanUser))
            {
                ShowToUser?.Invoke("Jawaban tidak boleh kosong.");
                return;
            }

            // Ambil huruf pertama untuk dibandingkan (case-insensitive)
            char jawabanBenar = jawabanList[currentIndex].Answer.FirstOrDefault();
            char jawabanUserChar = char.ToUpper(jawabanUser[0]);

            if (jawabanUserChar == jawabanBenar)
            {
                ShowToUser?.Invoke("Jawaban benar!");
                jumlahBenar++;
            }
            else
            {
                ShowToUser?.Invoke($"Salah. Jawaban benar: {jawabanBenar}");
            }

            currentIndex++;
            RunNextState();
        }

        // Load soal dan jawaban dari file JSON
        private void LoadData()
        {
            soalListByMatpel = LoadDataFromJson<Dictionary<string, List<SoalLatihan>>>("soal.json") ?? new();
            jawabanList = LoadDataFromJson<List<JawabanLatihan>>("jawaban.json") ?? new();
        }

        // Fungsi reusable untuk load JSON
        private T LoadDataFromJson<T>(string fileName)
        {
            string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", fileName);
            if (!File.Exists(filePath)) return default;

            try
            {
                string json = File.ReadAllText(filePath);
                return JsonSerializer.Deserialize<T>(json);
            }
            catch (Exception ex)
            {
                // Hindari crash saat gagal baca file
                ShowToUser?.Invoke($"Gagal memuat data dari {fileName}: {ex.Message}");
                return default;
            }
        }

        // Fungsi reusable untuk simpan data ke JSON
        private void SaveDataToJson<T>(T data, string fileName)
        {
            try
            {
                string filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "Data", fileName);
                string json = JsonSerializer.Serialize(data, new JsonSerializerOptions { WriteIndented = true });
                File.WriteAllText(filePath, json);
            }
            catch (Exception ex)
            {
                // Tangani error saat simpan data
                ShowToUser?.Invoke($"Gagal menyimpan data: {ex.Message}");
            }
        }
    }
}
