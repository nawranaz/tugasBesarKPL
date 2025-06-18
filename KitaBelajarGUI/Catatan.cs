using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text.Json;
using System.Windows.Forms;
using TubesKPL_KitaBelajar.Library.Model;
 

namespace CatatanGUI
{
    public partial class Form1 : Form
    {
        private List<Catatan> daftarCatatan = new();
        private string folderData = "Data/Catatan";
        private string indexFile = "Data/index.json";

        public Form1()
        {
            InitializeComponent();
            Directory.CreateDirectory(folderData);
            LoadCatatan();
        }

        private void LoadCatatan()
        {
            if (!File.Exists(indexFile)) return;

            var json = File.ReadAllText(indexFile);
            daftarCatatan = JsonSerializer.Deserialize<List<Catatan>>(json);
            lstCatatan.Items.Clear();

            foreach (var c in daftarCatatan)
            {
                lstCatatan.Items.Add(c.Judul);
            }
        }

        private void btnTambah_Click(object sender, EventArgs e)
        {
            var judul = txtJudul.Text.Trim();
            var isi = txtIsi.Text.Trim();

            if (judul.Length < 3 || isi.Length < 5)
            {
                MessageBox.Show("Judul minimal 3 karakter dan isi minimal 5 karakter.");
                return;
            }

            var filePath = Path.Combine(folderData, $"{judul}.json");

            var catatan = new Catatan
            {
                Judul = judul,
                Isi = isi,
                Tanggal = DateTime.Now,
                FilePath = filePath
            };

            var json = JsonSerializer.Serialize(catatan, new JsonSerializerOptions { WriteIndented = true });
            File.WriteAllText(filePath, json);

            daftarCatatan.Add(catatan);
            File.WriteAllText(indexFile, JsonSerializer.Serialize(daftarCatatan, new JsonSerializerOptions { WriteIndented = true }));

            lstCatatan.Items.Add(judul);
            txtJudul.Clear();
            txtIsi.Clear();
        }

        private void lstCatatan_SelectedIndexChanged(object sender, EventArgs e)
        {
            var judul = lstCatatan.SelectedItem?.ToString();
            if (judul == null) return;

            var catatan = daftarCatatan.FirstOrDefault(c => c.Judul == judul);
            if (catatan != null)
            {
                lblDetail.Text = $"Judul: {catatan.Judul}\nTanggal: {catatan.Tanggal:dd/MM/yyyy}\n\n{catatan.Isi}";
            }
        }

        private void btnKembali_Click(object sender, EventArgs e)
        {
            
            this.Close();
        }

    }
}