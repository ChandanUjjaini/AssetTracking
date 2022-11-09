using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking
{
    public class AssetOp
    {
        internal static void Input(List<AssetData> AssetList)
        {
            String Type; // Declaring variables for passing arguments
            String Brand;
            String Model;
            DateOnly PDate;
            String Price;
            String? Location;
            String currency;
            {
                // Input asset data form user
                Type = DataIn.ReadData("Asset Type");
                Type = Char.ToUpper(Type[0]) + Type.Substring(1);//Converting first character to uppercase
                Brand = DataIn.ReadData("Asset Brand");
                Brand = Char.ToUpper(Brand[0]) + Brand.Substring(1);//Converting first character to uppercase
                Model = DataIn.ReadData("Asset Model");
                         
                Location = DataIn.ReadData("AssetLocation");
                Location = Char.ToUpper(Location[0]) + Location.Substring(1);//Converting first character to uppercase
                currency = DataIn.ReadData("currency").ToUpper();
                Price = DataIn.Numchk("Asset Price");
                DateOnly Date1 = DataIn.Datechk("Purchase Date");
                PDate = Date1;



                AssetList.Add(new AssetData(Type, Brand, Model, Location, currency, Price, PDate));
                
            }

        }

        internal static void Output(List<AssetData> AssetList)
        {
            Console.Clear();
            Console.WriteLine("------------------------------------------------------------------------------------------");
            Console.WriteLine("Asset Type".PadRight(12) + "Brand".PadRight(12) + "Model".PadRight(12)
                  + "Location".PadRight(12) + "Currency".PadRight(12) + "Price".PadRight(12) + "Purchase Date");
            Console.WriteLine("------------------------------------------------------------------------------------------");

            foreach (AssetData Asset in AssetList)
            {
                Console.WriteLine(Asset.Type.PadRight(12) + Asset.Brand.PadRight(12) + Asset.Model.PadRight(12)
                 + Asset.Location.PadRight(12) + Asset.Currency.PadRight(12) + Asset.Price.PadRight(12) + Asset.PDate);
            }
            Console.WriteLine("------------------------------------------------------------------------------------------");

        }

        internal static void SortList(List<AssetData> AssetList)
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("* Please Enter your sort type *");
            Console.WriteLine("*****************************************");
            Console.WriteLine("* Sort by Type\t\t- 1\t\t*\n* Sort by Brand\t\t- 2\t\t*\n* Sort by Date\t\t- 3\t\t*\n* Sort by Price\t\t- 4\t\t*\n* Sort by Location\t- 5\t\t*");
            Console.WriteLine("*****************************************");
            string SortIn = DataIn.Selchk("Sort Type", 5);

            int SorSel = Convert.ToInt32(SortIn);

            switch (SorSel)
            {
                case 1:
                    {
                        List<AssetData> SortType = AssetList.OrderBy(AssetList => AssetList.Type).ToList();
                        Output(SortType);
                        break;
                    }
                case 2:
                    {
                        List<AssetData> SortType = AssetList.OrderBy(AssetList => AssetList.Brand).ToList();
                        Output(SortType);
                        break;
                    }
                case 3:
                    {
                        List<AssetData> SortType = AssetList.OrderBy(AssetList => AssetList.PDate).ToList();
                        Output(SortType);
                        break;
                    }
                case 4:
                    {
                        List<AssetData> SortType = AssetList.OrderBy(AssetList => AssetList.Price).ToList();
                        Output(SortType);
                        break;
                    }
                case 5:
                    {
                        List<AssetData> SortType = AssetList.OrderBy(AssetList => AssetList.Location).ToList();
                        Output(SortType);
                        break;
                    }
            }

            

            

        }
    }
}
