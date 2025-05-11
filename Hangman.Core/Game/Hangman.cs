using System;
using HangmanRenderer.Renderer;

namespace Hangman.Core.Game
{
    public class HangmanGame
    {
        private GallowsRenderer _renderer;
        private readonly string[] words = {
            "compiler", "index", "inheritance", "casting", "parameter",
            "framework", "console", "array", "dictionary", "github",
            "method", "class", "object", "override", "interface",
            "constructor", "abstraction", "encapsulation", "namespace", "stack"
        };


        public HangmanGame()
        {
            _renderer = new GallowsRenderer();
        }

        public void Run()
        {
            int guess = 6;
            Random rand = new Random();
            string selectedWord = words[rand.Next(words.Length)];
            char[] guessedWord = new string('-', selectedWord.Length).ToCharArray();
            int remainingLives = 6;
            HashSet<char> guessedLetters = new HashSet<char>();
        
          
            _renderer.Render(5, 5, 6);
            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("Your current guess: ");
            Console.WriteLine("--------------");
            Console.SetCursorPosition(0, 15);

            Console.ForegroundColor = ConsoleColor.Green;



            Console.Write("What is your next guess: ");
            var nextGuess = Console.ReadLine();
        }

    }
}
