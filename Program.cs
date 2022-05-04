
//Reads a .txt file then adds each line as a string in an array
string[] fiveLetterWords = File.ReadAllLines("dictionary.txt");

//Picks an index at random from the string array then returns the string
string GenerateRandomWord()
            {
                Random randomWordGenerator = new Random();
                return fiveLetterWords[randomWordGenerator.Next(0, 2500)];
            }
string chosenWord = GenerateRandomWord();
//char[] chosenWordAsCharArray = chosenWord.ToCharArray();

string guessedWord;

//Console.WriteLine(chosenWord);

Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");

Console.WriteLine("Guess the five letter word!");

guessedWord = Console.ReadLine();

WordleApp.UtilityClass.LetterStateByIndex[] result = WordleApp.UtilityClass.LetterCheck(chosenWord, guessedWord);

for(int i = 0; i < 5; i++)
{
    Console.Write($"The letter No. {i + 1} is: ");
    Console.WriteLine(result[i]);
}


Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~");