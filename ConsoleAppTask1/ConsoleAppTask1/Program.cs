using ConsoleAppTask1.Exceptions;
using System;

namespace ConsoleAppTask1
{
    class Program
    {
        static void Main(string[] args)
        {
            var textProcessing = new TextProcessing();

            Console.WriteLine("=================//=================\n" +
                "Welcom to the app that will process your text.\n" +
                "=================//=================\n" +
                "Let's start!");

            var continueKey = ConsoleKey.Escape;
            do
            {
                Console.WriteLine("Enter text for processing:");
                var text = Console.ReadLine();

                try
                {
                    Console.WriteLine(textProcessing.GetFirstSymbol(text));
                }
                catch (EmptyLineException ex)
                {
                    Console.WriteLine($"Empty line was entered. {ex.Message}.");
                }

                Console.WriteLine("In order to exit press 'Escape'. In order to continue press any other key.");
                continueKey = Console.ReadKey(true).Key;

            } while (continueKey != ConsoleKey.Escape);

            Console.WriteLine("Press any key to close app.");
            Console.ReadKey();
        }
    }
}
