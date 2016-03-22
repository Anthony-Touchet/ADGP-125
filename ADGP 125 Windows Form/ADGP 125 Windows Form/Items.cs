using Inferances;
using System;

namespace Items
{
    [Serializable]
    public class Item : IStats
    {
        int _health;
        int _attack;
        int _speed;
        string _name;

        public Item()
        {
            
        }

        public Item(int h, int a, int s, string n)
        {
            health = h;
            attack = a;
            speed = s;
            name = n;
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
    }
}
