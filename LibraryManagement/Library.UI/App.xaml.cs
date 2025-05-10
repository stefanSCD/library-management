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

            string dbPath = @"C:\Users\x\Desktop\proiect internship\LibraryManagement\LibraryManagement\Library.Repository\Database";
            AppDomain.CurrentDomain.SetData("DataDirectory", dbPath);

            app.InitializeComponent();

            app.Properties["LibraryConnectionString"] = DatabaseHelper.ConnectionString;

            var mainWindow = new LibraryManagement.MainWin();
            app.Run();
        }

        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
        }
    }
}