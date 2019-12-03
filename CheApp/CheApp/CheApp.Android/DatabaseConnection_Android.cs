using SQLite;
using CheApp.Droid;
using System.IO;

[assembly: Xamarin.Forms.Dependency(typeof(DatabaseConnection_Android))]
namespace CheApp.Droid
{
    public class DatabaseConnection_Android : IDatabaseConnection
    {
        public SQLiteConnection DbConnection()
        {
            var dbName = "CheAppDB_2_1.db3";
            var path = Path.Combine(System.Environment.
            GetFolderPath(System.Environment.
            SpecialFolder.Personal), dbName);
            return new SQLiteConnection(path);
        }
    }
}