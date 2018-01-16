using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace todoleaf
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Done { get; set; }
        public TodoItem()
        {
        }
        public TodoItem(string name, string text, int done = 0)
        {
            this.Name = name;
            this.Text = text;
            this.Done = done;
        }
        public override string ToString()
        {
            return "ID" + ID + " Name " + Name + " Text " + Text;
        }
    }
}
