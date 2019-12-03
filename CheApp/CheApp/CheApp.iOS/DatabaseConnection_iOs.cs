using CheApp.iOS;
using SQLite;
using System;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_iOS))]
namespace CheApp.iOS
{
    public class DatabaseConnection_iOS
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "CheAppDB_2_1.db3";
            string personalFolder =
            Environment.
            GetFolderPath(Environment.SpecialFolder.Personal);
            string libraryFolder =
            Path.Combine(personalFolder, "..", "Library");
            var path = Path.Combine(libraryFolder, dbName);
            return new SQLiteConnection(path);
        }
    }
}