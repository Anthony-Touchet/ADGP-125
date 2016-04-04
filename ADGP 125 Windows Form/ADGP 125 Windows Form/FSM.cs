using System;
using System.Collections.Generic;
<<<<<<< HEAD
using Inferances;
=======
>>>>>>> parent of 782cfae... Small Changes

namespace FSM
{
    public delegate IParty transition(IParty otherPar);

    [Serializable]
    public class FSM<T>   //Finite State Machine.
    {
<<<<<<< HEAD
        [Serializable]
        public struct Link     //Item that holds the transition. THis is a single transition.
        {
            public State from;
            public State to;
        }

        [Serializable]
        public class State
        {
            public T state;
            public transition delag;

            public State(T s, transition d)
            {
                state = s;
                delag = d;
            }
        }

        public State currentState;  //Current State of the FSM
        public List<State> states;
        public List<Link> trans;
=======
        public T currentState;  //Current State of the FSM
        public List<T> states;
        public List<Link<T>> trans;
>>>>>>> parent of 782cfae... Small Changes

        public FSM()
        {

        }

        public FSM(T state)         //Constructor
        {
            states = new List<State>();
            trans = new List<Link>();
            currentState = new State(state, null);
            AddState(state, null);
        }

        public bool AddState(T addingState, transition d)   //Adding a State to the FSM
        {
            State tempState = new State(addingState, d);

            foreach (State s in states)
            {
                if (s.state.ToString() == tempState.state.ToString())
                {
                    return false;
                }
            }

            //Does not have this state.
            states.Add(tempState);   //Adds state to Dictonary as a Key with a blank set of Transitions.
            return true;
        }

        public bool AddTransition(T from, T to) //Add a Transition to the key/state the player is from.
        {
            Link temp = new Link();   //Setting up a temp transition variable

            foreach (State s in states)
            {
                if (s.state.ToString() == from.ToString())
                {
                    temp.from = s;
                }

                if (s.state.ToString() == to.ToString())
                {
                    temp.to = s;
                }
            }

            if (trans.Contains(temp))  //Does this key/state already have this transition?
            {
                //If the transition Exists.
                return false;
            }

            trans.Add(temp);   //Add transition to the list of transitions for that state/key
            return true;
        }

        public T SwitchStates(T to, IParty op)  //Changing the current state of a FSM to another state
        {
            Link temp = new Link();   //Set up temp variable
            temp.from = currentState;
            foreach (State s in states)
            {
                if (s.state.ToString() == to.ToString())
                {
                    temp.to = s;
                }
            }

            foreach (Link l in trans)  //Check Transitions for this State/Key
            {
                if (l.to.state.ToString() == temp.to.state.ToString()) //If Transition Exists, 
                {
                    this.currentState = l.to; //Current State equals the next state 
                    if(currentState.delag != null)
                    {
                        currentState.delag.Invoke(op);
                    }
                    return currentState.state;
                }
            }
            return currentState.state;   //Invalid Transition
        }

        public void Print()
        {
            foreach (State s in states)
            {
                Console.WriteLine(s.state.ToString());
            }

            foreach (Link l in trans)
            {
                Console.WriteLine(l.from.state.ToString() + " -> " + l.to.state.ToString());
            }
        }
    }
}