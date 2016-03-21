using System;
using BattleRanks;
using Inferances;
using Items;
using System.Xml;
using System.Windows.Forms;

namespace GameManager
{
    class GM : IGameManager
    {
        static private GM _instance;
        static public GM instance
        {
            get
            {
                if (_instance == null)
                    _instance = new GM();
                return _instance;
            }
        }

        Party _goodGuys;
        Party _badGuys;

        public Party badGuys
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

        public Party goodGuys
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

        public Party CreateParty(Party create, string type)
        {
            for(int c = 0; c < 5; c++)
            {
                Item item = new Item(10, 0, 0, "Potion"); //Units' Items
                Unit temp = new Unit(5 + c, 20 + c, 20 + c, false, type + "Unit" + (c + 1), 0.0, 10.0, 0, item);  //Create instance of the unit
                create.AddUnit(temp);
            }

            return create;
        }

        public Enum StartMachine()
        {
            goodGuys.turnHandler.SwitchStates(Party.TurnStates.USE);   //Use is the first action ever done.
            return Party.TurnStates.USE;
        }

        public GM GameControl()
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
                            goodGuys.turnHandler.currentState = goodGuys.turnHandler.SwitchStates(Party.TurnStates.END);  //Switch States to end Turn
                            badGuys.turnHandler.currentState = badGuys.turnHandler.SwitchStates(Party.TurnStates.USE);   //Set other FSM to start
                            goodGuys.turnHandler.currentState = goodGuys.turnHandler.SwitchStates(Party.TurnStates.WAIT); //Set this FSM to Wait till next turn.
                        }

                        else
                        {
                            goodGuys.currUnit = goodGuys.team[goodGuys.team.IndexOf(goodGuys.currUnit) + 1];    //Set current Unit to the next one in the list
                            goodGuys.turnHandler.currentState = goodGuys.turnHandler.SwitchStates(Party.TurnStates.USE);       //Reset this FSM for next Unit
                        }
                        break;

