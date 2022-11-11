using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking
{
    internal class AssetData
    {
        public AssetData(string type, string brand, string model, string location, DateOnly pdate, int price, string currency, decimal loprice)
        {
            Type = type;
            Brand = brand;
            Model = model;
            PDate = pdate;
            Price = price;
            Location = location;
            Currency = currency;
            Loprice = loprice;
        }

        public string Type { get; set; }
        public string Brand { get; set; }
        public string Model { get; set; }
        public string Location { get; set; }
        public DateOnly PDate { get; set; }
        public int Price { get; set; }
        public string Currency { get; set; }
        public decimal Loprice { get; set; }

    }
}
