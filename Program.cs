
//Reads a .txt file then adds each line as a string in an array
string[] fiveLetterWords = File.ReadAllLines("dictionary.txt");

bool quit = false;

do
{
    WordleApp.UtilityClass.ShowMenu();
    string response = Console.ReadLine();
    WordleApp.UtilityClass.DeletePrevConsoleLine();
    response = response.ToUpper();
    Console.WriteLine();

    switch (response[0])
    {
        case 'P':
            PlayTheGame();
            break;
        case 'Q':
            quit = true;
            break;
        default:
            Console.WriteLine("Invalid choice!");
            break;
    }
}
while (quit == false);

void PlayTheGame()
{
    Random randomWordGenerator = new Random();
    string chosenWord = fiveLetterWords[randomWordGenerator.Next(0, 2500)];
    List<string> guesses = new List<string>();
    List<char> letters = new List<char>();
    Console.WriteLine("Guess the five letter word!");
    string guessedWord;
    int iterations = 0;
    Console.WriteLine();
    Console.WriteLine(chosenWord);

    do
    {
        guessedWord = Console.ReadLine().ToLower();
        WordleApp.UtilityClass.DeletePrevConsoleLine();

        if (fiveLetterWords.Contains(guessedWord) && !guesses.Contains(guessedWord))
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            string guessedWordUpper = guessedWord.ToUpper();
            letters.Clear();

            for (int i = 0; i < 5; i++)
            {
                //Known bug: If the chosenWord has two identical letters and
                //your guessWord has both those letters in the wrong place
                //only one of them will be highlighted
                if (guessedWord[i] == chosenWord[i]) Console.ForegroundColor = ConsoleColor.Green;
                else if (chosenWord.Contains(guessedWord[i]) && !letters.Contains(guessedWord[i])) Console.ForegroundColor = ConsoleColor.DarkYellow;
                else Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"[ {guessedWordUpper[i]} ]");
                Console.Write(" ");
                Console.ResetColor();
                letters.Add(guessedWord[i]);
            }

            Console.WriteLine();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            guesses.Add(guessedWord);
            iterations++;
        }
        else if (guesses.Contains(guessedWord))
        {
            Console.WriteLine("You've already used that word, dummy!");
            Thread.Sleep(2000);
            WordleApp.UtilityClass.DeletePrevConsoleLine();
        }
        else if (guessedWord.Length > 5)
        {
            Console.WriteLine("Slow down, that's too many letters!");
            Thread.Sleep(2000);
            WordleApp.UtilityClass.DeletePrevConsoleLine();
        }
        else if (guessedWord.Length < 5)
        {
            Console.WriteLine("We're gonna need a few more letters!");
            Thread.Sleep(2000);
            WordleApp.UtilityClass.DeletePrevConsoleLine();
        }
        else
        {
            Console.WriteLine("That word is not in our dictionary!");
            Thread.Sleep(2000);
            WordleApp.UtilityClass.DeletePrevConsoleLine();
        }
    }
    while (iterations < 6 && guessedWord != chosenWord);

    if (iterations == 1) Console.WriteLine("How the f...!? You got it first try!");
    else if (iterations < 6) Console.WriteLine($"Congratulations! It took you {iterations} tries to win!");
    else
    {
        Console.WriteLine("Aww.. better luck next time!");
        Console.Write("The chosen word was ");
        Console.ForegroundColor = ConsoleColor.Green;
        Console.Write(chosenWord);
        Console.ResetColor();
        Console.WriteLine();
    }
}