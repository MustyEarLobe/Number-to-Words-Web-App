using NUnit.Framework;
using Number_to_Words_Web_App;

namespace Number_to_Words_Web_App_Unit_Tests
{
    public class Tests
    {
        



        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public void ThisShouldAlwaysPass()
        {
            Assert.Pass();
        }

        [Test]
        public void CheckManipulateNumericMoneyDataIsWorking()
        {
            string GoodInput1 = "$1,000.5";
            string GoodInput1ExpectedResult = "ONE THOUSAND DOLLARS AND FIFTY CENTS";
            string GoodInput2 = "123.01";
            string GoodInput2ExpectedResult = "ONE HUNDRED AND TWENTY-THREE DOLLARS AND ONE CENT";
            string BadInput1 = "!123.45";            
            string BadInput2 = "0.50c";
            string BadInputsExpectedResult = "Please Enter Valid Number (Dollars And Cents)";

            string result1 = GoodInput1.ConvertNumbToWords();
            string result2 = GoodInput2.ConvertNumbToWords();
            string result3 = BadInput1.ConvertNumbToWords();
            string result4 = BadInput2.ConvertNumbToWords();

            Assert.AreEqual(result1, GoodInput1ExpectedResult);
            Assert.AreEqual(result2, GoodInput2ExpectedResult);
            Assert.AreEqual(result3, BadInputsExpectedResult);
            Assert.AreEqual(result4, BadInputsExpectedResult);

        }

        [Test]
        public void CheckValidationIsWorking()
        {
            string[] TestString1Good = new string[] { "100", "23" };
            string[] TestStringBad = new string[] {"!123","30c" };

            Assert.IsTrue(TestString1Good.IsValidInput());
            Assert.IsFalse(TestStringBad.IsValidInput());
        }

        [Test]
        public void CheckHundredsAreConvertingToWords()
        {
            int TestInt1 = 100;
            //this demonstrates that it can convert with out tens and ones extra
            string TestInt1ExpectedResult = "One Hundred";
            int TestInt2 = 355;
            //This should if tens and ones are there it should append "And" to link the sentence.
            string TestInt2ExpectedResult = "Three Hundred And";

            string result1 = "".HandleHundreds(TestInt1);
            string result2 = "".HandleHundreds(TestInt2);

            Assert.AreEqual(result1, TestInt1ExpectedResult);
            Assert.AreEqual(result2, TestInt2ExpectedResult);
        }

        [Test]
        public void CheckOnesAndTensAreConvertingToWords()
        {
            int TestInt1 = 12;
            string TestInt1ExpectedResult = "Twelve";
            int TestInt2 = 25;

            string TestInt2ExpectedResult = "Twenty-Five";
            string result1 = "".HandelTensAndOnes(TestInt1);
            string result2 = "".HandelTensAndOnes(TestInt2);

            Assert.AreEqual(result1, TestInt1ExpectedResult);
            Assert.AreEqual(result2, TestInt2ExpectedResult);            
        }
    }
}