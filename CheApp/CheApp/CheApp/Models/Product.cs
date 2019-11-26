using System;
using System.Collections.Generic;
using System.Text;

namespace CheApp.Models
{
    public class Product
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public double Price { get; set; }
        public int CategoryID { get; set; }
        public int MarketID { get; set; }
    }
}
