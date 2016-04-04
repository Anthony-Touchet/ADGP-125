using System;
using System.Collections.Generic;
using BattleRanks;
using FSM;
using GameManager;

namespace Inferances
{
    public interface IGameManager
    {
        Party goodGuys { get; set; }
        Party badGuys { get; set; }

        Party CreateParty(Party create, string type);
        TurnStates StartMachine();

        GM GameControl();
    }

    public interface IStats
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

    public interface IParty
    {
        List<Unit> team { get; set; }                     //Actual Storage of the Units
        Unit currUnit { get; set; }   //Unit that is currently being used for the party's actions
<<<<<<< HEAD
        FSM<TurnStates> turnHandler { get; set; }
=======

        IParty Attack(IParty other);
        Unit UseItem();
>>>>>>> parent of 782cfae... Small Changes
    }
}
