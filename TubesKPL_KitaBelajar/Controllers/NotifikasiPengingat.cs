using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace TubesKPL_KitaBelajar.Controllers
{
    internal class NotifikasiPengingat
    {
        private static Dictionary<int, Dictionary<int, string>> jadwalPengingatPerBulan = new()
        {
            {
                5, new Dictionary<int, string> {
                    { 1, "Membaca materi dan mengerjakan kuis bab 1!" },
                    { 7, "Membaca materi dan mengerjakan kuis kuis bab 2!" },
                    { 14, "Membaca materi dan mengerjakan kuis bab 3! "},
                    { 28, "Evaluasi kuis bulanan!" }
                }

            },
            {
                6, new Dictionary<int, string> {
                    { 1, "Membaca materi dan mengerjakan kuis bab 4!" },
                    { 7, "Membaca materi dan mengerjakan kuis kuis bab 5!" },
                    { 14, "Membaca materi dan mengerjakan kuis bab 6! "},
                    { 28, "Evaluasi kuis bulanan!" }
                }

            },
            {
                7, new Dictionary<int, string> {
                    { 1, "Membaca materi dan mengerjakan kuis bab 7!" },
                    { 7, "Membaca materi dan mengerjakan kuis kuis bab 8!" },
                    { 14, "Evaluasi kuis bab 7 dan 8! "},
                    { 28, "Latihan Ujian Tengah Semester!" }
                }

            }
        };

        public static void TampilkanPengingat(int bulan, int tahun)
        {
            int jumlahHari = GetHariPerBulan(bulan, tahun);
            Console.WriteLine($"\nReminder Belajar {bulan}, {tahun}");
            if (!jadwalPengingatPerBulan.ContainsKey(bulan))
            {
                Console.WriteLine("Tidak ada pengingat atau jadwal yang tersedia untuk bulan ini.");
                return;
            }

            var pengingatBulan = jadwalPengingatPerBulan[bulan];

            for (int hari = 1; hari <= jumlahHari; hari++)
            {
                if (pengingatBulan.ContainsKey(hari))
                {
                    Console.WriteLine($"Jadwal hari ke-{hari} : {pengingatBulan[hari]}");
                }
            }

        }

        private static int GetHariPerBulan(int bulan, int tahun)
        {
            int[] hariPerBulan = { 31, 28, 31, 30, 31, 30, 31, 31, 30, 31, 30, 31 };
            return (bulan == 2 && DateTime.IsLeapYear(tahun)) ? 29 : hariPerBulan[bulan - 1];
        }
    }
}
