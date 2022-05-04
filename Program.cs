
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

    switch (char.Parse(response))
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
    Console.WriteLine("Guess the five letter word!");
    string guessedWord;
    int iterations = 0;
    Console.WriteLine(chosenWord);
    Console.WriteLine();
    do
    {
        guessedWord = Console.ReadLine().ToLower();
        WordleApp.UtilityClass.DeletePrevConsoleLine();
        //if (guessedWord == chosenWord && iterations == 0) Console.WriteLine("How the f...!? You got it first try!");
        //else if(guessedWord == chosenWord && iterations != 0) Console.WriteLine("That's the correct word! Congratulations!");
        if (fiveLetterWords.Contains(guessedWord))
        {
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            string guessedWordUpper = guessedWord.ToUpper();
            for (int i = 0; i < 5; i++)
            {
                if (guessedWord[i] == chosenWord[i]) Console.ForegroundColor = ConsoleColor.Green;
                else if (chosenWord.Contains(guessedWord[i])) Console.ForegroundColor = ConsoleColor.DarkYellow;
                else Console.ForegroundColor = ConsoleColor.DarkGray;
                Console.Write($"[ {guessedWordUpper[i]} ]");
                Console.Write(" ");
                Console.ResetColor();
            }
            Console.WriteLine();
            //WordleApp.UtilityClass.LetterStateByIndex[] result = WordleApp.UtilityClass.LetterCheck(chosenWord, guessedWord);
            //for (int i = 0; i < 5; i++)
            //{
            //    Console.Write($"The letter | {guessedWordUpper[i]} | is: ");
            //    Console.WriteLine(result[i]);
            //}
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

            iterations++;
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
}