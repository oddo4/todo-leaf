using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace todoleaf
{
    public class TodoItemDatabase
    {
        private SQLiteAsyncConnection database;

        public TodoItemDatabase(string dbPath)
        {
            database = new SQLiteAsyncConnection(dbPath);
            database.CreateTableAsync<TodoItem>().Wait();
        }
        public Task<List<TodoItem>> GetItemsAsync(string name)
        {
            return database.QueryAsync<TodoItem>("SELECT * FROM [TodoItem] WHERE [Name] = '" + name + "'");
        }
        public Task<List<TodoItem>> GetAllAsync()
        {
            return database.Table<TodoItem>().ToListAsync();
        }
        public Task<int> SaveItemAsync(TodoItem saveItem)
        {
            foreach (TodoItem item in GetItemsAsync(saveItem.Name).Result)
            {
                if (item.ID == saveItem.ID)
                {
                    return database.UpdateAsync(saveItem);
                }
            }
            return database.InsertAsync(saveItem);
        }
        public Task<List<TodoItem>> DeleteItemAsync(TodoItem saveItem)
        {
            return database.QueryAsync<TodoItem>("DELETE FROM [TodoItem] WHERE [ID] = '" + saveItem.ID + "'");
        }
        public Task<List<TodoItem>> DeleteAllAsync()
        {
            return database.QueryAsync<TodoItem>("DELETE FROM [TodoItem]");
        }
    }
}
