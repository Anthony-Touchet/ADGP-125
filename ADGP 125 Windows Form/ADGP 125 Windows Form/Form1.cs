using System;
using System.Collections.Generic;
using System.Windows.Forms;
using BattleRanks;
using GameManager;

namespace ADGP_125_Form
{
    public partial class Form1 : Form
    {     
        GM gameHandler = GM.instance;
        List<Unit> attributeShower = new List<Unit>();
        int listCount = -1;
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
                
            battleTextBox.AppendText(Party.BatLog.BB.Text);   //Append Text to RichTextBox
            if(Party.BatLog.BB.Text != "")  //If the TextLog is not empty, add a line space.
            {
                battleTextBox.AppendText("\n");
            }
            Party.BatLog.BB.Text = "";        //Clear Singleton's Text
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
            bgPhase.Text = gameHandler.badGuys.turnHandler.currentState.ToString();
            battleTextBox.Text = "";
            battleTextBox.AppendText("The Units Form their Ranks." + "\n");
            battleTextBox.Visible = true;
            button1.Visible = true;
            saveButton.Visible = true;
            loadGame.Visible = true;
            loadBox.Visible = true;
        }

        private void switchButton_Click(object sender, EventArgs e)
        {
                if (listCount < 0)
                {
                    listCount = 0;
                }
                cuName.Text = attributeShower[listCount].name;
                cuHealth.Text = attributeShower[listCount].health.ToString() + " / " + attributeShower[listCount].maxHealth.ToString();
                cuAttack.Text = attributeShower[listCount].attack.ToString();
                cuSpeed.Text = attributeShower[listCount].speed.ToString();
                cuCurExp.Text = attributeShower[listCount].currExp.ToString() + " / " + attributeShower[listCount].maxExp.ToString();
                cuLevel.Text = attributeShower[listCount].level.ToString();

                listCount++;
                if (listCount >= attributeShower.Count)
                {
                    listCount = 0;
                }
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            gameHandler.SaveGame();
        }

        private void loadGame_Click(object sender, EventArgs e)
        {
            startFSM(sender, e);
            gameHandler = gameHandler.LoadGame(loadBox);
            ggPhase.Text = gameHandler.goodGuys.turnHandler.currentState.ToString();
            bgPhase.Text = gameHandler.badGuys.turnHandler.currentState.ToString();

            attributeShower = new List<Unit>();
            foreach(Unit u in gameHandler.goodGuys.team)
            {
                attributeShower.Add(u);
            }

            foreach (Unit u in gameHandler.badGuys.team)
            {
                attributeShower.Add(u);
            }
        }
    }

    public class BattleLog
    {
        public RichTextBox BB = new RichTextBox();
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
