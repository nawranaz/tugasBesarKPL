using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TubesKPL_KitaBelajar.Library.Services;
using TubesKPL_KitaBelajar.Library.Model;

namespace KitaBelajarGUI
{
    public partial class ModulPembelajaranForm : Form
    {
        private List<ModulPembelajaran> semuaModul;

        public ModulPembelajaranForm()
        {
            InitializeComponent();
            semuaModul = ModulService.LoadData<ModulPembelajaran>("modul.json");
            LoadMapelKeComboBox();
        }

        private void LoadMapelKeComboBox()
        {
            var mapel = semuaModul.Select(m => m.MataPelajaran).Distinct().ToList();
            cmbMapel.Items.AddRange(mapel.ToArray());
        }

        private void btnCari_Click(object sender, EventArgs e)
        {
            string keyword = txtKeyword.Text.Trim();
            if (string.IsNullOrWhiteSpace(keyword) || keyword.Length < 3)
            {
                lblStatus.Text = "Kata kunci minimal 3 karakter.";
                return;
            }

            var hasil = ModulSearchService.CariModul(semuaModul, keyword);
            lstModul.Items.Clear();
            foreach (var modul in hasil)
            {
                lstModul.Items.Add(modul.Judul);
            }

            lblStatus.Text = $"{hasil.Count} modul ditemukan.";
        }

        private void cmbMapel_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedMapel = cmbMapel.SelectedItem.ToString();
            var modulTerkait = semuaModul.Where(m => m.MataPelajaran == selectedMapel).ToList();

            lstModul.Items.Clear();
            foreach (var modul in modulTerkait)
            {
                lstModul.Items.Add(modul.Judul);
            }

            lblStatus.Text = $"Menampilkan modul: {selectedMapel}";
        }

        private void lstModul_SelectedIndexChanged(object sender, EventArgs e)
        {
            string judul = lstModul.SelectedItem?.ToString();
            var modul = semuaModul.FirstOrDefault(m => m.Judul == judul);
            if (modul != null)
            {
                txtKonten.Text = $"Judul: {modul.Judul}\n\nDeskripsi: {modul.Deskripsi}\n\nKonten:\n{modul.Konten}";
            }
        }
    }
}
