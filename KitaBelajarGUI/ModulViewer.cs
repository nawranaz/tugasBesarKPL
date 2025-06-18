using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TubesKPL_KitaBelajar.Library.Model;
using TubesKPL_KitaBelajar.Library.Services;


namespace KitaBelajarGUI
{
    public partial class ModulViewer: Form
    {
        private List<ModulPembelajaran> semuaModul;
        public ModulViewer()
        {
            InitializeComponent();
            semuaModul = ModulService.LoadData<ModulPembelajaran>("modul.json");
            LoadMapel();
        }

        private void LoadMapel()
        {
            var mapelUnik = semuaModul
                .Select(m => m.MataPelajaran)
                .Distinct()
                .OrderBy(m => m)
                .ToList();

            lstMapel.Items.Clear();
            lstMapel.Items.AddRange(mapelUnik.ToArray());

            lstModul.Items.Clear();
            txtJudul.Clear();
            txtDeskripsi.Clear();
            txtKontenMultiline.Clear();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            var modulForm = new ModulPembelajaranForm();
            modulForm.Show(); // atau modulForm.ShowDialog(); jika ingin modal
        }
        private void lstMapel_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstMapel.SelectedItem == null) return;

            string selectedMapel = lstMapel.SelectedItem.ToString();
            var modulMapel = semuaModul
                .Where(m => m.MataPelajaran == selectedMapel)
                .OrderBy(m => m.Judul)
                .ToList();

            lstModul.Items.Clear();
            lstModul.Items.AddRange(modulMapel.Select(m => m.Judul).ToArray());

            txtJudul.Clear();
            txtDeskripsi.Clear();
            txtKontenMultiline.Clear();
        }

        private void lstModul_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (lstModul.SelectedItem == null) return;

            string judul = lstModul.SelectedItem.ToString();
            var modul = semuaModul.FirstOrDefault(m => m.Judul == judul);

            if (modul != null)
            {
                txtJudul.Text = modul.Judul;
                txtDeskripsi.Text = modul.Deskripsi;
                txtKontenMultiline.Text = modul.Konten;
            }
        }

        private void btnBack_Click(object sender, EventArgs e) { 
            var menu = new Menu();
            menu.Show(this);
        }



    }
}
