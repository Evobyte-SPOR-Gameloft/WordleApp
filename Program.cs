
//Reads a .txt file then adds each line as a string in an array
string[] fiveLetterWords = File.ReadAllLines("dictionary.txt");

bool quit = false;
string fancyDivider = ("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

do
{
    WordleApp.UtilityClass.ShowMenu();
    string response = Console.ReadLine();
    WordleApp.UtilityClass.DeletePrevConsoleLine();
    response = response.ToUpper();
    Console.WriteLine();
    string invalidChoice = "Invalid choice!";
    switch (response[0])
    {
        case 'P':
            PlayTheGame();
            break;
        case 'Q':
            quit = true;
            break;
        default:
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + invalidChoice.Length / 2) + "}", invalidChoice);
            break;
    }
}
while (quit == false);

void PlayTheGame()
{
    string guessString = "Guess the five letter word!";
    string triedString = "~  You've got 6 tries!  ~";
    Random randomWordGenerator = new Random();
    string chosenWord = fiveLetterWords[randomWordGenerator.Next(0, 2500)];
    List<string> guesses = new List<string>();
    List<char> letters = new List<char>();
    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + guessString.Length / 2) + "}", guessString);
    Console.WriteLine("{0," + ((Console.WindowWidth / 2) + triedString.Length / 2) + "}", triedString);
    string guessedWord;
    int iterations = 0;
    Console.WriteLine();

    do
    {
        guessedWord = Console.ReadLine().ToLower();
        WordleApp.UtilityClass.DeletePrevConsoleLine();

        if (fiveLetterWords.Contains(guessedWord) && !guesses.Contains(guessedWord))
        {
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + fancyDivider.Length / 2) + "}", fancyDivider);
            string guessedWordUpper = guessedWord.ToUpper();
            letters.Clear();

            Console.Write(" ");
            Console.SetCursorPosition((Console.WindowWidth / 2) - 15, Console.CursorTop);
            for (int i = 0; i < 5; i++)
            {
                if (guessedWord[i] == chosenWord[i]) Console.ForegroundColor = ConsoleColor.Green;
                else if (chosenWord.Contains(guessedWord[i]) && !letters.Contains(guessedWord[i])) Console.ForegroundColor = ConsoleColor.DarkYellow;
                else Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"[ {guessedWordUpper[i]} ]");
                Console.Write(" ");
                Console.ResetColor();
                letters.Add(guessedWord[i]);
            }

            Console.WriteLine();
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + fancyDivider.Length / 2) + "}", fancyDivider);
            guesses.Add(guessedWord);
            iterations++;
        }
        else if (guesses.Contains(guessedWord))
        {
            string alreadyUsedWord = "You've already used that word, dummy!";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + alreadyUsedWord.Length / 2) + "}", alreadyUsedWord);
            Thread.Sleep(2000);
            WordleApp.UtilityClass.DeletePrevConsoleLine();
        }
        else if (guessedWord.Length > 5)
        {
            string guessTooLong = "Slow down, that's too many letters!";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + guessTooLong.Length / 2) + "}", guessTooLong);
            Thread.Sleep(2000);
            WordleApp.UtilityClass.DeletePrevConsoleLine();
        }
        else if (guessedWord.Length < 5)
        {
            string guessTooShort = "We're gonna need a few more letters!";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + guessTooShort.Length / 2) + "}", guessTooShort);
            Thread.Sleep(2000);
            WordleApp.UtilityClass.DeletePrevConsoleLine();
        }
        else
        {
            string notInDictionary = "That word is not in our dictionary!";
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + notInDictionary.Length / 2) + "}", notInDictionary);
            Thread.Sleep(2000);
            WordleApp.UtilityClass.DeletePrevConsoleLine();
        }
    }
    while (iterations < 6 && guessedWord != chosenWord);

    string firstTry = "How the f...!? You got it first try!";
    string win = $"Congratulations! It took you {iterations} tries to win!";

    if (iterations == 1 && guessedWord == chosenWord) Console.WriteLine("{0," + ((Console.WindowWidth / 2) + firstTry.Length / 2) + "}", firstTry);
    else if (iterations < 7 && guessedWord == chosenWord) Console.WriteLine("{0," + ((Console.WindowWidth / 2) + win.Length / 2) + "}", win);
    else
    {
        string betterLuck = "Aww.. better luck next time!";
        string loseFeedback = "The chosen word was:";
        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + betterLuck.Length / 2) + "}", betterLuck);
        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + loseFeedback.Length / 2) + "}", loseFeedback);
        Console.ForegroundColor = ConsoleColor.Green;
        Console.WriteLine("{0," + ((Console.WindowWidth / 2) + (chosenWord.Length + 2) / 2) + "}", $"[{chosenWord.ToUpper()}]");
        Console.ResetColor();
    }
}