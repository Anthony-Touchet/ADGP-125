using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleRanks;
using Items;

namespace ConsoleApplication1
{
    class Program   //When Transfered, class that holds this code must be the singleton
    {
        static void Main(string[] args)
        {
            Unit a = new Unit(5, 20, 20, false, "Unit" , 2002.0, 10.0, 0, null);  //Create instance of the unit
            a = CheckLevl(a);
            a = CheckLevl(a);
            a.currExp += 10;
            a = CheckLevl(a);
            Console.ReadLine(); //Pause
        }

        public static Unit CheckLevl(Unit other) //Checks to see if the Unit can increase its level and obtain the stat increases that comes with it.
        {
            int tempLev = other.level;          
            int baseint = 10;       //How much each level will increment by.
            double expCh = 10;      //Changing base change
            double Unused = 0;

            for(int lev = other.level; lev > 1; lev--)
            {
                expCh += baseint;
                Unused = expCh;
            }

            for(expCh = Unused; expCh + baseint  < other.currExp; expCh += baseint)     //Extra EXP
            {
                tempLev++;
                if (tempLev % 3 == 0 || tempLev == 0)   // Level is 0 or Divisable by 3
                {
                    other.maxHealth += 10;    //Increase Max Health by 10
                }

                else if (tempLev % 3 == 1) //if level has a remainder of 1.
                {
                    other.attack += 10;   //Increase Attack by 10
                }

                else if (tempLev % 3 == 2)    //if Level has a remainder of 2
                {
                    other.speed += 10;    //Increase speed by 10
                }
            }

            other.level = tempLev;
            other.health = other.maxHealth;
            Console.WriteLine(other.level);
            return other;
        }
    }
}