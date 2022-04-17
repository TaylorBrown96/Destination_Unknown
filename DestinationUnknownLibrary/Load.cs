/**
* 17APR22
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

namespace DestinationUnknownLibrary
{
    public class Load
    {
		public static void Game()
		{
			LoadUser();
			LoadRooms();
			LoadWeapons();
			LoadPotions();
			LoadTreasure();
			LoadItems();
			LoadMobs();
		}


		// Loads User profile
		public static void LoadUser()
        {
			
			try
			{
				List<int> inv = new List<int>();
				List<string> quests = new List<string>();

				int id = 0;
				string name = "";
				string password = "";
				string race = "";
				string Pclass = "";
				int hp = 100;
				int location = 0;


				StreamReader userReader = File.OpenText("Game_Data/User_Profile.csv");
				StreamReader invReader = File.OpenText("Game_Data/User_Inventory.csv");
				StreamReader questReader = File.OpenText("Game_Data/User_Quests.csv");
				
				string line;
				while ((line = userReader.ReadLine()) != null)
				{
					string[] tokens = line.Split(',');

					id = int.Parse(tokens[0]);
					name = tokens[1];
					password = tokens[2];
					race = tokens[3];
					Pclass = tokens[4];
					hp = int.Parse(tokens[5]);
					location = int.Parse(tokens[6]);
				}

				while ((line = invReader.ReadLine()) != null)
				{
					string[] tokens = line.Split(',');

					for (int i = 0; i < tokens.Length; i++)
                    {
						inv.Add(int.Parse(tokens[i]));
                    }
				}

				while ((line = questReader.ReadLine()) != null)
				{
					string[] tokens = line.Split(',');

					for (int i = 0; i < tokens.Length; i++)
					{
						quests.Add(tokens[i]);
					}
				}

				Player.player.Add(new Player(id, name, password, race, Pclass, hp, location, inv, quests));

				userReader.Close();
				invReader.Close();
				questReader.Close();
			}
			catch (Exception)
			{
				int id = 0;

				Console.Write("Please enter a username: ");
				string name = Console.ReadLine();

				bool valid = false;
				string password = "";
				string specialChar = "!@#$%^&*()-_=+[{]};:,<.>/?|`~";
				while (!valid)
				{
					Console.Write("Please enter a password: ");
					password = Console.ReadLine();
					if (!password.Any(char.IsUpper))
					{
						Console.WriteLine("Your password must contain an uppercase letter\n");
						continue;
					}
					else if (!password.Any(char.IsLower))
					{
						Console.WriteLine("Your password must contain a lowercase letter\n");
						continue;
					}
					foreach (char c in specialChar)
                    {
						if (password.Contains(c))
                        {
							valid = true;
                        }
                    }
					if (!valid)
                    {
						Console.WriteLine("Your password must contain a special character\n");
					}
				}

				string race = "";
				valid = false;
				while (!valid)
				{
					Console.WriteLine("\nOptions: Elf, Human, Dwarf, Ogre, and Worgen");
					Console.Write("Please enter in a race: ");
					race = Console.ReadLine();
					switch (race.ToLower())
					{
						case "elf":
							valid = true;
							break;
						case "human":
							valid = true;
							break;
						case "dwarf":
							valid = true;
							break;
						case "ogre":
							valid = true;
							break;
						case "worgen":
							valid = true;
							break;
						default:
							Console.WriteLine("That is not a valid option!");
							continue;
					}
				}

				string Pclass = "";
				valid = false;
				while (!valid)
				{
					Console.WriteLine("\nOptions: Warrior, Hunter, Mage, Rouge, and Shawman");
					Console.Write("Please enter in a class: ");
					Pclass = Console.ReadLine();

					switch (Pclass.ToLower())
                    {
						case "warrior":
							valid = true;
							break;
						case "hunter":
							valid = true;
							break;
						case "mage":
							valid = true;
							break;
						case "rouge":
							valid = true;
							break;
						case "shawman":
							valid = true;
							break;
						default:
							Console.WriteLine("That is not a valid option!");
							continue;
					}
				}
					
				int hp = 100;
				int location = 100;
				List<int> inv = new List<int>() { 200, 300, 302};
				List<string> quests = new List<string>();

				StreamWriter userFile = File.CreateText("Game_Data/User_Profile.csv");
				StreamWriter invFile = File.CreateText("Game_Data/User_Inventory.csv");
				StreamWriter questFile = File.CreateText("Game_Data/User_Quests.csv");
				
				userFile.WriteLine(id + "," + name + "," + password + "," + race + "," + Pclass + "," + hp + "," + location);
				
				for (int i = 0; i < inv.Count; i++)
                {
					invFile.WriteLine(inv[i]);
				}
				questFile.WriteLine();

				userFile.Close();
				invFile.Close();
				questFile.Close();

				

				Player.player.Add(new Player(id, name, password, race, Pclass, hp, location, inv, quests));
			}
		}


		// Loads Rooms
		public static void LoadRooms()
		{
			string line;
			StreamReader room = File.OpenText("Game_Data/Rooms.csv");
			StreamReader room_Mobs = File.OpenText("Game_Data/Room_Mobs.csv");
			StreamReader room_Loot = File.OpenText("Game_Data/Room_Loot.csv");
			while ((line = room.ReadLine()) != null)
			{
				string[] tokens = line.Split(',');
				List<int> mobs = new List<int>();
				List<int> loot = new List<int>();
				List<int> exits = new List<int>();

				int roomID = int.Parse(tokens[0]);
				string name = tokens[1];
				string description = tokens[2];

				int north = int.Parse(tokens[3]);
				int east = int.Parse(tokens[4]);
				int south = int.Parse(tokens[5]);
				int west = int.Parse(tokens[6]);

				exits.Add(north);
				exits.Add(east);
				exits.Add(south);
				exits.Add(west);
				while ((line = room_Mobs.ReadLine()) != null)
				{
					string[] mob = line.Split(',');
					for (int i = 0; i < mob.Length; i++)
					{
						mobs.Add(int.Parse(mob[i]));
					}
					break;
				}
				while ((line = room_Loot.ReadLine()) != null)
				{
					string[] room_loot = line.Split(',');
					for (int i = 0; i < room_loot.Length; i++)
					{
						loot.Add(int.Parse(room_loot[i]));
					}
					break;
				}
				Rooms.Room.Add(new Rooms(roomID, name, description, mobs, loot, exits));
			}
			room.Close();
			room_Mobs.Close();
			room_Loot.Close();
		}


		// Loads Weapons
		public static void LoadWeapons()
		{
			string line;
			StreamReader reader = File.OpenText("Game_Data/Weapons.csv");
			while ((line = reader.ReadLine()) != null)
			{
				string[] tokens = line.Split(',');

				int weaponID = int.Parse(tokens[0]);
				string name = tokens[1];
				string description = tokens[2];
				string dmgType = tokens[3];
				int price = int.Parse(tokens[4]);
				int damage = int.Parse(tokens[5]);

				Weapons.Weapon.Add(new Weapons(weaponID, name, description, dmgType, price, damage));
			}
			reader.Close();
		}


		// Loads Potions
		public static void LoadPotions()
		{
			string line;
			StreamReader reader = File.OpenText("Game_Data/Potions.csv");
			while ((line = reader.ReadLine()) != null)
			{
				string[] tokens = line.Split(',');

				int id = int.Parse(tokens[0]);
				string name = tokens[1];
				int price = int.Parse(tokens[2]);
				int value = int.Parse(tokens[3]);
				string description = tokens[4];

				Potions.Potion.Add(new Potions(id, name, price, value, description));
			}
			reader.Close();
		}


		// Loads Treasures
		public static void LoadTreasure()
		{
			string line;
			StreamReader reader = File.OpenText("Game_Data/Treasures.csv");
			while ((line = reader.ReadLine()) != null)
			{
				string[] tokens = line.Split(',');

				int id = int.Parse(tokens[0]);
				string name = tokens[1];
				int price = int.Parse(tokens[2]);
				bool questItem = bool.Parse(tokens[3]);
				string description = tokens[4];

				Treasures.Treasure.Add(new Treasures(id, name, price, questItem, description));
			}
			reader.Close();
		}


		// Loads Items
		public static void LoadItems()
		{
			string line;
			StreamReader reader = File.OpenText("Game_Data/Items.csv");
			while ((line = reader.ReadLine()) != null)
			{
				string[] tokens = line.Split(',');

				int id = int.Parse(tokens[0]);
				string name = tokens[1];
				int price = int.Parse(tokens[2]);
				bool questItem = bool.Parse(tokens[3]);
				bool required = bool.Parse(tokens[4]);
				string description = tokens[5];

				Items.Item.Add(new Items(id, name, price, questItem, required, description));
			}
			reader.Close();
		}


		// Loads Mobs
		public static void LoadMobs()
		{
			string line;
			StreamReader reader = File.OpenText("Game_Data/Mobs.csv");
			while ((line = reader.ReadLine()) != null)
			{
				string[] tokens = line.Split(',');

				List<string> inv = new List<string>();
				for (int i = 6; i < tokens.Length; i++)
                {
					inv.Add(tokens[i]);
                }

				int id = int.Parse(tokens[0]);
				string name = tokens[1];
				string race = tokens[2];
				int hp = int.Parse(tokens[3]);
				string weapon = tokens[4];
				string description = tokens[5];

				Mobs.Mob.Add(new Mobs(id, name, race, hp, weapon, description, inv));
			}
			reader.Close();
		}
	}
}
