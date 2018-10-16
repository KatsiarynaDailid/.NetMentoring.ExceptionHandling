using ConsoleAppTask1.Exceptions;
using System;

namespace ConsoleAppTask1
{
    public class TextProcessing
    {
        /// <summary>
        /// Process line and get first symbol.
        /// </summary>
        /// <param name="line">Entered line.</param>
        /// <returns>First symbol of entered line.</returns>
        /// <exception cref="Exceptions.EmptyLineException" />
        public char GetFirstSymbol(string line)
        {
            if (String.IsNullOrWhiteSpace(line))
            {
                throw new EmptyLineException("GetFirstSymbol method has thrown an exception.");
            }
            return line[0];
        }
    }
}
