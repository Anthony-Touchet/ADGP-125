using System;
using System.Collections.Generic;

namespace FSM
{
    struct Link<T>      //Item that holds the transition. THis is a single transition.
    {
        public T from;
        public T to;
    }

    class FSM <T>   //Finite State Machine.
    {
        public T currentState;                      //Current State of the FSM
        private Dictionary<T, List<Link<T>>> dict;  //Dictonary holding the States(Key) and the list of transitions it can have(Value).

        public FSM(T state)         //Constructor
        {
            dict = new Dictionary<T, List<Link<T>>>();  //Giving directory space in memory.
            AddState(state);
            currentState = state;                       //Setting the current state to start on.
        }

        public bool AddState(T state)   //Adding a State to the FSM
        {
            if (dict.ContainsKey(state))    //Does this FSM already have this state?
            {
                //Has state
                return false;
            }

            //Does not have this state.
            dict.Add(state, new List<Link<T>>());   //Adds state to Dictonary as a Key with a blank set of Transitions.
            return true;
        }

        public bool AddTransition(T from, T to) //Add a Transition to the key/state the player is from.
        {
            Link<T> temp = new Link<T>();   //Setting up a temp transition variable
            temp.from = from;
            temp.to = to;     
                
            if (dict[from].Contains(temp))  //Does this key/state already have this transition?
            {
                //If the transition Exists.
                return false;
            }          

            dict[from].Add(temp);   //Add transition to the list of transitions for that state/key
            return true;
        }

        public void Print() //Print out the FSM's states with its valid transitions
        {
            Console.WriteLine("The states are:");
            int count = 0;
            foreach (T key in dict.Keys)    //Prints the keys
            {
                Console.WriteLine("State " + count + " : " + key.ToString());
                Console.WriteLine("The valid Transitions for this state are: ");
                foreach (Link<T> value in dict[key])    //Prints the transitions
                {
                    Console.WriteLine(value.from.ToString() + " to " + value.to.ToString());
                }
                Console.WriteLine(" ");
                count++;    //Counts what the state's index is.
            }
        }

        public T SwitchStates(T to)  //Changing the current state of a FSM to another state
        {
            Link<T> temp = new Link<T>();   //Set up temp variable
            temp.from = this.currentState;  //Coming from the current state
            temp.to = to;

            foreach (Link<T> l in dict[currentState])  //Check Transitions for this State/Key
            {
                if (l.Equals(temp)) //If Transition Exists, 
                {
                    this.currentState = l.to; //Current State equals the next state
                    return currentState;
                }
            }
            return currentState;   //Invalid Transition
        }
    }
}