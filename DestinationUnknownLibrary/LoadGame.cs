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
using System.IO;

namespace DestinationUnknownLibrary
{
    public class LoadGame
    {
		// Takes in an empty list and the file path and returns the updated list.
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


		// Checks to see if user has created a profile. If not the user is asked to create one.
		public static string LoadUser()
		{
			string userName;
			try
			{
				StreamReader sr = new StreamReader("Game_Data/User_Profile.txt");
				userName = sr.ReadLine();
				sr.Close();
			}
			catch
			{
				userName = CatchCorrections.UserNameCreation();
			}

			return userName;
		}
	}
}
