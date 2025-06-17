using TubesKPL_KitaBelajar;
using TubesKPL_KitaBelajar.Library.Model;
using TubesKPL_KitaBelajar.Library.Services;

namespace KitaBelajarGUI
{
    public partial class Login : Form
    {
        // Konstruktor Form Login
        public Login()
        {
            InitializeComponent();
        }

        // Event handler untuk tombol "Masuk"
        private void ButtonLogin_Click(object sender, EventArgs e)
        {
            // Ambil dan bersihkan input username dan password
            string username = textBoxUsername.Text.Trim();
            string password = textBoxPassword.Text.Trim();

            // Validasi input tidak boleh kosong
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                labelLoginResult.Text = "Username dan password harus diisi!";
                labelLoginResult.Visible = true;
                return;
            }

            // Buat objek user dari input pengguna
            var user = new User
            {
                Username = username,
                Password = password
            };

            // Inisialisasi service autentikasi
            var authService = new AuthService();

            try
            {
                // Proses autentikasi login
                if (authService.Login(user))
                {
                    // Jika berhasil, simpan user ke program utama
                    Program.LoggedInUser = user;

                    // Pindah ke state MENU aplikasi
                    Program.CurrentState = Program.AppState.MENU;

                    labelLoginResult.Visible = false;
                    Close(); // Tutup form login
                }
                else
                {
                    // Jika gagal login, tampilkan pesan kesalahan
                    labelLoginResult.Text = "Username atau password salah!";
                    labelLoginResult.Visible = true;
                }
            }
            catch (Exception ex)
            {
                // Tangani exception tak terduga, tampilkan pesan error
                labelLoginResult.Text = $"Error: {ex.Message}";
                labelLoginResult.Visible = true;
            }
        }
    }
}
