using System;
using System.Collections.Generic;
using System.IO;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Json;

namespace Battle_Simulator
{
    internal class Program
    {
        private const string CharacterFileName = "characters.json"; // File name for storing character data in JSON format.
        static void Main(string[] args)
        {
            List<Character> characters = LoadCharacters(); // Load characters from the JSON file into a list.
            Console.WriteLine("Character file path: " + GetCharacterFilePath()); // Print the file path of the character JSON file to the console.

            GameTitle.PrintTitle(); // Call the PrintTitle method to display the game title in the console.

            bool isRunning = true; // Variable to control the main loop of the program.

            while (isRunning)
            {
                Console.Clear(); // Clear the console for a fresh display.
                GameTitle.PrintTitle(); // Print the game title again for each iteration of the loop.
                Console.WriteLine("Characters Loaded: " + characters.Count);
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
                        ViewAllCharacters(characters);
                        break;
                    case "5":
                        isRunning = false; // Set isRunning to false to exit the loop and end the program.
                        Console.WriteLine("Exiting the game. Goodbye!");
                        break;
                    default: // Handle invalid input
                        Console.WriteLine("Invalid input. Please enter a number between 1 and 5.");
                        break;
                }
                if (isRunning) // Only prompt to continue if the program is still running.
                {
                    Console.WriteLine("\nPress Enter to continue...");
                    Console.ReadLine(); // Wait for user input before continuing the loop.
                }
            }
        }

        private static List<Character> LoadCharacters()
        {
            try
            {
                string fullpath = GetCharacterFilePath(); // Get the full path to the character JSON file.

                if (!File.Exists(fullpath) || new FileInfo(fullpath).Length == 0)
                {
                    List<Character> defaults = GetDefaultCharacters();
                    SaveCharacters(defaults); // Save default characters to the JSON file if it doesn't exist or is empty.
                    return defaults; // Return the default characters.
                }

                // If the file exists and is not empty, read and deserialize the JSON data.
                using (FileStream stream = new FileStream(fullpath, FileMode.Open, FileAccess.Read))
                {
                    DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Character>));
                    List<Character> loaded = serializer.ReadObject(stream) as List<Character>; // Deserialize the JSON data into a list of Character objects.
                    
                    if (loaded == null || loaded.Count == 0)
                    {
                        loaded = GetDefaultCharacters(); // If the loaded list is null or empty, use default characters.
                        SaveCharacters(loaded); // Save the default characters to the JSON file.
                    }
                    return loaded;
                }
            }
            catch
            {
                // Fallback if JSON is broken or file read fails 
                List<Character> defaults = GetDefaultCharacters(); // In case of an error, return default characters.
                SaveCharacters(defaults); // Save default characters to the JSON file.
                Console.WriteLine("Error loading characters. Default characters have been loaded.");
                return defaults;
            }
        }

        private static void SaveCharacters(List<Character> characters)
        {
            string fullpath = GetCharacterFilePath(); // Get the full path to the character JSON file.

            using (FileStream stream = new FileStream(fullpath, FileMode.Create, FileAccess.Write))
            {
                DataContractJsonSerializer serializer = new DataContractJsonSerializer(typeof(List<Character>));
                serializer.WriteObject(stream, characters); // Serialize the list of Character objects to JSON and write it to the file.
            }
        }

        private static string GetCharacterFilePath()
        {
            
            return Path.Combine(AppDomain.CurrentDomain.BaseDirectory, CharacterFileName); // Combine the base directory of the application with the character file name to get the full path.
        }

        // Method to provide a list of default characters in case the JSON file is missing or corrupted.
        private static List<Character> GetDefaultCharacters()
        {
            return new List<Character>
            {
                new Character { Id = 001, Name = "Brandon", Type = "Warrior", Health = 100, Attack = 20, Defence = 10, SpAbility = "Berserk" },
                new Character { Id = 002, Name = "Astra", Type = "Mage", Health = 80, Attack = 25, Defence = 5, SpAbility = "Fireball" },
                new Character { Id = 003, Name = "Archie", Type = "Archer", Health = 90, Attack = 15, Defence = 8, SpAbility = "Arrow Rain" },
                new Character { Id = 004, Name = "Luna", Type = "Assassin", Health = 70, Attack = 30, Defence = 5, SpAbility = "Shadow Strike" },
            };
        }

        private static void ViewAllCharacters(List<Character> characters)
        {
            // Validate the list before trying to display data.
            if (characters == null || characters.Count == 0)
            {
                Console.WriteLine("No characters available to display.");
                return;
            }

            Console.Clear(); // Clear the console for a fresh display.
            GameTitle.PrintTitle(); // Print the game title again for the character view.
            Console.WriteLine("===== Character List =====\n");

            // Display each character's details in a formatted manner.
            foreach (Character c in characters)
            {
                Console.WriteLine($"ID: {c.Id}, Name: {c.Name}, Type: {c.Type}, Health: {c.Health}, Attack: {c.Attack}, Defence: {c.Defence}, Special Ability: {c.SpAbility}");
            }
        }
    }


    // Class to be called when needed to print the title of the game to the console.
    internal static class GameTitle
    {
        private const string Title = "\t\t\t ===== BATTLE SIMULATOR ===== \n\n\n";

        public static void PrintTitle() // method for printing the Game Title 
        {
            Console.WriteLine(Title);
        }
    }
    [DataContract]
    public class  Character 
    {
        [DataMember] public int Id { get; set; }
        [DataMember] public string Name { get; set; }
        [DataMember] public string Type { get; set; }
        [DataMember] public int Health { get; set; }
        [DataMember] public int Attack { get; set; }
        [DataMember] public int Defence { get; set; }
        [DataMember] public string SpAbility { get; set; }
    }

}
