using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LibraryManagement.Library.Repository.Database
{
    public static class DatabaseHelper
    {
        private static string _connectionString;
        private static readonly object _lock = new object();
        private static bool _isInitialized = false;

        public static string ConnectionString
        {
            get
            {
                if (!_isInitialized)
                {
                    Initialize();
                }
                return _connectionString;
            }
        }

        private static void Initialize()
        {
            lock (_lock)
            {
                if (!_isInitialized)
                {
                    SetupConnectionString();
                    _isInitialized = true;
                }
            }
        }

        private static void SetupConnectionString()
        {
            try
            {
                string fullPath = GetDatabasePath();
                Console.WriteLine($"Baza de date găsită la: {fullPath}");

                DetachDatabaseIfAttached();

                _connectionString = $@"Data Source=(LocalDB)\MSSQLLocalDB;AttachDbFilename={fullPath};Integrated Security=True;Connect Timeout=30;";

                var dataDir = Path.GetDirectoryName(fullPath);
                AppDomain.CurrentDomain.SetData("DataDirectory", dataDir);
            }
            catch (Exception ex)
            {
                throw new Exception($"Eroare la configurarea conexiunii: {ex.Message}", ex);
            }
        }

        // Restul metodelor (DetachDatabaseIfAttached, GetDatabasePath) rămân la fel
        private static void DetachDatabaseIfAttached()
        {
            using (var connection = new SqlConnection(@"Data Source=(LocalDB)\MSSQLLocalDB;Integrated Security=True"))
            {
                try
                {
                    connection.Open();

                    // Închide toate conexiunile active către LibraryDB
                    var killConnectionsCmd = new SqlCommand(@"
                IF DB_ID('LibraryDB') IS NOT NULL
                BEGIN
                    ALTER DATABASE [LibraryDB] SET SINGLE_USER WITH ROLLBACK IMMEDIATE
                END", connection);

                    killConnectionsCmd.ExecuteNonQuery();

                    // Detașează baza de date
                    var detachCmd = new SqlCommand(@"
                IF DB_ID('LibraryDB') IS NOT NULL
                BEGIN
                    EXEC sp_detach_db 'LibraryDB'
                END", connection);

                    detachCmd.ExecuteNonQuery();
                }
                catch (Exception ex)
                {
                    // Log eroarea dar continuă - poate baza de date nu era atașată
                    Console.WriteLine($"Notă la detașare: {ex.Message}");
                }
            }
        }


        private static string GetDatabasePath() {
            // Pornește de la directorul unde rulează aplicația
            string currentDir = AppDomain.CurrentDomain.BaseDirectory;

            // Caută în sus în structura de directoare până găsești Library.Repository
            while (currentDir != null)
            {
                var libraryRepoPath = Path.Combine(currentDir, "Library.Repository", "Database", "LibraryDB.mdf");
                if (File.Exists(libraryRepoPath))
                {
                    return libraryRepoPath;
                }

                // Caută și direct în Database
                var databasePath = Path.Combine(currentDir, "Database", "LibraryDB.mdf");
                if (File.Exists(databasePath))
                {
                    return databasePath;
                }

                currentDir = Directory.GetParent(currentDir)?.FullName;
            }

            throw new FileNotFoundException("Nu s-a putut găsi LibraryDB.mdf");
        }
    }
}
