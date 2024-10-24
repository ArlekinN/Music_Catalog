using Microsoft.Data.Sqlite;
using Microsoft.EntityFrameworkCore;

namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder();
            using (var connection = new SqliteConnection("Data Source=MusicCatalogDB.db"))
            {
                connection.Open();
                //// CREATION TABLES
                //SqliteCommand command = new SqliteCommand();
                //command.Connection = connection;
                //command.CommandText = "CREATE TABLE Artists(ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Name TEXT NOT NULL)";
                //command.ExecuteNonQuery();
                //command.CommandText = "CREATE TABLE Genres(ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, Title TEXT NOT NULL)";
                //command.ExecuteNonQuery();
                //command.CommandText = "CREATE TABLE Albums(ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                //    "Title TEXT NOT NULL," +
                //    "YearRelease INREGER NOT NULL, " +
                //    "id_Genre INREGER NOT NULL, " +
                //    "id_Artist INREGER NOT NULL, " +
                //    "FOREIGN KEY (id_Genre)  REFERENCES Genres (ID)," +
                //    "FOREIGN KEY (id_Artist)  REFERENCES Artists (ID))";
                //command.ExecuteNonQuery();
                //command.CommandText = "CREATE TABLE Collections(ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                //    "Title TEXT NOT NULL," +
                //    "TypeCollection TEXT NOT NULL, " +
                //    "YearRelease INREGER," +
                //    "id_Genre INTEGER," +
                //    "FOREIGN KEY (id_Genre)  REFERENCES Genres (ID))";
                //command.ExecuteNonQuery();
                //command.CommandText = "CREATE TABLE Songs(ID INTEGER NOT NULL PRIMARY KEY AUTOINCREMENT UNIQUE, " +
                //    "Title TEXT NOT NULL," +
                //    "id_Artist INREGER NOT NULL, " +
                //    "id_Album INREGER NOT NULL, " +
                //    "Duration FLOAT NOT NULL, " +
                //    "YearRelease INREGER NOT NULL," +
                //    "id_Genre INREGER NOT NULL," +
                //    "FOREIGN KEY (id_Genre)  REFERENCES Genres (ID)," +
                //    "FOREIGN KEY (id_Artist)  REFERENCES Artists (ID)," +
                //    "FOREIGN KEY (id_Album)  REFERENCES Albums (ID))";
                //command.ExecuteNonQuery();

            }
            
            var app = builder.Build();

            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.Run();
            
           
        }
    }
}
