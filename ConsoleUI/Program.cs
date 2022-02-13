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

namespace ConsoleUI
{
	internal class Program
	{
		static void Main(string[] args)
		{
			// Arrays
			string[] Rooms = { "Kitchen", "Living Room", "Bathroom", "Garage", "Back Deck" }; // 5
			string[] Weapons = { "Broad sword", "Dagger", "Butter Knife", "Machine Gun" }; // 4
			string[] Potions = { "Large Health Potion", "Mana Potion" }; // 2
			string[] Treasures = { "Golden Trophy", "Giant Diamond", "Fancy Heirloom" }; // 3


			// Lists
			List<string> Items = new List<string>(); // 4
			string[] RangItems = { "Small Wallet", "Pencil", "Notepad", "Map" };
			Items.AddRange(RangItems);

			List<string> Mobs = new List<string>(); // 5
			string[] RangMobs= { "Necromancer", "Golem", "Mimic", "A.I Soldier", "General" };
			Mobs.AddRange(RangMobs);


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
					DisplayArray(ref Rooms);
				}
				else if (input == "2")
				{
					DisplayArray(ref Weapons);
				}
				else if (input == "3")
				{
					DisplayArray(ref Potions);
				}
				else if (input == "4")
				{
					DisplayArray(ref Treasures);
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
		public static void TestPlay(ref string[] Rooms)
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
					DisplayArray(ref Rooms);
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

		// Iterates through each item in a given array
		public static void DisplayArray(ref string[] arr)
		{
			Console.WriteLine();
			foreach (string item in arr)
			{
				Console.WriteLine(item);
			}
			Console.WriteLine();
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