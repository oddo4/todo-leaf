using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace todoleaf
{
    public class Category
    {
        [PrimaryKey, AutoIncrement]
        public int ID { get; set; }
        public string Name { get; set; }
        public Category()
        {

        }
        public Category(string name)
        {
            this.Name = name;
        }
    }
}
