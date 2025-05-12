using System;
using System.Threading;
using Hangman.Core.Game;

namespace HangmanGameConsole
{
    internal class Program
    {
        static void Main(string[] args)
        {
            ConsoleColor oldColor = Console.ForegroundColor;

            Console.ForegroundColor = ConsoleColor.Green;
            Console.SetCursorPosition(10, 2);
            Console.Write("Welcome to Hangman for Developers!!");
            Thread.Sleep(2000);

            var hangman = new HangmanGame();
            hangman.Run();

            Console.ForegroundColor = oldColor;


            Console.SetCursorPosition(20, 25);
            Console.WriteLine("Thank you for playing dev");
            Console.ReadLine();
        }
    }
}
