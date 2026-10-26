using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Battle_Simulator
{
    internal class Program
    {


        static void Main(string[] args)
        {
            GameTitle.PrintTitle(); // Call the PrintTitle method to display the game title in the console.
            Console.ReadLine(); // Wait for user input before closing the console window.
        }
    }


    // Class to be called when needed to print the title of the game to the console.
    internal static class GameTitle
    {
        private const string Title = "===== BATTLE SIMULATOR =====";

        public static void PrintTitle()
        {
            Console.WriteLine(Title);
        }

    }
}
