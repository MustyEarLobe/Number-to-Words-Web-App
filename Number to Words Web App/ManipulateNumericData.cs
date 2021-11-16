using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Number_to_Words_Web_App
{
    public static class ManipulateNumericData
    {
        static string[] ones = new string[] { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine ", "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "NineTeen " };
        static string[] Tens = new string[] { "", "", "Twenty ","Thirty ","Forty ","Fifty ","Sixty ","Seventy ","Eighty ","Ninety "};


        public static string ConvertNumbToWords(this string numericString)
        {
            string Result = "";

            string[] dollarsAndCents = numericString.Split(".");
            if (dollarsAndCents[0].Length > 3)
            {
                return "Please Insert Smaller Number";
            }
            if (dollarsAndCents.Count() > 2 || dollarsAndCents.Count() < 1 /*|| dollarsAndCents[1].Length < 2*/)
            {
                return "Please Enter Valid Number";
            }


            int dollars = Convert.ToInt32(numericString);
            if (dollars/100 > 9)
            {
                return "Please Insert Smaller Number";
            }

            if (dollars/100 >= 1)
            {
                Result += ones[dollars / 100] + "Hundred ";
            }
            if ((dollars % 100 > 0 || dollarsAndCents.Count() == 2) && dollars / 100 >= 1)
            {
                Result += "And ";
            }

            if ((dollars % 100) > 19)
            {
                Result += Tens[(dollars % 100) / 10];
                Result += ones[(dollars % 10)];
            }
            else 
            {
                Result += ones[(dollars % 100)];
            }







            return Result;
        }
    }
}
