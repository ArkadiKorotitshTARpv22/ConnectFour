// DatabaseService.cs
using SQLite;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ConnectFour
{
    public class DatabaseService
    {
        private readonly SQLiteAsyncConnection _database;

        public DatabaseService()
        {
            
            try
            {
                SQLitePCL.Batteries_V2.Init();  // Initialize SQLite
                var databasePath = Path.Combine(FileSystem.AppDataDirectory, "colors.db");
                _database = new SQLiteAsyncConnection(databasePath);
                _database.CreateTableAsync<ColorItem>().Wait();
                // Initialize default colors
                InitializeDefaultColors().Wait();
            }
            catch (Exception ex)
            {
                // Handle exception (e.g., log the error)
                Console.WriteLine($"Database initialization error: {ex.Message}");
                throw;

            }
        }
        
        public Task<List<ColorItem>> GetColorsAsync()
        {
            return _database.Table<ColorItem>().ToListAsync();
        }

        public Task<int> SaveColorAsync(ColorItem color)
        {
            return _database.InsertAsync(color);
        }
        public async Task InitializeDefaultColors()
        {
            
                await SaveColorAsync(new ColorItem { ColorName = "Red", ColorHex = "#FF0000" });
            
        }

    }
}

