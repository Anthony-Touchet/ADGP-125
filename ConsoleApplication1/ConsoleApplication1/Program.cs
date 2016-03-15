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
            Party goodGuys = new Party();   //First Party
            Party badGuys = new Party();    //Second Party

            Console.WriteLine("How many in each party will you want?");
            string input = Console.ReadLine();
            int num = Convert.ToInt32(input);   //How many Units will be in each party.

            for (int c = 0; c < num; c++)   //Creating Units.
            {
                Item gtitem = new Item(10, 0, 0, "Potion"); //Units' Items
                Item btitem = new Item(10, 0, 0, "Potion");

                Unit gtemp = new Unit(5 + c, 20 + c, 20 + c, false, "Good Unit " + (c + 1), 0.0, 10.0, 0, gtitem);  //Create instance of the unit
                Unit btemp = new Unit(5 + c, 20 + c, 20 + c, false, "Bad Unit " + (c + 1), 0.0, 10.0, 0, btitem);

                goodGuys.AddUnit(gtemp);    //Add unit to the list.
                badGuys.AddUnit(btemp);
            }

            goodGuys.StartMachine();    //Starts the FSMs for Both Parties.

            while(goodGuys.PartyHealth() == true && badGuys.PartyHealth() == true)  //While there is still an alive Unit
            {

                switch (goodGuys.turnHandler.currentState.ToString())   //Takes the state and sees what it is so actions can be done.
                {
                    case "ATTACK":
                        goodGuys.Attack(badGuys);   //One Unit attacking another Unit
                        break;

                    case "USE":
                        goodGuys.UseItem();     //Unit uses item on itself
                        break;

                    case "WAIT":    //Can not do anything because it is the other party's turn
                        break;

                    default:
                        break;
                }

                switch (badGuys.turnHandler.currentState.ToString())    //Takes the state and sees what it is so actions can be done.
                {
                    case "ATTACK":
                        badGuys.Attack(goodGuys);   //One Unit attacking another Unit
                        break;

                    case "USE":
                        badGuys.UseItem();  //Unit uses item on itself
                        break;

                    case "WAIT":    //Can not do anything because it is the other party's turn
                        break;

                    default:
                        break;
                }     
            }

            Console.ReadLine(); //Pause
        }
    }
}
