
//string[] fiveLetterWords = File.ReadAllLines("C:\_CodingVS\WordleApp\dictionary.txt");

string[] fiveLetterWords = File.ReadAllLines("dictionary.txt");

string GenerateRandomWord()
{
    Random randomWordGenerator = new Random();
    return fiveLetterWords[randomWordGenerator.Next(0, 2500)];
}

Console.WriteLine(GenerateRandomWord());



