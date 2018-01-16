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
        public Task<List<TodoItem>> GetItemsAsync()
        {
            return database.Table<TodoItem>().ToListAsync();
        }
        public Task<int> SaveItemAsync(TodoItem item)
        {
            return database.InsertAsync(item);
        }
        public Task<List<TodoItem>> DeleteAllAsync()
        {
            return database.QueryAsync<TodoItem>("DELETE * FROM [TodoItem]");
        }
    }
}
