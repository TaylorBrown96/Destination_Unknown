/**
* 18MAR22
* CSC 153
* Taylor J. Brown
* This program is a maze/rpg text adventure game. 
*/

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DestinationUnknownLibrary;

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

			// Sets all file paths to csv files for each list.
			string roomsFile = "Game_Data/Rooms.csv";
			string weaponsFile = "Game_Data/Weapons.csv";
			string potionsFile = "Game_Data/Potions.csv";
			string treasuresFile = "Game_Data/Treasures.csv";
			string itemsFile = "Game_Data/Items.csv";
			string mobsFile = "Game_Data/Mobs.csv";

			// Opens the file and returns the updated list contents.
			LoadGame.OpenFiles(ref Rooms, roomsFile);
			LoadGame.OpenFiles(ref Weapons, weaponsFile);
			LoadGame.OpenFiles(ref Potions, potionsFile);
			LoadGame.OpenFiles(ref Treasures, treasuresFile);
			LoadGame.OpenFiles(ref Items, itemsFile);
			LoadGame.OpenFiles(ref Mobs, mobsFile);

			// Loads an existing User or prompts the user to create one
			string userName = LoadGame.LoadUser();
			int HP = 100;

			// Initilizes the game after everything has loaded
			Play(ref Rooms, userName, HP);
		}


		// Current game play Method
		public static void Play(ref List<string> Rooms, string userName, int HP)
		{
			int currentLocation = 1; // Defines the starting rooms index
			Console.WriteLine("Hello " + userName + "\n");

			// Prints out all pertinent information about the user
			Console.WriteLine("Your starting HP is: " + HP);
			Console.WriteLine("Your starting room is: " + Rooms[currentLocation]);
			Console.WriteLine("Your starting room index is: " + currentLocation + "\n");


			bool exit = false;
			while (exit == false)
			{
				Console.WriteLine("1. Move North");
				Console.WriteLine("2. Move South");
				Console.WriteLine("3. Attack");
				Console.WriteLine("4. Exit");
				Console.Write("\n>");


				switch (Console.ReadLine()) // Collects the users input and runs it through a switch case
				{
					case "1": // Increases the index of the list and displays the new information
						try 
						{
							currentLocation += 1;
							Console.WriteLine("Room name: " + Rooms[currentLocation]);
							Console.WriteLine("Index of room: " + currentLocation + "\n");
						}
						catch (ArgumentOutOfRangeException)
						{
							Console.WriteLine("There are no more rooms in this direction\n");
							currentLocation = Rooms.Count - 1;
						}
						continue;
					case "2": // Decreases the index of the list and displays the new information
						try
						{
							currentLocation -= 1;
							Console.WriteLine("Room name: " + Rooms[currentLocation]);
							Console.WriteLine("Index of room: " + currentLocation + "\n");
						}
						catch (ArgumentOutOfRangeException)
						{
							Console.WriteLine("There are no more rooms in this direction\n");
							currentLocation = 0;
						}
						continue;
					case "3": // Sends the variable HP to the Combat class and returns the new value
						HP = Combat.Attack(ref HP);
						if (HP > 0)
                        {
							Console.WriteLine("Your current HP is now: " + HP + "\n");
						}
                        else
                        {
							Console.WriteLine("You're dead\n");
							exit = true;
							break;
                        }
						continue;
					case "4": // Terminates the program
						exit = true;
						break;
					default: // Prompts the user of an invalid entry
                        Console.WriteLine("Invalid choice!\n");
						continue;
				}

				Console.WriteLine("Thank you for playing!");
				Console.ReadKey();
			}
		}
	}
}
