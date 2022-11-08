using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking
{
    internal class AssetData
    {
        public AssetData(string type, string brand, string model, string date, string price, string location, string currency)
        {
            Type = type;
            Brand = brand;
            Model = model;
            
            Date = date;
            Price = price;
            Location = location;
            Currency = currency;
        }

        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Location { get; set; }
        public string Date { get; set; }
        public string Price { get; set; }
        public string Currency { get; set; }

    }
}
