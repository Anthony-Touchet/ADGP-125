using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleRanks;
using FSM;
using GameManager;

namespace Inferances
{
    interface IGameManager
    { 
        Party goodGuys { get; set; }
        Party badGuys { get; set; }

        Party CreateParty(Party create);
        Enum StartMachine();
    }

    interface IDamageable
    {
        int TakeDamage(IStats other);
    }

    interface IStats
    {
        int health
        {
            get;
            set;
        }

        int attack
        {
            get;
            set;
        }

        int speed
        {
            get;
            set;
        }

        string name
        {
            get;
            set;
        }
    }

    interface IParty
    {
        List<Unit> team { get; set; }                     //Actual Storage of the Units
        FSM<Enum> turnHandler { get; set; }  //Finite State Machine that determines which actions the Party will preform with the Units.
        Unit currUnit { get; set; }   //Unit that is currently being used for the party's actions

        void Attack(IParty other);
        void UseItem();
    }
}
