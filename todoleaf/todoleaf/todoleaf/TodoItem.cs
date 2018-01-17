using SQLite;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace todoleaf
{
    public class TodoItem
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public string Text { get; set; }
        public int Done { get; set; }
        public string TickIcon { get; set; }
        public TodoItem()
        {
        }
        public TodoItem(string name, string text, int done = 0)
        {
            this.Name = name;
            this.Text = text;
            this.Done = done;
            SetTickIcon();
        }
        public void SetTickIcon()
        {
            switch (Done)
            {
                case 0:
                    TickIcon = "tick0.png";
                    break;
                case 1:
                    TickIcon = "tick1.png";
                    break;
                default:
                    break;
            }
        }
        public override string ToString()
        {
            return "ID" + ID + " Name " + Name + " Text " + Text;
        }
    }
}
