/**
* 13FEB22
* CSC 153
* Taylor J. Brown
* This program is a maze/rpg text adventure game. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace ConsoleUI
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Empty lists
			List<string> Rooms = new List<string>();
			List<string> Weapons = new List<string>();
			List<string> Potions = new List<string>();
			List<string> Treasures = new List<string>();
			List<string> Items = new List<string>();
			List<string> Mobs = new List<string>();

			// Sets all file paths to csv files for each list
			string roomsFile = "Game_Data/Rooms.csv";
			string weaponsFile = "Game_Data/Weapons.csv";
			string potionsFile = "Game_Data/Potions.csv";
			string treasuresFile = "Game_Data/Treasures.csv";
			string itemsFile = "Game_Data/Items.csv";
			string mobsFile = "Game_Data/Mobs.csv";

			// Opens the file and returns the updated list contents
			OpenFiles(ref Rooms, roomsFile);
			OpenFiles(ref Weapons, weaponsFile);
			OpenFiles(ref Potions, potionsFile);
			OpenFiles(ref Treasures, treasuresFile);
			OpenFiles(ref Items, itemsFile);
			OpenFiles(ref Mobs, mobsFile);

			//Main menu
			bool exit = false;
			while (exit == false)
			{
				Console.WriteLine("Main Menu");
				Console.WriteLine("1. Display Rooms");
				Console.WriteLine("2. Display Weapons");
				Console.WriteLine("3. Display Potions");
				Console.WriteLine("4. Display Treasure");
				Console.WriteLine("5. Display Items");
				Console.WriteLine("6. Display Mobs");
				Console.WriteLine("7. Test Play");
				Console.WriteLine("8. Exit");
				Console.Write("Enter a choice > ");
				string input = Console.ReadLine();

				if (input == "1")
				{
					DisplayList(ref Rooms);
				}
				else if (input == "2")
				{
					DisplayList(ref Weapons);
				}
				else if (input == "3")
				{
					DisplayList(ref Potions);
				}
				else if (input == "4")
				{
					DisplayList(ref Treasures);
				}
				else if (input == "5")
				{
					DisplayList(ref Items);
				}
				else if (input == "6")
				{
					DisplayList(ref Mobs);
				}
				else if (input == "7")
                {
					TestPlay(ref Rooms);
                }
				else if (input == "8")
				{
					Console.WriteLine("Goodbye");
					exit = true;
				}
				else
				{
					Console.WriteLine("\nInvalid choice!\n");
				}
			}
		}

		// Current game play Method
		public static void TestPlay(ref List<string> Rooms)
		{
			int currentLocation = 2;
			Console.WriteLine("\nIf you want to move north type 'n'");
			Console.WriteLine("If you want to move south type 's'");
			Console.WriteLine("To display the rooms type 'rooms'");
			Console.WriteLine("To go back to the main menu type 'exit'");
			Console.WriteLine("\nYour current location is the Bathroom\n");

			bool exit = false;
			while (exit == false)
			{
				Console.Write(">");
				string input = Console.ReadLine();

				if (input == "n")
				{
					if (currentLocation < 4)
					{
						currentLocation += 1;
						Console.WriteLine(Rooms[currentLocation] + "\n");
					}
					else
					{
						Console.WriteLine("There are no more rooms in this direction\n");
					}
				}
				else if (input == "s")
				{
					if (currentLocation > 0)
					{
						currentLocation -= 1;
						Console.WriteLine(Rooms[currentLocation] + "\n");
					}
					else
					{
						Console.WriteLine("There are no more rooms in this direction\n");
					}
				}
				else if (input == "rooms")
                {
					DisplayList(ref Rooms);
                }
				else if (input == "exit")
                {
					exit = true;
                }
				else
                {
					Console.WriteLine("\nInvalid Choice!\n");
                }
			}
		}


		// Takes in an empty list and the file path and returns the updated list
		public static List<string> OpenFiles(ref List<string> list, string filePath)

		{
			StreamReader reader;
			char delim = ',';

			reader = File.OpenText(filePath);
			while (reader.EndOfStream == false)
			{
				string nameValues = reader.ReadLine();
				string[] tokens = nameValues.Split(delim);

				foreach (string name in tokens)
				{
					list.Add(name);
				}
			}
			reader.Close();

			return list;
		}


		// Iterates through each item in a given list
		public static void DisplayList(ref List<string> list)
		{
			Console.WriteLine();
			foreach (string item in list)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine();
		}

	}
}