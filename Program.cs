using Microsoft.Data.Sqlite;
namespace App
{
    class Program
    {
        static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder();
            var app = builder.Build();
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.Run();
            using (var connection = new SqliteConnection("Data Source=MusicCatalogDB.db"))
            {
                connection.Open();
            }
            Console.Read();
        }
    }
}
