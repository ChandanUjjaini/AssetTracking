using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata.Ecma335;
using System.Runtime.ConstrainedExecution;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AssetTracking
{
    internal class Validation
    {
        public static bool ChkData(string read)//Validation input all string
        {
            bool Flag;

            Flag = int.TryParse(read, out int num);

            if (Flag == false)
            {
                Flag = (String.IsNullOrWhiteSpace(read)); 
            }
            return Flag;
        }

        public static string ChkAbb(string read1)//Checking for alternate country name
        {
            string read = read1.ToLower();
            if ((read == "america") || (read == "us") || (read == "united states of america") || (read == "usa"))
            {
                read = "United States";
            }

            else if ((read == "uae"))
            {
                read = "United Arab Emirates";
            }
            else if ((read == "uk") || (read == "england") || (read == "great britain"))
            {
                read = "united Kingdom";
            }
            else
                read = read1;

            return read;
        }

        public static bool ChkDate(String read)//Validation for input date
        {
            DateTime Data;
            bool Flag;
            Flag = (String.IsNullOrWhiteSpace(read));//Checking for null string
            if (Flag == false)
            {
                Flag = DateTime.TryParse(read, out Data);
                if (Flag == false)
                {
                    Flag = true;
                }
               else
                {
                    Flag = false;
                }    
            }
            if (Flag == false)
            {
                Flag = DateTime.TryParse(read, out Data);
                Flag = Data >= DateTime.Now;
            }
            GC.Collect();
            return Flag;

        }
        public static bool codeVal(string read) //Checking for valid cuntry name
        {
            bool Flag;
            string Data;
            Data = Char.ToUpper(read[0]) + read.Substring(1);//Converting first character to uppercase
            string code = DataIO.Ccode2(Data);
            Flag = Validation.ChkData(code);
            GC.Collect();
            return Flag;
        }
    }


}
        


