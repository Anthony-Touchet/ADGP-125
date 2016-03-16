using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BattleRanks;
using Items;
using GameManager;

namespace ADGP_125_Form
{
    public class BattleLog
    {
        public RichTextBox BB = new RichTextBox();
        static private BattleLog _instance;
        static public BattleLog instance{
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

    enum TurnStates  //States for the Party
    {
        WAIT = 0,   //Party will do nothing while in this state
        USE = 1,    //Party will use an item on the current Unit at this state
        ATTACK = 2, //Party will attack with the current Unit at this state
        END = 3,    //Signals When the party will change current Units.
    }

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
            ggPhase.Text = gameHandler.goodGuys.turnHandler.currentState.ToString();
            bgPhase.Text = gameHandler.badGuys.turnHandler.currentState.ToString();
            battleTextBox.AppendText(batLog.BB.Text);
            batLog.BB.Text = "";
        }

        private void startFSM(object sender, EventArgs e)
        {
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
            battleTextBox.AppendText("The Units Form their Ranks.");
        }

        private void switchButton_Click(object sender, EventArgs e)
        {
            if(listCount < 0)
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
            if(listCount >= attributeShower.Count)
            {
                listCount = 0;
            }
        }
    }
}
