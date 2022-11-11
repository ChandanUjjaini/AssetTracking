using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

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
            int Price;
            String? Location;
            String currency;
            decimal LPrice;
            {
                // Input asset data form user
                Type = DataIO.ReadData("Asset Type");
                Type = Char.ToUpper(Type[0]) + Type.Substring(1);//Converting first character to uppercase
                Brand = DataIO.ReadData("Asset Brand");
                Brand = Brand.ToUpper();//Converting uppercase
                Model = DataIO.ReadData("Asset Model");                         
                Location = DataIO.ReadData("Asset Location");
                Location = Char.ToUpper(Location[0]) + Location.Substring(1);//Converting first character to uppercase
                Location = Validation.ChkAbb(Location); //Check for country alias name and code
                currency = DataIO.Ccode2(Location);  //Getting international Currency code              
                DateOnly Date1 = DataIO.ReadDate("Purchase Date");
                PDate = Date1;
                Price = DataIO.ReadNum("Asset Price in USD");//Getting price in USD
                LPrice = DataIO.LocalPrice(currency,Price); //Converting USD price to local cuntry price
                AssetList.Add(new AssetData(Type, Brand, Model, Location, PDate, Price, currency, LPrice));                
            }
        }

        internal static void Output(List<AssetData> AssetList)
        {
            Console.Clear();
            //Menu outline
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");
            Console.WriteLine(String.Format("{0,-10}", "Asset Type".PadRight(12) + "Brand".PadRight(12) + "Model".PadRight(12)
                  + "Location".PadRight(24) + "Purchase Date".PadRight(20) + "Price (USD)".PadRight(12) + "Currency".PadRight(12) + "Local Price" ));
            Console.WriteLine("---------------------------------------------------------------------------------------------------------------------");            
            foreach (AssetData Asset in AssetList)
            {
                var y = DateTime.Now.Year - Asset.PDate.Year;
                var m = DateTime.Now.Month - Asset.PDate.Month;
                var TM = m + (y * 12);// Checking for asset expirt date

                if (TM > 36)//Expired asset

                {
                    Console.ForegroundColor = ConsoleColor.Blue;
                    CommonOp.PrintData(Asset.Type, Asset.Brand, Asset.Model, Asset.Location, Asset.PDate, Asset.Price, Asset.Currency, Asset.Loprice);
                    Console.ResetColor();
                }

                else if (TM>=33 && TM >= 36)//6 months to expire

                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    CommonOp.PrintData(Asset.Type, Asset.Brand, Asset.Model, Asset.Location, Asset.PDate, Asset.Price,Asset.Currency,Asset.Loprice);                    
                    Console.ResetColor();                     
                }

                else if (TM>=30 && TM <33)//3 months to expire

                {
                    Console.ForegroundColor = ConsoleColor.Yellow;
                    CommonOp.PrintData(Asset.Type, Asset.Brand, Asset.Model, Asset.Location, Asset.PDate, Asset.Price, Asset.Currency, Asset.Loprice);
                    Console.ResetColor();
                }
                else
                {
                    CommonOp.PrintData(Asset.Type, Asset.Brand, Asset.Model, Asset.Location, Asset.PDate, Asset.Price, Asset.Currency, Asset.Loprice);
                }

            }
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Asset Expired >");
            Console.ForegroundColor = ConsoleColor.Red;
            Console.Write("3 monts for Asset to Expired >");
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.WriteLine("6 monts for Asset to Expired >");
            Console.ResetColor();
            Console.WriteLine("--------------------------------------------------------------------------------------------------------------------");

        }



        internal static void SortList(List<AssetData> AssetList)
        {
            Console.WriteLine("*****************************************");
            Console.WriteLine("* Please Enter your sort type *");
            Console.WriteLine("*****************************************");
            Console.WriteLine("* Sort by Type\t\t- 1\t\t*\n* Sort by Brand\t\t- 2\t\t*\n* Sort by Date\t\t- 3\t\t*\n* Sort by Price\t\t- 4\t\t*\n* Sort by Location\t- 5\t\t*");
            Console.WriteLine("*****************************************");
            int SortIn = DataIO.Selchk("Sort Type", 5);

            int SorSel = Convert.ToInt32(SortIn);

            switch (SorSel)
            {
                case 1:
                    {
                        //Sort by Type
                        List<AssetData> SortType = AssetList.OrderBy(AssetList => AssetList.Type).ToList();
                        Output(SortType);
                        break;
                    }
                case 2:
                    {
                        //Sort by Brand
                        List<AssetData> SortType = AssetList.OrderBy(AssetList => AssetList.Brand).ToList();
                        Output(SortType);
                        break;
                    }
                case 3:
                    {
                        //Sort by Purchase Date
                        List<AssetData> SortType = AssetList.OrderBy(AssetList => AssetList.PDate).ToList();
                        Output(SortType);
                        break;
                    }
                case 4:
                    {
                        //Sort by price
                        List<AssetData> SortType = AssetList.OrderBy(AssetList => AssetList.Price).ToList();
                        Output(SortType);
                        break;
                    }
                case 5:
                    {
                        //Sort by asset Location
                        List<AssetData> SortType = AssetList.OrderBy(AssetList => AssetList.Location).ToList();
                        Output(SortType);
                        break;
                    }
            }             
        }        
        internal static string Ccode2(String name)
        {
            //This method is used to extract internation currency code(USD,SEK,INR...)
            //County data from Culter info and Region info is used to extract currency code.
            String Code = null;

            CultureInfo[] cultures = CultureInfo.GetCultures(CultureTypes.SpecificCultures);
            List<RegionInfo> countries = new List<RegionInfo>();
            foreach (CultureInfo ci in cultures)
            {
                RegionInfo regionInfo = new RegionInfo(ci.Name);
                if (countries.Count(x => x.EnglishName == regionInfo.EnglishName) <= 0)
                    countries.Add(regionInfo);
            }
            foreach (RegionInfo regionInfo in countries.OrderBy(x => x.EnglishName))
            {
                //Console.WriteLine(regionInfo.EnglishName + "   " + regionInfo.ISOCurrencySymbol);
                if (name == regionInfo.EnglishName)
                    Code = regionInfo.ISOCurrencySymbol;
            }
                return Code;
        }
    }
}
