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

        bool inPar
        {
            get;
            set;
        }

        string name
        {
            get;
            set;
        }

        double currExp
        {
            get;
            set;
        }

        double maxExp
        {
            get;
            set;
        }

        int level
        {
            get;
            set;
        }

        void CheckLevl();
    }

    interface IAttack
    {
        void Attack(Party other);
    }
}
