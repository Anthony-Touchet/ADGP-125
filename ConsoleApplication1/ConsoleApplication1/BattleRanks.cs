using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Inferances;
using FSM;

namespace BattleRanks
{
    class Unit : IStats
    {
        public int maxHealth;
        int _health;
        int _attack;
        int _speed;
        bool _inPar;
        string _name;
        double _currExp;
        double _maxExp;
        int _level;

        Unit(int a, int h, int s, bool iP, string n, double cEx, double mEx, int l)
        {
            attack = a;
            health = h;
            maxHealth = h;
            speed = s;
            inPar = iP;
            name = n;
            currExp = cEx;
            maxExp = mEx;
            level = l;
        }

        public int health
        {
            get
            {
                return _health;
            }

            set
            {
                _health = value;
            }
        }

        public int attack
        {
            get
            {
                return _attack;
            }

            set
            {
                _attack = value;
            }
        }

        public int speed
        {
            get
            {
                return _speed;
            }

            set
            {
                _speed = value;
            }
        }

        public bool inPar
        {
            get
            {
                return inPar;
            }

            set
            {
                _inPar = value;
            }
        }

        public string name
        {
            get
            {
                return _name;
            }

            set
            {
                _name = value;
            }
        }

        public double currExp
        {
            get
            {
                return _currExp;
            }

            set
            {
                _currExp = value;
            }
        }

        public double maxExp
        {
            get
            {
                return _maxExp;
            }

            set
            {
                _maxExp = value;
            }
        }

        public int level
        {
            get
            {
                return _level;
            }

            set
            {
                _level = value;
            }
        }

        public void CheckLevl()
        {
            if(currExp >= maxExp)
            {
                currExp = 0;
                maxExp = maxExp * 1.1;
                level++;
            }
        }
    }

    class Party : IAttack
    {
        List<Unit> team = new List<Unit>();
        FSM<Enum> turnHandler = new FSM<Enum>(TurnStates.WAIT);
        Unit currUnit;

        enum TurnStates
        {
            WAIT = 0,
            USE = 1,
            ATTACK = 2,
            END = 3,
        }

        Party()
        {
            turnHandler.AddState(TurnStates.USE);
            turnHandler.AddState(TurnStates.ATTACK);
            turnHandler.AddState(TurnStates.END);
            turnHandler.AddTransition(TurnStates.WAIT, TurnStates.USE);
            turnHandler.AddTransition(TurnStates.USE, TurnStates.ATTACK);
            turnHandler.AddTransition(TurnStates.ATTACK, TurnStates.USE);
            turnHandler.AddTransition(TurnStates.ATTACK, TurnStates.END);
            turnHandler.AddTransition(TurnStates.END, TurnStates.USE);
            turnHandler.AddTransition(TurnStates.END, TurnStates.WAIT);
        }

        public void Attack(Party other)
        {
            turnHandler.SwitchStates(TurnStates.ATTACK);    //Sets State to Attack
            team = team.OrderByDescending(o => o.speed).ToList();   //Sorts List by highest to lowest speed
            currUnit = team[0];

            for (int a = 0; a < other.team.Count; a++)  //Getting a target
            {
                if (other.team[team.Count - 1].health > 0)         //Does it have health.
                {
                    other.team[team.Count - 1].health -= currUnit.attack;
                    Console.WriteLine(currUnit.name + " attacks " + other.team[team.Count - 1].name);
                    Console.WriteLine(other.team[team.Count - 1].name + "'s health is now " + other.team[team.Count - 1].health);
                    break;
                }
            }

            if (team.IndexOf(currUnit) + 1 == team.Count)
            {
                currUnit = team[0];
            }

            else
            {
                currUnit = team[team.IndexOf(currUnit) + 1];
            }

            turnHandler.SwitchStates(TurnStates.END);
        }
    }
}
