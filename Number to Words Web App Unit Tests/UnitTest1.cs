using NUnit.Framework;
using Number_to_Words_Web_App;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using Assert = NUnit.Framework.Assert;

namespace Number_to_Words_Web_App_Unit_Tests
{
    public class Tests
    {
        [Test]
        public void ThisShouldAlwaysPass()
        {
            //Sanity Test
            Assert.Pass();
        }

        [Test]
        public void CheckManipulateNumericMoneyDataIsWorking()
        {
            string GoodInput1 = "$1,000.5";
            string GoodInput1ExpectedResult = "ONE THOUSAND DOLLARS AND FIFTY CENTS";
            string GoodInput2 = "123.01";
            string GoodInput2ExpectedResult = "ONE HUNDRED AND TWENTY-THREE DOLLARS AND ONE CENT";

            string result1 = GoodInput1.ConvertNumToWords();
            string result2 = GoodInput2.ConvertNumToWords();


            Assert.AreEqual(result1, GoodInput1ExpectedResult);
            Assert.AreEqual(result2, GoodInput2ExpectedResult);

        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void ManipulateNumericMoneyDataShouldThrowExeptionWhenInputIsNotMoney()
        {
            string BadInput = "!123.45";

            try
            {
                string result = BadInput.ConvertNumToWords();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Input string was not in a correct format.", e.Message);
            }
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void ManipulateNumericMoneyDataShouldThrowExeptionWhenInvalidCharactersAreInput()
        {
            string BadInput = "0.50c";
            try
            {
                string result = BadInput.ConvertNumToWords();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Invalid cents amount.", e.Message);
            }
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void ManipulateNumericMoneyDataShouldThrowExeptionWhenCentsInputIsTooLong()
        {
            string BadInput = "0.001";
            try
            {
                string result = BadInput.ConvertNumToWords();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Invalid cents amount.", e.Message);
            }
        }

        [Test]
        [ExpectedException(typeof(FormatException))]
        public void ManipulateNumericMoneyDataShouldThrowExeptionWhenMultipleDecPointsAreInput()
        {
            string BadInput = "0.001.1";
            try
            {
                string result = BadInput.ConvertNumToWords();
            }
            catch (Exception e)
            {
                Assert.AreEqual("Invalid input, currency format dollars.cents", e.Message);
            }
        }

    }
}