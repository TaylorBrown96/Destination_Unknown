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
	public class Player
	{
		public static List<Player> player = new List<Player>();

		private int _id;
		private string _name;
		private string _password;
		private string _race;
		private string _class;
		private int _hp;
		private int _location;
		private List<int> _inventory;
		private List<string> _quest;

		public Player()
		{
			_id = 0;
			_name = "";
			_password = "";
			_race = "";
			_class = "";
			_hp = 0;
			_location = 0;
			_inventory = new List<int>();
			_quest = new List<string>();
		}

		public Player(int id, string name, string password, string race, string Pclass, int hp, int location, List<int> inventory, List<string> quests)
		{
			_id = id;
			_name = name;
			_password = password;
			_race = race;
			_class = Pclass;
			_hp = hp;
			_location = location;
			_inventory = inventory;
			_quest = quests;
		}

		public int Id { get { return _id; } set { _id = value; } }

		public string Name { get { return _name; } set { _name = value; } }

		public string Password { get { return _password; } set { _password = value; } }

		public string Race { get { return _race; } set { _race = value; } }

		public string Class { get { return _class; } set { _class = value; } }

		public int HP { get { return _hp; } set { _hp = value; } }

		public int Location { get { return _location; } set { _location = value; } }

		public List<int> Inventory { get { return _inventory; } set { _inventory = value; } }

		public List<string> Quest { get { return _quest; } set { _quest = value; } }
	}

	public class Rooms
	{
		public static List<Rooms> Room = new List<Rooms>();

		private int _room_ID;
		private string _name;
		private string _description;
		private List<int> _mobs;
		private List<int> _loot;
		private List<int> _exit;

		public Rooms()
		{
			_room_ID = 0;
			_name = "";
			_description = "";
			_mobs = new List<int>();
			_loot = new List<int>();
			_exit = new List<int>();
		}

		public Rooms(int room_ID, string name, string description, List<int> mobs, List<int> loot, List<int> exits)
		{
			_room_ID = room_ID;
			_name = name;
			_description = description;
			_mobs = mobs;
			_loot = loot;
			_exit = exits;
		}

		public int RoomID { get { return _room_ID; } set { _room_ID = value; } }

		public string Name { get { return _name; } set { _name = value; } }

		public string Description { get { return _description; } set { _description = value; } }

		public List<int> Mobs { get { return _mobs; } set { _mobs = value; } }

		public List<int> Loot { get { return _loot; } set { _loot = value; } }

		public List<int> Exit { get { return _exit; } set { _exit = value; } }
	}

	public class Weapons
	{
		public static List<Weapons> Weapon = new List<Weapons>();

		private int _weaponID;
		private string _name;
		private string _description;
		private string _dmgType;
		private int _price;
		private int _damage;

		public Weapons()
		{
			_weaponID = 0;
			_name = "";
			_description = "";
			_dmgType = "";
			_price = 0;
			_damage = 0;
		}

		public Weapons(int weaponID, string name, string description, string dmgtype, int price, int damage)
		{
			_weaponID = weaponID;
			_name = name;
			_description = description;
			_dmgType = dmgtype;
			_price = price;
			_damage = damage;
		}

		public int WeaponID { get { return _weaponID; } set { _weaponID = value; } }

		public string Name { get { return _name; } set { _name = value; } }

		public string Description { get { return _description; } set { _description = value; } }

		public string DmgType { get { return _dmgType; } set { _dmgType = value; } }

		public int Price { get { return _price; } set { _price = value; } }

		public int Damage { get { return _damage; } set { _damage = value; } }
	}

	public class Potions
	{
		public static List<Potions> Potion = new List<Potions>();

		private int _id;
		private string _name;
		private int _price;
		private int _value;
		private string _description;

		public Potions()
		{
			_id = 0;
			_name = "";
			_price = 0;
			_value = 0;
			_description = "";
		}

		public Potions(int id, string name, int price, int value, string description)
		{
			_id = id;
			_name = name;
			_price = price;
			_value = value;
			_description = description;
		}

		public int Id { get { return _id; } set { _id = value; } }

		public string Name { get { return _name; } set { _name = value; } }

		public int Price { get { return _price; } set { _price = value; } }

		public int Value { get { return _value; } set { _value = value; } }

		public string Description { get { return _description; } set { _description = value; } }
	}

	public class Treasures
	{
		public static List<Treasures> Treasure = new List<Treasures>();

		private int _id;
		private string _name;
		private int _price;
		private bool _questItem;
		private string _description;

		public Treasures()
		{
			_id = 0;
			_name = "";
			_price = 0;
			_questItem = false;
			_description = "";
		}

		public Treasures(int id, string name, int price, bool questItem, string description)
		{
			_id = id; 
			_name = name;
			_price = price;
			_questItem = questItem;
			_description = description;
		}

		public int Id { get { return _id; } set { _id = value; } }

		public string Name { get { return _name; } set { _name = value; } }

		public int Price { get { return _price; } set { _price = value; } }

		public bool QuestItem { get { return _questItem; } set { _questItem = value;} }

		public string Description { get { return _description; } set { _description = value; } }
	}

	public class Items
	{
		public static List<Items> Item = new List<Items>();

		private int _id;
		private string _name;
		private int _price;
		private bool _questItem;
		private bool _required;
		private string _description;

		public Items()
		{
			_id = 0;
			_name = "";
			_price = 0;
			_questItem = false;
			_required = false;
			_description = "";
		}

		public Items(int id, string name, int price, bool questItem, bool required, string description)
		{
			_id = id;
			_name = name;
			_price = price;
			_questItem = questItem;
			_required = required;
			_description = description;
		}

		public int Id { get { return _id; } set { _id = value; } }

		public string Name { get { return _name; } set { _name = value; } }

		public int Price { get { return _price; } set { _price = value; } }

		public bool QuestItem { get { return _questItem; } set { _questItem = value;} }

		public bool Required { get { return _required; } set { _required = value; } }

		public string Description { get { return _description; } set { _description = value; } }
	}

	public class Mobs
	{
		public static List<Mobs> Mob = new List<Mobs>();

		private int _id;
		private string _name;
		private string _race;
		private int _hp;
		private string _weapon;
		private string _description;
		private List<string> _inventory;
		
		public Mobs()
		{
			_id = 0;
			_name = "";
			_race = "";
			_hp = 0;
			_weapon = "";
			_description = "";
			_inventory = new List<string>();
		}

		public Mobs(int id, string name, string race, int hp, string weapon, string description, List<string> inventory)
		{
			_id = id;
			_name = name;
			_race = race;
			_hp = hp;
			_weapon = weapon;
			_description = description;
			_inventory = inventory;
		}

		public int Id { get { return _id; } set { _id = value; } }

		public string Name { get { return _name; } set { _name = value; } }

		public string Race { get { return _race; } set { _race = value; } }

		public int HP { get { return _hp; } set { _hp = value; } }

		public string Weapon { get { return _weapon; } set { _weapon = value; } }

		public List<string> Inventory { get { return _inventory; } set { _inventory = value;} }

		public string Description { get { return _description; } set { _description = value; } }
	}
}
