using LibraryManagement.Library;
using LibraryManagement.Library.Repository.Database;
using System;
using System.Windows;

namespace LibraryManagement
{
    public partial class App : Application
    {
        [System.STAThread]
        public static void Main()
        {
            var app = new App();

            // Setează DataDirectory ÎNAINTE de InitializeComponent
            string dbPath = @"C:\Users\x\Desktop\proiect internship\LibraryManagement\LibraryManagement\Library.Repository\Database";
            AppDomain.CurrentDomain.SetData("DataDirectory", dbPath);

            app.InitializeComponent();

            // Setează connection string în Settings
            app.Properties["LibraryConnectionString"] = DatabaseHelper.ConnectionString;

            // Creează și afișează fereastra principală
            var mainWindow = new LibraryManagement.MainWin();
            app.Run(); // Adaugă mainWindow ca parametru
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            // Poți să ștergi SetupDataDirectory() dacă nu o mai folosești
            base.OnStartup(e);
        }
    }
}