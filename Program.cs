
//Reads a .txt file then adds each line as a string in an array
string[] fiveLetterWords = File.ReadAllLines("dictionary.txt");

bool quit = false;

do
{
    WordleApp.UtilityClass.ShowMenu();
    string response = Console.ReadLine();
    response = response.ToUpper();

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
    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
    Console.WriteLine("Guess the five letter word!");
    string guessedWord;
    guessedWord = Console.ReadLine();
    WordleApp.UtilityClass.LetterStateByIndex[] result = WordleApp.UtilityClass.LetterCheck(chosenWord, guessedWord);

    for (int i = 0; i < 5; i++)
    {
        Console.Write($"The letter No. {i + 1} is: ");
        Console.WriteLine(result[i]);
    }

    Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
}