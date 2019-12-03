using System;
using System.Collections.Generic;
using System.Text;
using SQLite;

namespace CheApp
{
    public interface IDatabaseConnection
    {
        SQLiteConnection DbConnection();
    }
}
