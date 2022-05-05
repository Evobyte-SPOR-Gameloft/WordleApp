using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WordleApp
{
    public static class UtilityClass
    {
        public static void ShowMenu()
        {
            string fancyDivider = ("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            string enterChoice = ("Please enter your choice:");
            string playMenu = ("P - Play");
            string quitMenu = ("Q - Quit");
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + fancyDivider.Length / 2) + "}", fancyDivider);
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + enterChoice.Length / 2) + "}", enterChoice);
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + playMenu.Length / 2) + "}", playMenu);
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + quitMenu.Length / 2) + "}", quitMenu);
            Console.ResetColor();
            Console.WriteLine("{0," + ((Console.WindowWidth / 2) + fancyDivider.Length / 2) + "}", fancyDivider);
        }
        public static void DeletePrevConsoleLine()
        {
            if (Console.CursorTop == 0) return;
            Console.SetCursorPosition(0, Console.CursorTop - 1);
            Console.Write(new string(' ', Console.WindowWidth));
            Console.SetCursorPosition(0, Console.CursorTop);
        }
    }
}