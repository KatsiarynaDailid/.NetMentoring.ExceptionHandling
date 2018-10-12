using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleAppTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            var textProcessingLogic = new TextProcessingLogic();

            Console.WriteLine("=================//=================\n" +
                "Welcom to the app that will process your text. In order to stop processing enter 'exit'.\n" +
                "=================//=================\n" +
                "Let's start!");

            string text = "";
            do
            {
                Console.WriteLine("Enter text for processing:");
                text = Console.ReadLine();
                Console.WriteLine(textProcessingLogic.GetFirstSymbol(text));

            } while (!textProcessingLogic.Exit);

            Console.WriteLine("Press any key to close app.");
            Console.ReadLine();           
        }
    }
}
