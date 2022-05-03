
//string[] fiveLetterWords = File.ReadAllLines("C:\\_CodingVS\\WordleApp\\WordleApp\\dictionary.txt");

string[] fiveLetterWords = File.ReadAllLines("dictionary.txt");

foreach (string word in fiveLetterWords)
{
    Console.WriteLine(word);
}