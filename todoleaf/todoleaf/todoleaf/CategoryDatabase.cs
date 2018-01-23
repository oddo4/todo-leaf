using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace todoleaf
{
    public class CategoryDatabase
    {
        private SQLiteAsyncConnection database;

        public CategoryDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<Category>().Wait();
        }
        public Task<List<Category>> GetAllAsync()
        {
            return database.Table<Category>().ToListAsync();
        }
        public Task<int> SaveItemAsync(Category saveItem)
        {
            foreach (Category item in GetAllAsync().Result)
            {
                if (item.ID == saveItem.ID)
                {
                    return database.UpdateAsync(saveItem);
                }
            }
            return database.InsertAsync(saveItem);
        }
        public Task<List<Category>> DeleteItemAsync(Category saveItem)
        {
            return database.QueryAsync<Category>("DELETE FROM [Category] WHERE [ID] = '" + saveItem.ID + "'");
        }
        public Task<List<Category>> DeleteAllAsync()
        {
            return database.QueryAsync<Category>("DELETE FROM [Category]");
        }
    }
}

