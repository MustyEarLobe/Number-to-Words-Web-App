using System;
using System.Collections.Generic;
using System.Linq;

namespace Number_to_Words_Web_App
{
    public static class ManipulateNumericMoneyData
    {
        static string[] ones = new string[] { "", "One ", "Two ", "Three ", "Four ", "Five ", "Six ", "Seven ", "Eight ", "Nine ", "Ten ", "Eleven ", "Twelve ", "Thirteen ", "Fourteen ", "Fifteen ", "Sixteen ", "Seventeen ", "Eighteen ", "NineTeen " };
        static string[] tens = new string[] { "", "", "Twenty ", "Thirty ", "Forty ", "Fifty ", "Sixty ", "Seventy ", "Eighty ", "Ninety " };
        static string[] positiveExponentsOfThousand = new string[] { "", "", "Thousand ", "Million ", "billion ", "trillion " };

        public static string ConvertNumbToWords(this string numericString)
        {
            string Result = "";

            numericString = numericString.Replace("$", string.Empty).Replace(",", string.Empty);            
            string[] dollarsAndCentsString = numericString.Split(".");
            if (dollarsAndCentsString.Count() == 2)
            {
                if (dollarsAndCentsString[1].Length < 2)
                {
                    dollarsAndCentsString[1] += "0";
                }
            }            

            if (!dollarsAndCentsString.IsValidInput())
            {
                return "Please Enter Valid Number (Dollars And Cents)";
            }

            Result = Result.HandleDollars(dollarsAndCentsString).HandleCents(dollarsAndCentsString);            

            return Result;
        }
        public static bool IsValidInput(this string[] input)
        {
            foreach (string item in input)
            {
                foreach (char c in item)
                {
                    if (!char.IsDigit(c))
                    {
                        return false;
                    }

                }
            }

            if (input.Count() == 2)
            {
                if (input[1].Length != 2)
                {
                    return false;
                }

            }
            if (input.Count() > 2 || input.Count() < 1)
            {
                return false;
            }
            return true;
        }

        public static string HandleDollars(this string result, string[] dollarsAndCentsString)
        {
            if (dollarsAndCentsString[0].Length > 0)
            {
                int dollars;
                string[] dollarsStrings = dollarsAndCentsString[0].splitIntoPositiveExponentsOfThousand().ToArray();
                for (int i = 0; i < dollarsStrings.Count(); i++)
                {
                    dollars = Convert.ToInt32(dollarsStrings[i]);
                    result = result.HandleHundreds(dollars).HandelTensAndOnes(dollars);
                    result += positiveExponentsOfThousand[dollarsStrings.Count() - i];
                }
                if (result == "One ")
                {
                    result += "Dollar ";
                }
                else
                {
                    result += "Dollars ";
                }
                if (dollarsAndCentsString.DoseAmountHasCents())
                {
                    result += "And ";
                }
                return result;
            }
            else
            {
                return "";
            }
        }
        public static string HandleCents(this string result, string[] dollarsAndCentsString)
        {
            if (dollarsAndCentsString.Count() > 1)
            {
                int cents = Convert.ToInt32(dollarsAndCentsString[1]);
                result = result.HandelTensAndOnes(cents);

                if (cents == 1)
                {
                    result += "Cent ";
                }
                else
                {
                    result += "Cents ";
                }
            }
            return result;
        }

        public static IEnumerable<string> splitIntoPositiveExponentsOfThousand(this string inputstring)
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

        public static bool DoseAmountHasCents(this string[] dollarsAndCents)
        {
            return dollarsAndCents.Count() == 2;
        }

        public static string HandleHundreds(this string inputString, int InputNumb)
        {
            if (InputNumb / 100 >= 1)
            {
                inputString += ones[InputNumb / 100] + "Hundred ";
            }
            if (InputNumb % 100 > 0 && InputNumb / 100 >= 1)
            {
                inputString += "And ";
            }
            return inputString;
        }

        public static string HandelTensAndOnes(this string inputString, int InputNumb)
        {
            if ((InputNumb % 100) > 19)
            {
                inputString += tens[(InputNumb % 100) / 10];
                inputString += ones[(InputNumb % 10)];
            }
            else
            {
                inputString += ones[(InputNumb % 100)];
            }
            return inputString;
        }
    }
}
