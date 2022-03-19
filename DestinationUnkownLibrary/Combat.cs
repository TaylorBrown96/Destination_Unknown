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

namespace DestinationUnkownLibrary
{
    // Will add [Block, Heal, Run] methods to class
    public class Combat
    {
        // Takes in an argument of HP and generates a random number between 1-20 to
        // subtract from the total and then returns the new HP value.
        public static int Attack(ref int HP)
        {
            Random rnd = new Random();
            HP -= rnd.Next(1,21);
            return HP;
        }
    }
}
