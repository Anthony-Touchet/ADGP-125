using System;
using System.Collections.Generic;
using BattleRanks;
using FSM;
using GameManager;

namespace Inferances
{
    interface IGameManager
    {
        Party goodGuys { get; set; }
        Party badGuys { get; set; }

        Party CreateParty(Party create, string type);
        Enum StartMachine();

        GM GameControl();
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

        IParty Attack(IParty other);
        Unit UseItem();
    }
}
