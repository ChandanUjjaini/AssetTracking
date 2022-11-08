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
            String Date;
            String Price;
            String? Location;
            String currency;
            {
                
                Type = DataIn.ReadData("Type");
                Brand = DataIn.ReadData("Brand");
                Model = DataIn.ReadData("Model");
                Date = DataIn.ReadData("Date");
                Price = DataIn.Numchk("Price");
                Location = DataIn.ReadData("Location");
                currency = DataIn.ReadData("currency");
                currency = currency.ToUpper();


                //repeatBrand:
                //    Console.Write("Please Enter Asset Brand:");
                //    Brand = Console.ReadLine(); // Asset Brand
                //    if ((DataIn.EmptyNull(Brand) == true))
                //    {
                //        goto repeatBrand;
                //    }
                //repeaType:
                //    Console.Write("Please Enter Asset Type:");
                //    Type = Console.ReadLine(); // Asset Type

                //    if ((DataIn.EmptyNull(Type) == true))
                //    {
                //        goto repeaType;
                //    }

                //repeatModel:
                //    Console.Write("Please Enter Asset Model:");// Asset Model
                //    Model = Console.ReadLine();

                //    if ((DataIn.EmptyNull(Model) == true))
                //    {
                //        goto repeatModel;
                //    }



                //repeatDate:
                //    Console.Write("Please Enter Purchase Date:");// Asset Model
                //    Date = Console.ReadLine();
                //    if (String.IsNullOrEmpty(Date))
                //    {
                //        goto repeatDate;
                //    }

                //repeatPrice:
                //    Console.Write("Please Enter Purchase Price:");// Asset Model
                //     Price = Console.ReadLine();
                //    //Checking if the input value is number
                //    if (DataIn.NumChk(Price) == true) 
                //    {

                //        goto repeatDate;
                //    }

                //repeatLocation:
                //    Console.Write("Please Enter Office Location:");// Asset Model
                //    Location = Console.ReadLine();
                //    if (DataIn.NumChk(Price) == true)
                //    {

                //        goto repeatLocation;
                //    }

                //repeatcurrency:
                //    Console.Write("Please Enter Currency:");// Asset Model
                //    currency = Console.ReadLine();
                //    if (DataIn.NumChk(Price) == true)
                //    {

                //        goto repeatcurrency;
                //    }

                AssetList.Add(new AssetData(Type, Brand, Model, Date, Price, Location, currency));
                
            }

        }

        internal static void Output(List<AssetData> AssetList)
        {
            Console.WriteLine("----------------------------------------------------------------------------");
            Console.WriteLine("Asset Type".PadRight(10) + "Brand".PadRight(10) + "Model".PadRight(10)
                + "Purchase Date".PadRight(15) + "Price".PadRight(10) + "Location".PadRight(10) + "Currency");
            Console.WriteLine("----------------------------------------------------------------------------");

            foreach (AssetData Asset in AssetList)
            {
                Console.WriteLine(Asset.Type.PadRight(10) + Asset.Brand.PadRight(10) + Asset.Model.PadRight(10)
                + Asset.Date.PadRight(15) + Asset.Price.PadRight(10) + Asset.Location.PadRight(10) + Asset.Currency);
            }
            Console.WriteLine("----------------------------------------------------------------------------");

        }
    }
}
