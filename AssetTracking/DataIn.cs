using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking
{
    //Class file to input and validate  data
    public class DataIn
    {
        public static string ReadData(string read)
        {
            bool Flag;
            string Data;

            do
            {
                Console.Write($"Please Enter Asset {read}:");
                Data = Console.ReadLine();
                bool IsNull = (String.IsNullOrWhiteSpace(Data));
                bool IsNum = int.TryParse(Data, out int num);
                Flag = false;

                if (IsNull || IsNum == true)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter Valid Data");// Error Message
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
                if ((IsNull == true) || (IsNum != true))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter Valid Data");// Error Message
                    Console.ResetColor();
                    Flag = true;
                }
            } while (Flag == true);

            return Data;


        }

        public static DateOnly Datechk(string read)
        {
            bool Flag;
            string ReadDate;
            DateOnly Data;
            do
            {
                Console.Write($"Please Enter Purchase {read} in \"mm/dd/yyyy\" format:");
                ReadDate = Console.ReadLine();
                bool IsNull = (String.IsNullOrWhiteSpace(ReadDate));
                DateTime DataT = DateTime.Parse(ReadDate);
                //Validating date format
                Flag = DateOnly.TryParseExact(ReadDate, "mm/dd/yyyy", CultureInfo.InvariantCulture, DateTimeStyles.None, out DateOnly dateChk1);
                Data = DateOnly.Parse(ReadDate);    
                bool valDate = DataT <= DateTime.Now; // Checking for advance date
                if ((IsNull == true) || (Flag == false) || (valDate == false))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter Valid Data");// Error Message
                    Console.ResetColor();
                    Flag = true;
                }
                else
                {
                    Flag = false;
                }

                


            } while (Flag == true);

            //var Data1 = Convert.ToDateTime(Data);
            //var Data2 = Data1.Date;
           return Data;
        }
        public static String Selchk(string read, int count)
        {
            bool Flag;
            string Data;
            do
            {
                Console.Write($"Please Enter  {read}:");
                Data = Console.ReadLine(); // Asset Type
                bool IsNum = int.TryParse(Data, out int num);
                if ((num >=1) && (num <= count))
                {
                    IsNum = true; 
                }
                else
                {
                    IsNum = false;
                }
                    
                bool IsNull = (String.IsNullOrWhiteSpace(Data));
                         
                Flag = false;
                if ((IsNull == true) || (IsNum != true))
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Please Enter Valid Data");// Error Message
                    Console.ResetColor();
                    Flag = true;
                }
            } while (Flag == true);

            return Data;


        }
    }
}
