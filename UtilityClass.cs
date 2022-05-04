using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleApp
{
    public static class UtilityClass
    {
        public enum LetterStateByIndex
        {
            Correct,             // The letter is at the right index
            WrongPosition,       // The letter is at another index
            Missing,             // No such letter
            Null                 // Empty space
        }

        //Creates an array of enums to be filled with the results for each letter, then returns the array
        public static LetterStateByIndex[] LetterCheck(string chosenWord, string guessedWord)
        {
            LetterStateByIndex[] result = new LetterStateByIndex[5];

            for (int i = 0; i < 5; i++)
            {
                if (chosenWord[i] == guessedWord[i])
                {
                    result[i] = LetterStateByIndex.Correct;
                }
                else if (chosenWord.Contains(guessedWord[i]))
                {
                    result[i] = LetterStateByIndex.WrongPosition;
                }
                else
                {
                    result[i] = LetterStateByIndex.Missing;
                }
            }

            return result;
        }

    }
}
