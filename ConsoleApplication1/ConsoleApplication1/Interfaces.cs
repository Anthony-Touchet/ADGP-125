using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using BattleRanks;

namespace Inferances
{
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
        void Attack(Party other);
        void UseItem();
    }
}
