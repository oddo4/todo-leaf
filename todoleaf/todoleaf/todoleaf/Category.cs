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
        public bool Sort { get; set; }
        public Category()
        {

        }
        public Category(string name, bool sort = true)
        {
            this.Name = name;
            this.Sort = sort;
        }
    }
}
