using ConsoleAppTask1.Exceptions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace ConsoleAppTask1
{
    public class TextProcessingLogic
    {
        public bool Exit { get; private set; }

        /// <summary>
        /// Process line and get first symbol.
        /// </summary>
        /// <param name="line">Entered line.</param>
        /// <returns>First symbol of entered line.</returns>
        public string GetFirstSymbol(string line)
        {
            try
            {
                LineValidation(line);
            }
            catch (EmptyLineException ex)
            {
                return $"Error message: {ex.Message}";
            }
            if (line.Equals("exit"))
            {
                Exit = true;
                return "Process was ended by entering stop word.";
            }

            return $"First Symbol: '{line[0].ToString()}'.";
        }

        #region Private

        /// <summary>
        /// Validate if input string is null or empty
        /// </summary>
        /// <param name="line">Input string</param>
        /// <exception cref="Exceptions.EmptyLineException" />
        private void LineValidation(string line)
        {
            Match match = Regex.Match(line, @"^[ \t\r\n\s]*$");

            if (String.IsNullOrEmpty(line) || match.Success)
            {
                throw new EmptyLineException();
            }
        }

        #endregion
    }
}
