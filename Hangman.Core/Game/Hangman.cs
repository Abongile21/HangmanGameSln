using System;
using System.Collections.Generic;
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
            int remainingGuesses = 6;
            Random rand = new Random();
            string selectedWord = words[rand.Next(words.Length)];
            char[] guessedWord = new string('-', selectedWord.Length).ToCharArray();
            
            HashSet<char> guessedLetters = new HashSet<char>();
        
            while(remainingGuesses > 0 && new string(guessedWord)!=selectedWord)
            {
                Console.Clear();
                _renderer.Render(5, 5, remainingGuesses);

                Console.SetCursorPosition(0, 13);
                Console.ForegroundColor = ConsoleColor.Blue;
                Console.Write("Your current guess: ");
                Console.WriteLine(new string(guessedWord));
                
                


                Console.SetCursorPosition(0, 15);
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("What is your next guess: ");
                string nextGuess = Console.ReadLine();
                
                if (string.IsNullOrWhiteSpace(nextGuess) || nextGuess.Length != 1 || !char.IsLetter(nextGuess[0]))
                {
                    Console.SetCursorPosition(0, 17);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Invalid input. Press any key...");
                    Console.ReadKey();
                    continue;
                }

                
                 char guessed = char.ToLower(nextGuess[0]);

                if (guessedLetters.Contains(guessed))
                {
                    Console.SetCursorPosition(0, 17);
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("You already guessed that. Press any key...");
                    Console.ReadKey();
                    continue;
                };

                guessedLetters.Add(guessed);

                if (selectedWord.Contains(guessed))
                {
                    for (int i = 0; i < selectedWord.Length; i++)
                    {
                        if (selectedWord[i] == guessed)
                        {
                            guessedWord[i] = guessed;
                        }
                    }
                }
                else
                {
                    remainingGuesses--;
                }
            }
            Console.Clear();
            _renderer.Render(5, 5, remainingGuesses);

            Console.SetCursorPosition(0, 13);
            Console.ForegroundColor = ConsoleColor.Cyan;

            if (new string(guessedWord) == selectedWord)
            {
                Console.WriteLine("Congratulations! You survived!");
                Console.WriteLine("The word was: " + selectedWord);
            }
            else
            {
                Console.WriteLine("You died. Better luck next time!");
                Console.WriteLine("The word was: " + selectedWord);
            }

            Console.ResetColor();

        }
    }
}
