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
            ggPhase.Text = gameHandler.goodGuys.turnHandler.currentState.ToString();
            bgPhase.Text = gameHandler.badGuys.turnHandler.currentState.ToString();
            gameHandler = gameHandler.GameControl();    //Controls the machine    
            battleTextBox.AppendText(Party.BatLog.BB.Text);   //Append Text to RichTextBox
            if(Party.BatLog.BB.Text != "")
            {
                battleTextBox.AppendText("\n");
            }
            Party.BatLog.BB.Text = "";        //Clear Singleton's Text
        }

        private void startFSM(object sender, EventArgs e)
        {
            gameHandler.goodGuys = new Party();
            gameHandler.badGuys = new Party();
            gameHandler.goodGuys = gameHandler.CreateParty(gameHandler.goodGuys, "Good");//First Party
            gameHandler.badGuys = gameHandler.CreateParty(gameHandler.badGuys, "Bad");//Second Party

            foreach(Unit u in gameHandler.goodGuys.team)
            {
                attributeShower.Add(u);
            }

            foreach (Unit u in gameHandler.badGuys.team)
            {
                attributeShower.Add(u);
            }

            gameHandler.goodGuys.turnHandler.currentState = gameHandler.StartMachine();
            ggPhase.Text = gameHandler.goodGuys.turnHandler.currentState.ToString();
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
