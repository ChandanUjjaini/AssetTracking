using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Reflection;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace AssetTracking
{
    //Class file to input and validate  data
    public class DataIO
    {
        public static string ReadData(string read)// method to input data
        {
            bool Flag;
            string Data;
            do
            {
                Data = CommonOp.ReadData(read);
                Flag = Validation.ChkData(Data);
                if (read == "Asset Location")  
                {
                    Data = Validation.ChkAbb(Data);
                    Flag = Validation.codeVal(Data);
                   
                }
                if (Flag == true)
                
                    CommonOp.ErrorMessage(read);
                               
            } while (Flag == true);
            GC.Collect();
            return Data;
        }

        public static int ReadNum(string read)// Method to input number 
        {
            bool Flag;
            String PriceIn;
            int Data, num;
            do
            {
                PriceIn = CommonOp.ReadData(read);
                Flag = Validation.ChkData(PriceIn);
                if (Flag == false)
                {
                    CommonOp.ErrorMessage(read);
                }
            } while (Flag == false);
            Data = int.Parse(PriceIn);
            GC.Collect();
            return Data;
        }

        public static DateOnly ReadDate(string read) // Method to input date
        {
            bool Flag;
            string ReadDate;
            
            //bool valDate;
            do
            {
                ReadDate = CommonOp.ReadData(read + "in \"mm/dd/yyyy\" format");
                Flag = Validation.DateVal(ReadDate);
                if (Flag == true)
                {
                    CommonOp.ErrorMessage(read);
                }                                       
            } while (Flag == true);
            Flag = DateOnly.TryParse(ReadDate, out DateOnly Data);
            

            return Data;

        }
        public static int Selchk(string read, int count)
        {
            bool Flag;
            int Data=0;
            String Input;
            do
            {
                Input = CommonOp.ReadData(read);
                Flag = Validation.ChkData(Input);
                if (Flag == false)
                {
                    CommonOp.ErrorMessage(read);
                }
                else if (Flag == true)
                {
                    Data = int.Parse(Input);
                    Flag = (Data > count);
                }                
            } while (Flag == true);
            GC.Collect();
            return Data;


        }

        internal static string Ccode2(String name)
        {
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
                if (name == regionInfo.EnglishName)
                    Code = regionInfo.ISOCurrencySymbol;
            }
            return Code;
        }
        internal static decimal LocalPrice(string code, int price)
        {
            float data;
            
            String exrate = CommonOp.ExRate(code);
            float exRate = float.Parse(exrate);
            data = price * exRate; // Converting currency to local
            
            decimal Rdata = Convert.ToDecimal(data);
            Rdata = Math.Round(Rdata, 2);
            GC.Collect();
            return Rdata;
        }

       

    }
}
