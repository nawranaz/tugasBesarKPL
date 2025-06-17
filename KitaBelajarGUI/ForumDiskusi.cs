using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;
using System.Windows.Forms;
using TubesKPL_KitaBelajar;
using TubesKPL_KitaBelajar_API; // Pastikan referensinya sudah ditambahkan

namespace KitaBelajarGUI
{
    public partial class ForumDiskusi : Form
    {
        private readonly string _username;
        private readonly HttpClient _httpClient = new HttpClient();
        private readonly string _apiUrl = "https://localhost:7173/api/forum";

        public ForumDiskusi(string username)
        {
            InitializeComponent();
            if (Program.LoggedInUser == null)
            {
                MessageBox.Show("User belum login!");
                this.Close();
                return;
            }
            _username = username;
        }

        private async void ForumDiskusi_Load(object sender, EventArgs e)
        {
            await LoadKomentar();
        }

        private async Task LoadKomentar()
        {
            try
            {
                var komentarList = await _httpClient.GetFromJsonAsync<List<Komentar>>(_apiUrl);
                listBox1.Items.Clear();
                foreach (var komentar in komentarList)
                {
                    listBox1.Items.Add($"[{komentar.Tanggal:HH:mm dd-MM}] {komentar.Username}: {komentar.IsiKomentar}");
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Gagal mengambil komentar dari server: " + ex.Message);
            }
        }

        private async void button1_Click(object sender, EventArgs e)
        {
            string isiKomentar = textBox1.Text.Trim();
            if (string.IsNullOrEmpty(isiKomentar))
            {
                MessageBox.Show("Komentar tidak boleh kosong.");
                return;
            }

            var komentar = new Komentar
            {
                Username = _username,
                IsiKomentar = isiKomentar,
                Tanggal = DateTime.Now
            };

            try
            {
                var response = await _httpClient.PostAsJsonAsync(_apiUrl, komentar);
                if (response.IsSuccessStatusCode)
                {
                    textBox1.Clear();
                    await LoadKomentar(); // Refresh list komentar
                }
                else
                {
                    MessageBox.Show("Gagal mengirim komentar: " + response.StatusCode);
                }

                DialogResult hasil = MessageBox.Show("Kembali ke Menu?", "Selesai", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
                if (hasil == DialogResult.OK)
                {
                    Program.CurrentState = Program.AppState.MENU;
                    this.Close();
                }
            }
            catch (HttpRequestException ex)
            {
                MessageBox.Show("Gagal terhubung ke API: " + ex.Message);
            }
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e) { }
        private void label3_Click(object sender, EventArgs e) { }
        private void label1_Click(object sender, EventArgs e) { }
        private void textBox1_TextChanged(object sender, EventArgs e) { }
        private void button2_Click(object sender, EventArgs e) { }
    }
}
