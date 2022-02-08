/**
* 07FEB22
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
			string[] Rooms = { "hey", "cool" }; // 5
			string[] Weapons = { }; // 4
			string[] Potions = { }; // 2
			string[] Treasures = { }; // 3

			// Lists
			List<string> Items = new List<string>(); // 4
			List<string> Mobs = new List<string>(); // 5

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
				Console.WriteLine("7. Exit");
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
					exit = true;
				}
				else
				{
					Console.WriteLine("Invalid choice!");
				}
			}
		}

		// Iterates through each item in a given array
		public static void DisplayArray(ref string[] arr)
		{

			foreach (string item in arr)
			{
				Console.WriteLine(item);
			}
		}

		// Iterates through each item in a given list
		public static void DisplayList(ref List<string> list)
		{
			foreach (string item in list)
			{
				Console.WriteLine(item);
			}
		}
	}
}