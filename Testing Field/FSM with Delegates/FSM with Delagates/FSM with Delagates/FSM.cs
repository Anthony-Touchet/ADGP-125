using System;
using System.Collections.Generic;
using System.Windows;


namespace FSM
{
    [Serializable]
    public class FSM <T>   //Finite State Machine.
    {
        [Serializable]
        internal class Link<T>      //Item that holds the transition. THis is a single transition.
        {
            public T from;
            public T to;
            public Delegate del;

        }

        public T currentState;  //Current State of the FSM
        private List<T> states;
        private List<Link<T>> trans;
     
        public FSM()
        {

        }

        public FSM(T state)         //Constructor
        {
            states = new List<T>();
            trans = new List<Link<T>>();
            AddState(state);
            currentState = state;                       //Setting the current state to start on.
        }

        public bool AddState(T state)   //Adding a State to the FSM
        {
            if (states.Contains(state))    //Does this FSM already have this state?
            {
                //Has state
                return false;
            }

            //Does not have this state.
            states.Add(state);   //Adds state to Dictonary as a Key with a blank set of Transitions.
            return true;
        }

        public bool AddTransition(T from, T to, Delegate d) //Add a Transition to the key/state the player is from.
        {
            Link<T> temp = new Link<T>();   //Setting up a temp transition variable
            temp.from = from;
            temp.to = to;
            temp.del = d;  
                
            if (trans.Contains(temp))  //Does this key/state already have this transition?
            {
                //If the transition Exists.
                return false;
            }          

            trans.Add(temp);   //Add transition to the list of transitions for that state/key
            return true;
        }

        public T SwitchStates(T to)  //Changing the current state of a FSM to another state
        {
            Link<T> temp = new Link<T>();   //Set up temp variable
            temp.from = this.currentState;  //Coming from the current state
            temp.to = to;

            foreach (Link<T> l in trans)  //Check Transitions for this State/Key
            {
                if (l.Equals(temp)) //If Transition Exists, 
                {
                    this.currentState = l.to; //Current State equals the next state
                    if(l.del != null)
                    {
                        l.del.DynamicInvoke();
                    }
                    
                    return currentState;
                }
            }
            return currentState;   //Invalid Transition
        }
    }
}