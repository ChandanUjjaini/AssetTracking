using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking
{
    public class CommonOp
    {
        internal static void ErrorMessage(String data) // Common code to display error message
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"Please Enter Valid {data}");// Error Message
            Console.ResetColor();
        }

        public static string ReadData(String read) // Common code to read data from console
        {
            Console.Write($"Please Enter {read}: ");
            String Data = Console.ReadLine();
            Data = Data.Trim();
            return Data;
        }

        // Common code to print data to console
        public static void PrintData(string Type, string Brand, string Model, string Location, DateOnly PDate, int Price, string Currency, decimal Lprice)
        {
            Console.WriteLine(String.Format("{0,-10}", Type.PadRight(12) + Brand.PadRight(12) + Model.PadRight(12)
                    + Location.PadRight(24) + PDate.ToString().PadRight(20) + Price.ToString().PadRight(12)
                    + Currency.PadRight(12) + Lprice ));
        }

        public static string ExRate(string code) //Method to get exchange rate from Google Finance
        {
            string data=null;
            try
            {
                HtmlAgilityPack.HtmlWeb website = new HtmlAgilityPack.HtmlWeb(); //Need to add HtmlAgilityPack Nuget
                String urlSrc = $"https://www.google.com/finance/quote/USD-" + code + "?hl=en";
                HtmlAgilityPack.HtmlDocument document = website.Load(urlSrc);
                data = document.DocumentNode.SelectSingleNode("//div[@class='YMlKec fxKbKc']").InnerText;                
            }
            catch (NullReferenceException nullexp)
            {
                if (code == "USD")
                {
                    data = "1";
                }
            }
            return data;


        }
    }
}
