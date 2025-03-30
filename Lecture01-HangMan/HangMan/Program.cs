using System.Text;
using CrypticWizard.RandomWordGenerator;

namespace HangMan
{

    internal class Program
    {
        static void Main(string[] args)
        {
            WordGenerator myWordGenerator = new WordGenerator();
            var hangman = new Hangman();
            var wordDatabase = new WordDatabase();
            var wordToGuessOriginal = wordDatabase.GetRandomWord();
            var wordToGuess = wordToGuessOriginal.ToLower();
            var stringBuilder = CreateSecretWord(wordToGuess.Length);

            while (true)
            {
                Console.SetCursorPosition(0, Console.CursorTop - Console.CursorTop);
                hangman.Draw();
                Console.WriteLine("Please enter a guess: " + stringBuilder.ToString());
                string input = Console.ReadLine().ToLower();

                if (input.Length == 1)
                {
                    if (!wordToGuess.Contains(input))
                    {
                        InputIOfLengthOneWrongGuess(hangman);
                    }
                    else
                    {
                        InputIOfLengthOneCorrectGuess(wordToGuess, input, stringBuilder, wordToGuessOriginal);
                        if (WordGuessedCheck(stringBuilder, wordToGuess, hangman))
                        {
                            break;
                        }
                    }
                }
                else
                {
                    if (input.Equals(wordToGuess))
                    {
                        WordGuessed(hangman, wordToGuessOriginal);
                        break;
                    }
                    else
                    {
                        GuessedWholeWordIncorrect(hangman);
                    }
                }
            }
        }

        public static StringBuilder CreateSecretWord(int length)
        {
            var stringBuilder = new StringBuilder();
            for (int i = 0; i < length; i++)
            {
                stringBuilder.Append("_");
            }
            return stringBuilder;
        }

        public static void InputIOfLengthOneWrongGuess(Hangman hangman)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect guess                             ");
            Console.ForegroundColor = ConsoleColor.White;

            hangman.RemoveOneLive();

            if (hangman.GameOverCheck())
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have lost!!!                 ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("Lives remaining: " + hangman.Lives);
        }

        public static void InputIOfLengthOneCorrectGuess(string wordToGuess, string input, StringBuilder stringBuilder, string wordToGuessOriginal)
        {
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("You guessed one of the letters!");
            Console.ForegroundColor = ConsoleColor.White;

            List<int> listOfIndexes = GetIndexes(wordToGuess, input);

            foreach (int index in listOfIndexes)
            {
                stringBuilder.Remove(index, 1);
                if (index == 0)
                {
                    if (wordToGuessOriginal[0].ToString().Equals(wordToGuessOriginal[0].ToString().ToLower()))
                    {
                        stringBuilder.Insert(index, input.ToLower());
                    }
                    else
                    {
                        stringBuilder.Insert(index, input.ToUpper());
                    }
                }
                else
                {
                    stringBuilder.Insert(index, input);
                }
            }
        }

        public static bool WordGuessedCheck(StringBuilder stringBuilder, string wordToGuessOriginal, Hangman hangman)
        {
            if (stringBuilder.ToString().ToLower().Equals(wordToGuessOriginal))
            {
                WordGuessed(hangman, wordToGuessOriginal);
                return true;
            }
            return false;
        }

        public static void WordGuessed(Hangman hangman, string wordToGuessOriginal)
        {
            Console.SetCursorPosition(0, Console.CursorTop - Console.CursorTop);
            hangman.Draw();
            Console.WriteLine("Please enter a guess: " + wordToGuessOriginal);
            Console.ForegroundColor = ConsoleColor.Blue;
            //Console.WriteLine("You guessed one of the letters!");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("You have won!                         ");
            Console.WriteLine("Lives remaining: " + hangman.Lives + "                     ");
            Console.WriteLine("                                                           ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.ReadLine();
        }

        public static List<int> GetIndexes(string wordToGuess, string input)
        {
            List<int> listOfIndexes = new List<int>();

            for (int i = 0; i < wordToGuess.Length; i++)
            {
                if (input == wordToGuess[i].ToString())
                {
                    listOfIndexes.Add(i);
                }
            }
            return listOfIndexes;
        }

        public static void GuessedWholeWordIncorrect(Hangman hangman)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Incorrect guess                             ");
            Console.ForegroundColor = ConsoleColor.White;

            hangman.RemoveOneLive();

            if (hangman.Lives == 0)
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("You have lost!!!                 ");
                Console.ForegroundColor = ConsoleColor.White;
            }
            Console.WriteLine("Lives remaining: " + hangman.Lives);
        }
    }
}