using System;
using FSM;

namespace FSM_with_Delagates
{
    class Program
    {
        static void Attack()
        {
            Console.WriteLine("Attack");
        }
        static void Use()
        {
            Console.WriteLine("Use");
        }
        static void End()
        {
            Console.WriteLine("End");
        }

        public enum Turns
        {
            WAIT = 0,
            USE = 1,
            ATTACK = 2,
            END = 3,
        }

        static Del a = Attack;
        static Del u = Use;
        static Del e = End;

        static void Main(string[] args)
        {
            FSM<Turns> fsm = new FSM<Turns>(Turns.WAIT);
            fsm.AddState(Turns.USE);
            fsm.AddState(Turns.ATTACK);
            fsm.AddState(Turns.END);
            fsm.AddTransition(Turns.WAIT, Turns.USE, null, u);
            fsm.AddTransition(Turns.USE, Turns.ATTACK, null, a);
            fsm.AddTransition(Turns.ATTACK, Turns.END, null, e);
            fsm.AddTransition(Turns.END, Turns.USE, null, null);

            fsm.SwitchStates(Turns.USE);
            fsm.SwitchStates(Turns.ATTACK);
            fsm.SwitchStates(Turns.END);
            fsm.SwitchStates(Turns.USE);

            Console.ReadLine();
        }
    }
}
