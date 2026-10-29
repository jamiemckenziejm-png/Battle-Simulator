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

            bool isRunning = true; // Variable to control the main loop of the program.

            while (isRunning)
            {
                Console.Clear(); // Clear the console for a fresh display.
                GameTitle.PrintTitle(); // Print the game title again for each iteration of the loop.
                Console.WriteLine("1. Start Battle");
                Console.WriteLine("2. Search for a character");
                Console.WriteLine("3. Sort Characters");
                Console.WriteLine("4. View Characters");
                Console.WriteLine("5. Exit");
                Console.Write("Please enter a number to choose an option: ");

                string input = Console.ReadLine(); // Read user input from the console.

                switch (input)
                {
                    case "1":
                        // Start Battle logic here
                        Console.WriteLine("Start battle... NEEDS IMPLEMENTATION ");
                        break;
                    case "2":
                        // Search for a character logic here
                        Console.WriteLine("Search Character ... NEEDS IMPLEMENTATION ");
                        break;
                    case "3":
                        // Sort Characters logic here
                        Console.WriteLine("Sort Characters ... NEEDS IMPLEMENTATION ");
                        break;
                    case "4":
                        // View Characters logic here
                        Console.WriteLine("View Characters Information... NEEDS IMPLEMENTATION ");
                        break;
                    case "5":
                        isRunning = false; // Set isRunning to false to exit the loop and end the program.
                        Console.WriteLine("Exiting the game. Goodbye!");
                        break;
                    default:
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                        break;
                }
                
                Console.WriteLine("Press Enter to continue...");
                Console.ReadLine();
            }
        }
    }


    // Class to be called when needed to print the title of the game to the console.
    internal static class GameTitle
    {
        private const string Title = "===== BATTLE SIMULATOR =====";

        public static void PrintTitle() // method for printing the Game Title 
        {
            Console.WriteLine(Title);
        }
    }

    // Character class 
    public class Character
    {
        // 
        public string Name { get; set; }
        public int Health { get; set; }
        public int Attack { get; set; }
        public int Defence { get; set; }
        public string SpAbility { get; set; }
    }
}
