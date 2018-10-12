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
        /// <summary>
        /// This method try to parse string to int.
        /// </summary>
        /// <param name="input">Input string.</param>
        /// <param name="intResult">Result of parsing.</param>
        /// <returns>true: if parsing succeeded
        /// false: if input string unable to parse
        /// </returns>
        public bool TryParseStringToInt(string input, ref int intResult)
        {
            try
            {
                ParseStringToInt(input, out intResult);
                return true;
            }
            catch (ArgumentNullException ex)
            {
                Console.WriteLine(ex.Message);
                return false;
            }
            catch (FormatException ex)
            {
                Console.WriteLine(ex.Message);
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

            if (string.IsNullOrEmpty(input))
            {
                throw new ArgumentNullException("input");
            }

            input = input.Trim();

            if (((input[0] == '-' || input[0] == '+') && input.Length > 11) || !(input[0] == '-' || input[0] == '+') && (input.Length > 10))
            {
                throw new FormatException($"Input string '{input}' is too long to be an int number.");
            }

            if (IsItInt(input))
            {
                if (input[0] == '-' || input[0] == '+')
                {
                    Parse(input.Substring(1), ref temporaryValue);

                    if (input[0] == '-')
                        temporaryValue *= -1;
                }
                else
                {
                    Parse(input, ref temporaryValue);
                }
                if (temporaryValue < int.MinValue || temporaryValue > int.MaxValue)
                {
                    throw new FormatException($"Input string '{input}' has wrong format. Expected: int. Actual: long.");
                }
                intResult = (int)temporaryValue;
            }
            else if (IsItFloat(input))
            {
                throw new FormatException($"Input string '{input}' has wrong format. Expected: int. Actual: float.");
            }
            else
                throw new FormatException($"Input string '{input}' has wrong format. Expected: int. Actual: string.");
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
            var regExpression = new Regex(@"^[+|-]?\d{1,10}$");
            return regExpression.IsMatch(stringToVerify);
        }

        private bool IsItFloat(string stringToVerify)
        {
            string separator = NumberFormatInfo.CurrentInfo.NumberDecimalSeparator;
            var regExpression = new Regex($@"^[+\-]?[0-9]*(?:\{separator}[0-9]+)?$");
            return regExpression.IsMatch(stringToVerify);
        }

        #endregion
    }
}
