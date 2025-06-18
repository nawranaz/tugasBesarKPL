using System;
using System.Diagnostics;
using System.Windows.Forms;
using KitaBelajarGUI;
using TubesKPL_KitaBelajar.Library.Model;

namespace TubesKPL_KitaBelajar
{
    static class Program
    {
        // Enum untuk mendefinisikan semua state aplikasi secara eksplisit
        public enum AppState
        {
            LOGIN,
            MENU,
            LATIHAN_SOAL,
            MODUL,
            VIDEO,
            PENGINGAT,
            FORUM,
            CATATAN,
            EXIT
        }

        // State global yang menyimpan state aplikasi saat ini
        public static AppState CurrentState = AppState.LOGIN;

        // Menyimpan user yang sedang login (jika sudah login)
        public static Library.Model.User LoggedInUser;

        [STAThread]
        static void Main()
        {
            // Inisialisasi konfigurasi Windows Forms (scaling, DPI, dll)
            ApplicationConfiguration.Initialize();

            // Loop utama state machine berbasis form GUI
            while (CurrentState != AppState.EXIT)
            {
                // Gunakan switch-case untuk mengatur transisi antar form berdasarkan AppState
                switch (CurrentState)
                {
                    case AppState.LOGIN:
                        Application.Run(new Login());
                        break;

                    case AppState.MENU:
                        Application.Run(new Menu());
                        break;

                    case AppState.LATIHAN_SOAL:
                        Application.Run(new LatihanSoal());
                        break;
                    case AppState.MODUL:
                        Application.Run(new ModulViewer());
                        break;
                    case 
                        AppState.FORUM:
                        Application.Run(new ForumDiskusi(Program.LoggedInUser.Username));
                        break;
                    case 
                        AppState.PENGINGAT:
                        Application.Run(new NotifikasiPengingat());
                        break;
                    case
                        AppState.VIDEO:
                        Application.Run(new FormVidIPA());
                        break;

                    case AppState.CATATAN:
                        Application.Run(new CatatanGUI.Form1());
                        break;



                    // Bisa ditambahkan case-case lain sesuai kebutuhan modul:
                    // case AppState.MODUL: Application.Run(new ModulForm()); break;
                    // case AppState.FORUM: Application.Run(new ForumForm()); break;

                    default:
                        // Jika state tidak dikenali, keluar secara aman
                        CurrentState = AppState.EXIT;
                        break;
                }

                // Validasi bahwa CurrentState masih dalam range enum
                Debug.Assert(Enum.IsDefined(typeof(AppState), CurrentState), "State tidak valid!");
            }
        }
    }
}
