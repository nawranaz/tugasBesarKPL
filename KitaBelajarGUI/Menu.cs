using System;
using System.Windows.Forms;
using static TubesKPL_KitaBelajar.Program; // agar bisa akses enum AppState langsung

namespace KitaBelajarGUI
{
    public partial class Menu : Form
    {
        // Konstruktor Menu: menginisialisasi komponen GUI
        public Menu()
        {
            InitializeComponent();
        }

        // Event handler untuk tombol Latihan Soal
        private void latihanSoalButton_Click(object sender, EventArgs e)
        {
            CurrentState = AppState.LATIHAN_SOAL; // Set state aplikasi ke LATIHAN_SOAL
            this.Close(); // Tutup form dan kembali ke loop utama
        }

        // Event handler untuk tombol "Modul Pembelajaran"
        private void modulPembelajaranButton_Click(object sender, EventArgs e)
        {
            CurrentState = AppState.MODUL; // Arahkan ke form Modul
            this.Close(); // Tutup form Menu
        }

        // Event handler untuk tombol "Video Pembelajaran"
        private void videoPembelajaranButton_Click(object sender, EventArgs e)
        {
            CurrentState = AppState.VIDEO; // Arahkan ke modul Video
            this.Close(); // Tutup form Menu
        }

        // Event handler untuk tombol "Notifikasi Pengingat"
        private void notifikasiPengingatButton_Click(object sender, EventArgs e)
        {
            CurrentState = AppState.PENGINGAT; // Arahkan ke modul pengingat
            this.Close(); // Tutup form Menu
        }

        // Event handler untuk tombol "Forum Diskusi"
        private void forumDiskusiButton_Click(object sender, EventArgs e)
        {
            CurrentState = AppState.FORUM; // Pindah ke modul forum diskusi
            this.Close(); // Tutup form Menu
        }

        // Event handler untuk tombol "Catatan Belajar"
        private void catatanButton_Click(object sender, EventArgs e)
        {
            CurrentState = AppState.CATATAN; // Pindah ke modul catatan
            this.Close(); // Tutup form Menu
        }

        // Event handler untuk tombol "Keluar"
        private void exitButton_Click(object sender, EventArgs e)
        {
            CurrentState = AppState.EXIT; // Keluar dari aplikasi
            this.Close(); // Tutup form Menu
        }
    }
}
