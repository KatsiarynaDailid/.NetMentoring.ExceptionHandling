using ClassLibrary.Utils;
using ClassLibrary.Utils.Interfaces;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ClassLibrary
{
    public class CustomParser
    {
        protected ILogger Logger { get; private set; }

        public CustomParser()
        {
            Logger = new Logger();
        }

        /// <summary>
        /// This method try to parse string to int.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <param name="intResult">Result of parsing.</param>
        /// <returns>true: if parsing succeeded
        /// false: if input string unable to parse
        /// </returns>
        public bool TryParseStringToInt(string input, out int intResult)
        {
            try
            {
                ParseStringToInt(input, out intResult);
                return true;
            }
            catch (Exception ex)
            {
                intResult = 0;
                Logger.LogException(ex);
                return false;
            }
        }

        /// <summary>
        /// Parse input string to int
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <param name="intResult">Result of parsing.</param>
        /// <exception cref="System.ArgumentNullException">Thrown when input string is null or empty.</exception>
        /// <exception cref="System.FormatException">Thrown when input string has wrong format.</exception>
        public void ParseStringToInt(string input, out int intResult)
        {
            long temporaryValue = 0;

            if (string.IsNullOrWhiteSpace(input))
            {
                throw new ArgumentNullException("input");
            }

            input = input.Trim();
            var hasSign = input[0] == '-' || input[0] == '+';

            if (hasSign && (input.Length > 11) || !hasSign && (input.Length > 10))
            {
                throw new FormatException($"Input string '{input}' is too long to be an int number.");
            }

            if (IsItInt(input))
            {
                if (hasSign)
                {
                    Parse(input.Substring(1), ref temporaryValue);

                    if (input[0] == '-')
                    {
                        temporaryValue *= -1;
                    }
                }
                else
                {
                    Parse(input, ref temporaryValue);
                }
                if (temporaryValue < int.MinValue || temporaryValue > int.MaxValue)
                {
                    throw new FormatException($"Input string '{input}' has wrong format. Expected format is int.");
                }
                intResult = (int)temporaryValue;
            }
            else
            {
                throw new FormatException($"Input string '{input}' has wrong format. Expected format is int.");
            }
        }

        #region Private

        private void Parse(string strToParse, ref long temporaryValue)
        {
            foreach (char c in strToParse)
            {
                temporaryValue *= 10;
                temporaryValue += c - '0';
            }
        }

        private bool IsItInt(string stringToVerify)
        {
            bool isItInt = false;
            if(stringToVerify[0] == '-' || stringToVerify[0] == '+')
            {
                stringToVerify = stringToVerify.Substring(1);
            }

            foreach (var c in stringToVerify)
            {
                var k = c - '0';
                isItInt = Enumerable.Range(0, 9).Contains(k);
                if (!isItInt)
                {
                    return isItInt;
                }
            }
 
            return isItInt;
           /* var regExpression = new Regex(@"^[+|-]?\d{1,10}$");
            return regExpression.IsMatch(stringToVerify);*/
        }

        #endregion
    }
}
