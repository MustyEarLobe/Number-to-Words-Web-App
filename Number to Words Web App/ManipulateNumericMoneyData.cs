using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;

namespace Number_to_Words_Web_App
{
    public static class ManipulateNumericMoneyData
    {
        static string[] ones = new string[] { "", "One", "Two", "Three", "Four", "Five", "Six", "Seven", "Eight", "Nine", "Ten", "Eleven", "Twelve", "Thirteen", "Fourteen", "Fifteen", "Sixteen", "Seventeen", "Eighteen", "NineTeen" };
        static string[] tens = new string[] { "", "", "Twenty", "Thirty", "Forty", "Fifty", "Sixty", "Seventy", "Eighty", "Ninety" };
        static string[] positiveExponentsOfThousand = new string[] { "", "", "Thousand", "Million", "billion", "trillion" };

        public static string ConvertNumToWords(this string numericString)
        {
            string Result = "";

            numericString = numericString.Replace("$", string.Empty).Replace(",", string.Empty);            
            string[] dollarsAndCentsString = numericString.Split(".");

            //If Cents are to the first decamal place, Append 0 to string.
            if (dollarsAndCentsString.Count() == 2)
            {
                if (dollarsAndCentsString[1].Length < 2)
                {
                    dollarsAndCentsString[1] += "0";
                }
            }

            if (dollarsAndCentsString.IsValidInput())
            {
                Result = Result.AppendDollarsString(dollarsAndCentsString).AppendSpaceIfNeeded().AppendCentsString(dollarsAndCentsString);
            }            

            return Result.ToUpper(); 
        }
        private static bool IsValidInput(this string[] input)
        {
            var inputcount = input.Count();            

            if (inputcount == 2)
            {
                if (input[1].Length != 2)
                {
                    throw new FormatException("Invalid cents amount.");
                }
            }
            if (inputcount > 2 || inputcount < 1)
            {
                throw new FormatException("Invalid input, currency format dollars.cents");
            }
            return true;
        }

        private static string AppendDollarsString(this string inputString, string[] dollarsAndCentsString)
        {
            if (dollarsAndCentsString[0].Length == 0)
            {
                return "";
            }
                int dollars;
                string[] dollarsStrings = dollarsAndCentsString[0].splitIntoPositiveExponentsOfThousand().ToArray();
                for (int i = 0; i < dollarsStrings.Count(); i++)
                {
                    dollars = Convert.ToInt32(dollarsStrings[i]);
                    
                    inputString = inputString.HandleHundreds(dollars).AppendSpaceIfNeeded().HandelTensAndOnes(dollars).AppendSpaceIfNeeded();
                
                    inputString += positiveExponentsOfThousand[dollarsStrings.Count() - i].AppendSpaceIfNeeded();
                }
                if (inputString == "One")
                {
                    inputString += "Dollar";
                }
                else
                {
                    inputString += "Dollars";
                }
                if (dollarsAndCentsString.DoesAmountHasCents())
                {
                    inputString += " And";
                }
                return inputString;            
        }
        private static string AppendCentsString(this string inputString, string[] dollarsAndCentsString)
        {
            if (dollarsAndCentsString.Count() <= 1)
            {
                return inputString;
            }
            int cents = Convert.ToInt32(dollarsAndCentsString[1]);
                inputString = inputString.HandelTensAndOnes(cents).AppendSpaceIfNeeded();

                if (cents == 1)
                {
                    inputString += "Cent";
                }
                else
                {
                    inputString += "Cents";
                }
            
            return inputString;
        }

        private static string AppendSpaceIfNeeded(this string input)
        {
            if (input == "")
            {
                return input;
            }
            var LastCharIndex = input.Length-1;
            if (input[LastCharIndex] != ' ')
            {
                input += " ";
            }
            return input;
        }

        private static IEnumerable<string> splitIntoPositiveExponentsOfThousand(this string inputstring)
        {
            List<string> result = new List<string>();
            for (int i = inputstring.Length; i > 0 ; i-=3)
            {
                if (i<3)
                {
                    result.Insert(0, inputstring.Substring(0, inputstring.Length%3));
                }
                else
                {
                    result.Insert(0, inputstring.Substring(i - 3, 3));
                }                
            }
            return result;
        }

        private static bool DoesAmountHasCents(this string[] dollarsAndCents)
        {
            return dollarsAndCents.Count() == 2;
        }

        private static string HandleHundreds(this string inputString, int InputNum)
        {
            if (InputNum / 100 >= 1)
            {
                inputString += ones[InputNum / 100] + " Hundred";
            }
            if (InputNum % 100 > 0 && InputNum / 100 >= 1)
            {
                inputString += " And";
            }
            return inputString;
        }

        private static string HandelTensAndOnes(this string inputString, int InputNum)
        {            
            if ((InputNum % 100) > 19)
            {
                inputString += tens[(InputNum % 100) / 10];
                if (InputNum % 10 > 0)
                {
                    inputString += "-";
                }
                inputString += ones[(InputNum % 10)];
            }
            else
            {
                inputString += ones[(InputNum % 100)];
            }
            return inputString;
        }
    }
}
