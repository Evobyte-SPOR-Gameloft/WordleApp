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
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
            Console.WriteLine("Please enter your choice:");
            Console.ForegroundColor = ConsoleColor.Cyan;
            Console.WriteLine("P - Play");
            Console.ResetColor();
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine("Q - Quit");
            Console.ResetColor();
            Console.WriteLine("~~~~~~~~~~~~~~~~~~~~~~~~~~~~~");
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