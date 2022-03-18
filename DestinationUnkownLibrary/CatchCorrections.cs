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

namespace DestinationUnkownLibrary
{
    // This class will be expanded on to give the user multiple chances to enter in the correct values.
    public class CatchCorrections
    {
        // Prompts the user to enter a username and creates the User_Profile.txt file
        public static string UserNameCreation()
        {
            Console.Write("Please enter in a username: ");
            string userName = Console.ReadLine();
            StreamWriter outputFile = File.CreateText("Game_Data/User_Profile.txt");
            outputFile.WriteLine(userName);
            outputFile.Close();
            return userName;
        }
    }
}