                    case "USE":
                        goodGuys.UseItem();  //Unit uses item on itself
                        goodGuys.turnHandler.currentState = goodGuys.turnHandler.SwitchStates(Party.TurnStates.ATTACK);
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
                            badGuys.turnHandler.currentState = badGuys.turnHandler.SwitchStates(Party.TurnStates.END);       //Switch States to end Turn
                            goodGuys.turnHandler.currentState = goodGuys.turnHandler.SwitchStates(Party.TurnStates.USE);      //Set other FSM to start
                            badGuys.turnHandler.currentState = badGuys.turnHandler.SwitchStates(Party.TurnStates.WAIT);      //Set this FSM to Wait till next turn.
                        }

                        else
                        {
                            badGuys.currUnit = badGuys.team[badGuys.team.IndexOf(badGuys.currUnit) + 1];    //Set current Unit to the next one in the list
                            badGuys.turnHandler.currentState = badGuys.turnHandler.SwitchStates(Party.TurnStates.USE);       //Reset this FSM for next Unit
                        }
                        break;

                    case "USE":
                        badGuys.UseItem();  //Unit uses item on itself
                        badGuys.turnHandler.currentState = badGuys.turnHandler.SwitchStates(Party.TurnStates.ATTACK);
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
            XmlDocument saveFile = new XmlDocument();
            XmlElement parties = saveFile.CreateElement("Parties");
            XmlElement goodPar = saveFile.CreateElement("goodPar");
            XmlElement badPar = saveFile.CreateElement("badPar");
            //Saving Good Guys
            goodPar.SetAttribute("TurnState", goodGuys.turnHandler.currentState.ToString());    //Good Party's State
            foreach (Unit u in goodGuys.team)
            {
                XmlElement temp = saveFile.CreateElement(u.name);           //Unit to be created
                temp.SetAttribute(u.name, u.name);                          //Unit's Name
                temp.SetAttribute("Maxhealth", u.maxHealth.ToString());     //Unit's Max Health
                temp.SetAttribute("health", u.health.ToString());           //Unit's Health
                temp.SetAttribute("attack", u.attack.ToString());           //Unit's Attack
                temp.SetAttribute("speed", u.speed.ToString());             //Unit's Speed
                temp.SetAttribute("InPar", u.inPar.ToString());             //Unit's In Party
                temp.SetAttribute("CurrEXP", u.currExp.ToString());         //Unit's current EXP
                temp.SetAttribute("MaxEXP", u.maxExp.ToString());           //Unit's Max EXP
                temp.SetAttribute("Level", u.level.ToString());             //Unit's Level
                XmlElement item = saveFile.CreateElement(u.uitem.name);     //Unit's Item
                item.SetAttribute("itemHealth", u.uitem.health.ToString()); //Unit's item's health
                item.SetAttribute("itemAttack", u.uitem.attack.ToString()); //Unit's item's attack
                item.SetAttribute("itemSpeed", u.uitem.speed.ToString());   //Unit's item's speed
                temp.AppendChild(item);     //Add item to Unit.
                goodPar.AppendChild(temp);  //Add Unit to Good Party
            }
            parties.AppendChild(goodPar);  //Add Good party to Parties

            //Saving Bad Guys
            badPar.SetAttribute("TurnState", badGuys.turnHandler.currentState.ToString());    //Bad Party's State
            foreach (Unit u in badGuys.team)
            {
                XmlElement temp = saveFile.CreateElement(u.name);           //Unit to be created
                temp.SetAttribute(u.name, u.name);                          //Unit's Name
                temp.SetAttribute("Maxhealth", u.maxHealth.ToString());     //Unit's Max Health
                temp.SetAttribute("health", u.health.ToString());           //Unit's Health
                temp.SetAttribute("attack", u.attack.ToString());           //Unit's Attack
                temp.SetAttribute("speed", u.speed.ToString());             //Unit's Speed
                temp.SetAttribute("InPar", u.inPar.ToString());             //Unit's In Party
                temp.SetAttribute("CurrEXP", u.currExp.ToString());         //Unit's current EXP
                temp.SetAttribute("MaxEXP", u.maxExp.ToString());           //Unit's Max EXP
                temp.SetAttribute("Level", u.level.ToString());             //Unit's Level
                XmlElement item = saveFile.CreateElement(u.uitem.name);     //Unit's Item
                item.SetAttribute("itemHealth", u.uitem.health.ToString()); //Unit's item's health
                item.SetAttribute("itemAttack", u.uitem.attack.ToString()); //Unit's item's attack
                item.SetAttribute("itemSpeed", u.uitem.speed.ToString());   //Unit's item's speed
                temp.AppendChild(item);     //Add item to Unit.
                badPar.AppendChild(temp);  //Add Unit to Bad Party
            }

            parties.AppendChild(badPar);  //Add Good party to file

            saveFile.AppendChild(parties);
            saveFile.Save("SaveFile.xml");
            return this;
        }

        public GM LoadGame(RichTextBox loadBox) //Get Those Stats and states Back
        {
            XmlDocument loadFile = new XmlDocument();   //Set Instance
            loadFile.Load("SaveFile.xml");              //Set File
            int counter = 0;
            bool partyswitched = false;

            foreach(XmlElement parties in loadFile.SelectNodes("Parties"))    //Iterates over party.
            { 
                foreach(XmlElement party in parties)  //Iterates over each Party
                {   
                    if(partyswitched == false)//If on GoodGuys, first element in Parties
                    {
                        goodGuys.turnHandler.currentState = (Party.TurnStates) Enum.Parse(typeof(Party.TurnStates), party.GetAttribute("TurnState"));
                        partyswitched = true;
                    }

                    else   //Else we on BadGuys, Second party in Parties
                    {
                        badGuys.turnHandler.currentState = (Party.TurnStates)Enum.Parse(typeof(Party.TurnStates), party.GetAttribute("TurnState"));
                    }
                    foreach(XmlElement unit in party)  //Iterates over each Unit
                    {
                        if(counter < goodGuys.team.Count)
                        {
                            goodGuys.team[counter].name = unit.Name;
                            goodGuys.team[counter].maxHealth = int.Parse(unit.GetAttribute("Maxhealth"));
                            goodGuys.team[counter].health = int.Parse(unit.GetAttribute("health"));
                            goodGuys.team[counter].attack = int.Parse(unit.GetAttribute("attack"));
                            goodGuys.team[counter].speed = int.Parse(unit.GetAttribute("speed"));
                            goodGuys.team[counter].currExp = int.Parse(unit.GetAttribute("CurrEXP"));
                            goodGuys.team[counter].maxExp = int.Parse(unit.GetAttribute("MaxEXP"));
                            goodGuys.team[counter].level = int.Parse(unit.GetAttribute("Level"));
                            goodGuys.team[counter].inPar = bool.Parse(unit.GetAttribute("InPar"));
                            foreach(XmlElement i in unit)//Get Unit's item
                            {
                                goodGuys.team[counter].uitem.health = int.Parse(i.GetAttribute("itemHealth"));
                                goodGuys.team[counter].uitem.attack = int.Parse(i.GetAttribute("itemAttack"));
                                goodGuys.team[counter].uitem.speed = int.Parse(i.GetAttribute("itemSpeed"));
                            }
                            loadBox.AppendText(unit.Name + " was loaded\n");
                            counter++;
                        }

                        else
                        {
                            badGuys.team[counter % goodGuys.team.Count].name = unit.Name;
                            badGuys.team[counter % goodGuys.team.Count].maxHealth = int.Parse(unit.GetAttribute("Maxhealth"));
                            badGuys.team[counter % goodGuys.team.Count].health = int.Parse(unit.GetAttribute("health"));
                            badGuys.team[counter % goodGuys.team.Count].attack = int.Parse(unit.GetAttribute("attack"));
                            badGuys.team[counter % goodGuys.team.Count].speed = int.Parse(unit.GetAttribute("speed"));
                            badGuys.team[counter % goodGuys.team.Count].currExp = int.Parse(unit.GetAttribute("CurrEXP"));
                            badGuys.team[counter % goodGuys.team.Count].maxExp = int.Parse(unit.GetAttribute("MaxEXP"));
                            badGuys.team[counter % goodGuys.team.Count].level = int.Parse(unit.GetAttribute("Level"));
                            badGuys.team[counter % goodGuys.team.Count].inPar = bool.Parse(unit.GetAttribute("InPar"));
                            foreach (XmlElement i in unit)//Get Unit's item
                            {
                                badGuys.team[counter % 5].uitem.health = int.Parse(i.GetAttribute("itemHealth"));
                                badGuys.team[counter % 5].uitem.attack = int.Parse(i.GetAttribute("itemAttack"));
                                badGuys.team[counter % 5].uitem.speed = int.Parse(i.GetAttribute("itemSpeed"));
                            }
                            loadBox.AppendText(unit.Name + " was loaded\n");
                        }
                        
                    }
                }
            }
            return this;
        }
    }
}