using SQLite;
using System;
using System.Collections.Generic;
using System.Text;

namespace InventoryApplication.Models
{
    public  class Record
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Producer { get; set; }
        public string Model { get; set; }
        public string Ram { get; set; }
        public string Hdd { get; set; }
        public string Ssd { get; set; }
    }
}
