using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking
{
    public class DataIn
    {
        public static string ReadData(string read)
        {
            bool Flag;
            string Data;

            do
            {
                Console.Write($"Please Enter Asset {read}:");
                Data = Console.ReadLine(); // Asset Type

                bool IsNull = (String.IsNullOrWhiteSpace(Data));
                bool IsNum = int.TryParse(Data, out int num);
                Flag = false;

                if (IsNull || IsNum == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter Valid Data");
                    Console.ResetColor();
                    Flag = true;
                }
            } while (Flag == true);
            
           
            return Data;



        }

        public static String Numchk(string read)
        {
            bool Flag;
            string Data;
            do
            {
                Console.Write($"Please Enter Asset {read}:");
                Data = Console.ReadLine(); // Asset Type
                bool IsNum = int.TryParse(Data, out int num);
                bool IsNull = (String.IsNullOrWhiteSpace(Data));
                Flag = false;
                if ((IsNull==true) || (IsNum != true))
                {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Please Enter Valid Data");
                Console.ResetColor();
                Flag = true;
                }
            } while (Flag == true);

            return Data;

            
        }


    }
}
