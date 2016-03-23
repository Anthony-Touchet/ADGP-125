using System;
using BattleRanks;
using Inferances;
using Items;
using FSM;
using System.Xml.Serialization;
using System.IO;

namespace GameManager
{
    public delegate GM Transition(IParty other);
    public class GM : IGameManager
    {
        static private GM _instance;        //GM is a Singleton. There should only ever be one.
        static public GM instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GM();
                return _instance;
            }
        }

        Party _goodGuys;    //GM's Good Guys' Party
        Party _badGuys;     //GM's Bad Guys' Party

        public Party badGuys    //Get and set the Bad Guys
        {
            get
            {
                return _badGuys;
            }

            set
            {
                _badGuys = value;
            }
        }

        public Party goodGuys   //Get and set the Good Guys
        {
            get
            {
                return _goodGuys;
            }

            set
            {
                _goodGuys = value;
            }
        }

        public Party CreateParty(Party create, string type) //Function that creates a party for the GM and returns that party.
        {
            for(int c = 0; c < 10; c++)
            {
                Item item = new Item(10, 0, 0, "Potion"); //Units' Items
                Unit temp = new Unit(5 + c, 20 + c, 20 + c, false, type + "Unit" + (c + 1), 0.0, 10.0, 0, item);  //Create instance of the unit
                create.AddUnit(temp);
            }

            return create;
        }

        public TurnStates StartMachine()    //Starts the Machine that is between the Good Guys and the Bad Guys.
        {
            goodGuys.turnHandler.SwitchStates(TurnStates.USE, goodGuys);   //Use is the first action to be done.
            return TurnStates.USE;
        }

        public GM GameControl()     //Controls the Flow of the FSM between the parties
        {
            if (goodGuys.PartyHealth() == true && badGuys.PartyHealth() == true)  //While there is still an alive Unit
            {
                switch (goodGuys.turnHandler.currentState.ToString())   //Takes the state and sees what it is so actions can be done.
                {
                    case "ATTACK":
                        goodGuys.Attack(badGuys);   //One Unit attacking another Unit
                        if (goodGuys.team.IndexOf(goodGuys.currUnit) + 1 == goodGuys.team.Count)   //If Unit is at the End of a party.
                        {
                            goodGuys.currUnit = goodGuys.team[0];               //Next is Begining Unit
                            goodGuys.turnHandler.SwitchStates(TurnStates.END);  //Switch States to end Turn
                            badGuys.turnHandler.SwitchStates(TurnStates.USE);   //Set other FSM to start
                            goodGuys.turnHandler.SwitchStates(TurnStates.WAIT); //Set this FSM to Wait till next turn.
                        }

                        else
                        {
                            goodGuys.currUnit = goodGuys.team[goodGuys.team.IndexOf(goodGuys.currUnit) + 1];    //Set current Unit to the next one in the list
                            goodGuys.turnHandler.SwitchStates(TurnStates.USE);       //Reset this FSM for next Unit
                        }
                        break;

                    case "USE":
                        goodGuys.UseItem();  //Unit uses item on itself
                        goodGuys.turnHandler.SwitchStates(TurnStates.ATTACK, badGuys);
                        break;

                    case "WAIT":    //Can not do anything because it is the other party's turn
                        break;

                    default:
                        break;
                }

                switch (badGuys.turnHandler.currentState.ToString())    //Takes the state and sees what it is so actions can be done.
                {
                    case "ATTACK":
                        badGuys.Attack(goodGuys);   //One Unit attacking another Unit
                        if (badGuys.team.IndexOf(badGuys.currUnit) + 1 == badGuys.team.Count)   //If Unit is at the End of a party.
                        {
                            badGuys.currUnit = badGuys.team[0];             //Next is Begining Unit
                            badGuys.turnHandler.SwitchStates(TurnStates.END);       //Switch States to end Turn
                            goodGuys.turnHandler.SwitchStates(TurnStates.USE);      //Set other FSM to start
                            badGuys.turnHandler.SwitchStates(TurnStates.WAIT);      //Set this FSM to Wait till next turn.
                        }

                        else
                        {
                            badGuys.currUnit = badGuys.team[badGuys.team.IndexOf(badGuys.currUnit) + 1];    //Set current Unit to the next one in the list
                            badGuys.turnHandler.SwitchStates(TurnStates.USE);       //Reset this FSM for next Unit
                        }
                        break;

                    case "USE":
                        badGuys.UseItem();  //Unit uses item on itself
                        badGuys.turnHandler.SwitchStates(TurnStates.ATTACK);
                        break;

                    case "WAIT":    //Can not do anything because it is the other party's turn
                        break;

                    default:
                        break;
                }
            }
            
            return this;
        }
        
        public GM SaveGame()    //Save the Units and the State of the Parties
        { 
            var goodpath = Environment.CurrentDirectory + "/GoodSaveFile.xml";  //Makes the path to GoodSaveFile.xml
            FileStream goodSaveFile = File.Create(goodpath);                    //Actual creation of the path

            XmlSerializer serial = new XmlSerializer(typeof(Party));            //The object that will serialize a Party Object
            serial.Serialize(goodSaveFile, goodGuys);                           //Serializing the Party.
            goodSaveFile.Close();                                               //Close this file.

            var badpath = Environment.CurrentDirectory + "/BadSaveFile.xml";    //Get path for the BadSaveFile.xml
            FileStream badSaveFile = File.Create(badpath);                      //Create that path

            serial = new XmlSerializer(typeof(Party));                          //Reset serializer
            serial.Serialize(badSaveFile, badGuys);                             //Serializing the Party.
            badSaveFile.Close();                                                //Close the BadSaveFile
            return this;
        }

        public GM LoadGame() //Get Those Stats and states Back
        {
            XmlSerializer reader = new XmlSerializer(typeof(Party));    //Object that will read the xml files.

            Party tempgoodGuys = new Party();   //Temp party to hold the GoodGuys
            Party tempbadGuys = new Party();    //Temp party to hold the BadGuys

            StreamReader goodFile = new StreamReader(Environment.CurrentDirectory + "/GoodSaveFile.xml");   //Getting this reader set to the GoodSaveFile
            StreamReader badFile = new StreamReader(Environment.CurrentDirectory + "/BadSaveFile.xml");     //Getting this reader set to the BadSaveFile

            tempgoodGuys = (Party)reader.Deserialize(goodFile);     //Taking the info from GoodSaveFile and turning it back into a Party.
            tempbadGuys = (Party)reader.Deserialize(badFile);       //Taking the info from BadSaveFile and turning it back into a Party.

            goodGuys = tempgoodGuys;    //Setting GoodGuy Party
            badGuys = tempbadGuys;      //Setting BadGuy Party
   
            return this;
        }

        public GM _attack(IParty other)
        {
            
            return this;
        }
    }

    public class BattleLog  //The Holding box for text that will show on the actual text box on this form.
    {
        public string BB = "";
        static private BattleLog _instance;
        static public BattleLog instance
        {
            get
            {
                if (_instance == null)
                {
                    _instance = new BattleLog();
                }
                return _instance;
            }
        }
    }
}