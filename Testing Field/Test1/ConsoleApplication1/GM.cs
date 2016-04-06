using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleRanks;
using Inferances;
using Items;

namespace GameManager
{
    class GM : IGameManager
    {
        enum TurnStates  //States for the Party
        {
            WAIT = 0,   //Party will do nothing while in this state
            USE = 1,    //Party will use an item on the current Unit at this state
            ATTACK = 2, //Party will attack with the current Unit at this state
            END = 3,    //Signals When the party will change current Units.
        }

        static private GM _instance;
        static public GM instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GM();
                return _instance;
            }
        }

        Party _goodGuys = new Party();
        Party _badGuys = new Party();

        public Party badGuys
        {
            get
            {
                return _badGuys;
            }

            set
            {
                _badGuys = value;
            }
        }

        public Party goodGuys
        {
            get
            {
                return _goodGuys;
            }

            set
            {
                _goodGuys = value;
            }
        }

        public Party CreateParty(Party create)
        {
            for(int c = 0; c < 5; c++)
            {
                Item item = new Item(10, 0, 0, "Potion"); //Units' Items
                Unit temp = new Unit(5 + c, 20 + c, 20 + c, false, "Good Unit " + (c + 1), 0.0, 10.0, 0, item);  //Create instance of the unit
                create.AddUnit(temp);
            }

            return create;
        }

        public Enum StartMachine()
        {
            goodGuys.turnHandler.SwitchStates(TurnStates.USE);   //Use is the first action ever done.
            return TurnStates.USE;
        }
    }
}
