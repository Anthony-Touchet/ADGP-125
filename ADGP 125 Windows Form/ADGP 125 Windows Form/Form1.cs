using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BattleRanks;
using GameManager;

namespace ADGP_125_Form
{
    public partial class Form1 : Form
    {     
        GM gameHandler = GM.instance;                       //Instance of the GM
        List<Unit> attributeShower = new List<Unit>();      //List to show the attribues of each unit within the game
        int listCount = -2;                                 //Controls which unit is selected. Negative one to show first unit.
        public static BattleLog batLog = new BattleLog();

        public Form1()
        {
            InitializeComponent();
        }

        private void nextFSMPhase(object sender, EventArgs e)
        {
            gameHandler = gameHandler.GameControl();    //Controls the machine
            ggPhase.Text = gameHandler.goodGuys.turnHandler.currentState.ToString();    //Shows current phase of Good Guys Party
            bgPhase.Text = gameHandler.badGuys.turnHandler.currentState.ToString();     //Shows current phase of Bad Guys Party
            GPCurrentUnit.Text = gameHandler.goodGuys.currUnit.name;                    //Shows Current Unit of the Good Party
            BPCurrentUnit.Text = gameHandler.badGuys.currUnit.name;                     //SHows Current Unit of the Bad Party
                
            battleTextBox.AppendText(Party.BatLog.BB);   //Append Text to RichTextBox
            if(Party.BatLog.BB != "")  //If the TextLog is not empty, add a line space.
            {
                battleTextBox.AppendText("\n");
            }
            Party.BatLog.BB = "";        //Clear Singleton's Text
        }

        private void startFSM(object sender, EventArgs e)   //Starts The FSM, Generates Units, and Turns on Buttons.
        {
            gameHandler.goodGuys = new Party();     //The Good Guys
            gameHandler.badGuys = new Party();      //The Bad Guys
            gameHandler.goodGuys = gameHandler.CreateParty(gameHandler.goodGuys, "Good");   //Creating First Party.
            gameHandler.badGuys = gameHandler.CreateParty(gameHandler.badGuys, "Bad");      //Creating Second Party.

            foreach(Unit u in gameHandler.goodGuys.team)    //Populates the Unit Shower With the Good Guys
            {
                attributeShower.Add(u);
            }

            foreach (Unit u in gameHandler.badGuys.team)    //Populates the Unit Shower with the Bad Guys
            {
                attributeShower.Add(u);
            }

            gameHandler.goodGuys.turnHandler.currentState = gameHandler.StartMachine(); //Function that Starts the Machine.
            ggPhase.Text = gameHandler.goodGuys.turnHandler.currentState.ToString();    //Displays the name of the Current state the Good Guys are in.
            bgPhase.Text = gameHandler.badGuys.turnHandler.currentState.ToString();     //Displays the name of the Current State the Bad Guys are in.
            battleTextBox.Text = "";            //Making sure the textbox is Empty
            battleTextBox.AppendText("The Units Form their Ranks." + "\n"); //Starting phrase.
            battleTextBox.Visible = true;   //Turns on the Battle Box/Log
            button1.Visible = true;         //Turns on the Next Phase Button
            saveButton.Visible = true;      //Turns on the Save Button
            loadGame.Visible = true;        //Turns on the Load Last Game Button  
            switchButton.Visible = true;
            switchButtonReverse.Visible = true;
        }

        private void switchButton_Click(object sender, EventArgs e)
        {
            listCount++;    //Enumeration through the list. 
             
            if (listCount >= attributeShower.Count || listCount < 0)     //If Enumeration is above the capacity of the list.
            {
                listCount = 0;      //Set to 0
            }
            cuName.Text = attributeShower[listCount].name;                  //Shows the Unit's name
            cuHealth.Text = attributeShower[listCount].health.ToString() + " / " + attributeShower[listCount].maxHealth.ToString(); //Shows the current and max health of the unit.
            cuAttack.Text = attributeShower[listCount].attack.ToString();   //Shows the attack power of the Unit
            cuSpeed.Text = attributeShower[listCount].speed.ToString();     //Shows the Speed of the Unit
            cuCurExp.Text = attributeShower[listCount].currExp.ToString() + " / " + attributeShower[listCount].maxExp.ToString();   //Shows the current exp and the Max EXP of the Unit
            cuLevel.Text = attributeShower[listCount].level.ToString();     //Shows the level of the Unit.      
        }

        private void saveButton_Click(object sender, EventArgs e)   //Saving the state of the Game, Units, and Parties' states.
        {
            gameHandler.SaveGame();
        }

        private void loadGame_Click(object sender, EventArgs e)     //Load the States of the last Game that was saved.
        {
            startFSM(sender, e);    //Restart Game
            battleTextBox.AppendText("Game Has Been Loaded." + "\n");   //Say game is loaded
            gameHandler = gameHandler.LoadGame();                       //Load the Game
            ggPhase.Text = gameHandler.goodGuys.turnHandler.currentState.ToString();    //Display the current state for Good Guys
            bgPhase.Text = gameHandler.badGuys.turnHandler.currentState.ToString();     //Display the State of the Bad Guys

            attributeShower = new List<Unit>();         //Repopulate the Atrribue Shower List.
            foreach(Unit u in gameHandler.goodGuys.team)//The Good Guys from the Load file in Attribute SHower.
            {
                attributeShower.Add(u);
            }

            foreach (Unit u in gameHandler.badGuys.team)//THe Bad guys from the load file in Attribute SHower.
            {
                attributeShower.Add(u);
            }
        }

        private void switchButtonReverse_Click(object sender, EventArgs e)
        {
            listCount--;    //Enumeration through the list.
            if (listCount < 0)  //If count Ever goes below 0, it's now 0
            {
                listCount = attributeShower.Count - 1;
            }

            
            cuName.Text = attributeShower[listCount].name;                  //Shows the Unit's name
            cuHealth.Text = attributeShower[listCount].health.ToString() + " / " + attributeShower[listCount].maxHealth.ToString(); //Shows the current and max health of the unit.
            cuAttack.Text = attributeShower[listCount].attack.ToString();   //Shows the attack power of the Unit
            cuSpeed.Text = attributeShower[listCount].speed.ToString();     //Shows the Speed of the Unit
            cuCurExp.Text = attributeShower[listCount].currExp.ToString() + " / " + attributeShower[listCount].maxExp.ToString();   //Shows the current exp and the Max EXP of the Unit
            cuLevel.Text = attributeShower[listCount].level.ToString();     //Shows the level of the Unit.           
        }
    }   
}
