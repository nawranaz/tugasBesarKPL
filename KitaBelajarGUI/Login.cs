using TubesKPL_KitaBelajar.Library.Services;
using TubesKPL_KitaBelajar;
using TubesKPL_KitaBelajar.Library.Model;

namespace KitaBelajarGUI
{
    public partial class Login : Form
    {
        // Konstruktor form login
        public Login()
        {
            InitializeComponent();
        }

        // Event handler saat tombol "Masuk" ditekan
        private void TombolMasuk_Click(object sender, EventArgs e)
        {
            // Ambil input dari TextBox dan buang spasi berlebih
            string username = textBox1.Text.Trim();
            string password = textBox2.Text.Trim();

            // Validasi input tidak boleh kosong
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                hasilLogin.Text = "Username dan password harus diisi!";
                hasilLogin.Visible = true;
                return;
            }

            // Buat objek user berdasarkan input
            var user = new User { Username = username, Password = password };

            // Buat instance AuthService (pengecekan login)
            var authService = new AuthService();

            try
            {
                // Coba login melalui AuthService
                if (authService.Login(user))
                {
                    // Login berhasil
                    Program.LoggedInUser = user; // Simpan user yang login
                    hasilLogin.Visible = false;

                    // Pindah state ke MENU
                    Program.CurrentState = Program.AppState.MENU;
                    this.Close(); // Tutup form login
                }
                else
                {
                    // Jika gagal login, tampilkan pesan kesalahan
                    hasilLogin.Text = "Username atau password salah!";
                    hasilLogin.Visible = true;
                }
            }
            catch (Exception ex)
            {
                // Tangani error tidak terduga (misal koneksi API atau file JSON corrupt)
                hasilLogin.Text = $"Error: {ex.Message}";
                hasilLogin.Visible = true;
            }
        }
    }
}
