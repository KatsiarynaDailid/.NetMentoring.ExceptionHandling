using System;
using ClassLibrary;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace ClassLibraryTests
{
    [TestClass]
    public class CustomParserTests
    {
        public static CustomParser customParser;

        [ClassInitialize]
        public static void CustomParserTestsInitialize(TestContext testContext)
        {
            customParser = new CustomParser();
        }

        [DataRow("-2147483648", -2147483648)]
        [DataRow("+2147483647", 2147483647)]
        [DataRow("2147483647", 2147483647)]
        [DataRow("+0", 0)]
        [DataRow("-0", 0)]
        [DataRow("0", 0)]
        [DataRow("+1254786", 1254786)]
        [DataRow("-1254786", -1254786)]
        [DataTestMethod]
        public void ParseStringToInt_VerifyParserWithValidValues_CorrectNumberAfterParsing(string valueToParse, int expectedParse)
        {
            int actualResult;
            customParser.ParseStringToInt(valueToParse, out actualResult);

            Assert.AreEqual(expectedParse, actualResult, "Wrong parse result for valid it number.");
        }

        [DataRow("")]
        [DataRow(null)]
        [DataTestMethod]
        [ExpectedException(typeof(ArgumentNullException))]
        public void ParseStringToInt_VerifyParserWithInvalidValues_ArgumentNullExceptionIsThrown(string valueToParse)
        {
            int actualResult;
            customParser.ParseStringToInt(valueToParse, out actualResult);
        }

        [DataRow("0.0")]
        [DataRow("1.23233")]
        [DataRow("string")]
        [DataRow("1;5")]
        [DataRow("2147483648")]
        [DataRow("+2147483648")]
        [DataTestMethod]
        [ExpectedException(typeof(FormatException))]
        public void ParseStringToInt_VerifyParserWithInvalidValues_FormatExceptionIsThrown(string valueToParse)
        {
            int actualResult;
            customParser.ParseStringToInt(valueToParse, out actualResult);
        }

        [DataRow("-2147483648", -2147483648)]
        [DataRow("+2147483647", 2147483647)]
        [DataRow("2147483647", 2147483647)]
        [DataRow("+0", 0)]
        [DataRow("-0", 0)]
        [DataRow("0", 0)]
        [DataRow("+1254786", 1254786)]
        [DataRow("-1254786", -1254786)]
        [DataTestMethod]
        public void TryParseStringToInt_VerifyParserWithValidValues_CorrectNumberAfterParsing(string valueToParse, int expectedParse)
        {
            int actualResult;
            var result = customParser.TryParseStringToInt(valueToParse, out actualResult);

            Assert.IsTrue(result, "Wrong parse result for valid int number.");
            Assert.AreEqual(expectedParse, actualResult, "Wrong parse result for valid int number.");
        }

        [DataRow("0.0")]
        [DataRow("1.23233")]
        [DataRow("string")]
        [DataRow("1;5")]
        [DataRow("2147483648")]
        [DataRow("+2147483648")]
        [DataRow("")]
        [DataRow(null)]
        [DataTestMethod]
        public void TryParseStringToInt_VerifyParserWithInvalidValues_FalseIsReturn(string valueToParse)
        {
            int result;
            var actualResult = customParser.TryParseStringToInt(valueToParse, out result);

            Assert.IsFalse(actualResult, "Wrong parse result for invalid values.") ;
        }
    }
}
