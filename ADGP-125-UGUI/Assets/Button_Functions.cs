using UnityEngine;
using UnityEngine.UI;
using BattleRanks;
using GameManager;
using System.Collections.Generic;
using System.Collections;

public class Button_Functions : MonoBehaviour {

    GM gameHandler = GM.instance;                       //Instance of the GM
    List<Unit> attributeShower = new List<Unit>();      //List to show the attribues of each unit within the game
    int listCount = -2;                                 //Controls which unit is selected. Negative one to show first unit.
    public static string batLog = "";

    Text battleTextBox;
    Text ggPhase;
    Text bgPhase;
    Text GPCurrentUnit;
    Text BPCurrentUnit;

    Button saveGame;
    Button loadGame;
    Button nextPhase;
    Button switchButton;
    Button switchButtonReverse;

    Text cuName;
    Text cuHealth;
    Text cuAttack;
    Text cuSpeed;
    Text cuCurExp;
    Text cuLevel;

    void Start () {
        battleTextBox = GameObject.Find("BattleLog").GetComponent<Text>();
        GPCurrentUnit = GameObject.Find("GG CU").GetComponent<Text>();
        BPCurrentUnit = GameObject.Find("BG CU").GetComponent<Text>();
        ggPhase = GameObject.Find("GG Phase").GetComponent<Text>();
        bgPhase = GameObject.Find("BG Phase").GetComponent<Text>();
        cuName = GameObject.Find("CU Name").GetComponent<Text>();
        cuHealth = GameObject.Find("CU Health").GetComponent<Text>();
        cuAttack = GameObject.Find("CU Attack").GetComponent<Text>();
        cuSpeed = GameObject.Find("CU Speed").GetComponent<Text>();
        cuCurExp = GameObject.Find("CU EXP").GetComponent<Text>();
        cuLevel = GameObject.Find("CU Level").GetComponent<Text>();

        saveGame = GameObject.Find("Save Button").GetComponent<Button>();
        loadGame = GameObject.Find("Load Button").GetComponent<Button>();
        nextPhase = GameObject.Find("Next Phase Button").GetComponent<Button>();
        switchButton = GameObject.Find("Switch Button").GetComponent<Button>();
        switchButtonReverse = GameObject.Find("Switch Reverse Button").GetComponent<Button>();
        battleTextBox.gameObject.SetActive(false);   
        nextPhase.gameObject.SetActive(false);         
        saveGame.gameObject.SetActive(false);     
        loadGame.gameObject.SetActive(false);        
        switchButton.gameObject.SetActive(false);
        switchButtonReverse.gameObject.SetActive(false);
    }

    public void nextFSMPhase()
    {
        gameHandler = gameHandler.GameControl();    //Controls the machine
        ggPhase.text = gameHandler.goodGuys.turnHandler.currentState.ToString();    //Shows current phase of Good Guys Party
        bgPhase.text = gameHandler.badGuys.turnHandler.currentState.ToString();     //Shows current phase of Bad Guys Party
        GPCurrentUnit.text = gameHandler.goodGuys.currUnit.name;                    //Shows Current Unit of the Good Party
        BPCurrentUnit.text = gameHandler.badGuys.currUnit.name;                     //SHows Current Unit of the Bad Party

        battleTextBox.text += (Party.BatLog);   //Append Text to RichTextBox
        if (Party.BatLog != "")  //If the TextLog is not empty, add a line space.
        {
            battleTextBox.text += ("\n");
        }
        Party.BatLog = "";        //Clear Singleton's Text
    }

    public void startFSM()   //Starts The FSM, Generates Units, and Turns on Buttons.
    {
        gameHandler.goodGuys = new Party();     //The Good Guys
        gameHandler.badGuys = new Party();      //The Bad Guys
        gameHandler.goodGuys = gameHandler.CreateParty(gameHandler.goodGuys, "Good");   //Creating First Party.
        gameHandler.badGuys = gameHandler.CreateParty(gameHandler.badGuys, "Bad");      //Creating Second Party.

        foreach (Unit u in gameHandler.goodGuys.team)    //Populates the Unit Shower With the Good Guys
        {
            attributeShower.Add(u);
        }

        foreach (Unit u in gameHandler.badGuys.team)    //Populates the Unit Shower with the Bad Guys
        {
            attributeShower.Add(u);
        }

        gameHandler.StartMachine(); //Function that Starts the Machine.
        ggPhase.text = gameHandler.goodGuys.turnHandler.currentState.ToString();    //Displays the name of the Current state the Good Guys are in.
        bgPhase.text = gameHandler.badGuys.turnHandler.currentState.ToString();     //Displays the name of the Current State the Bad Guys are in.
        battleTextBox.text = "";            //Making sure the textbox is Empty
        battleTextBox.text += ("The Units Form their Ranks." + "\n"); //Starting phrase.
        battleTextBox.gameObject.SetActive(true);   //Turns on the Battle Box/Log
        nextPhase.gameObject.SetActive(true);         //Turns on the Next Phase Button
        saveGame.gameObject.SetActive(true);      //Turns on the Save Button
        loadGame.gameObject.SetActive(true);        //Turns on the Load Last Game Button  
        switchButton.gameObject.SetActive(true);
        switchButtonReverse.gameObject.SetActive(true);
    }

    public void switchButton_Click()
    {
        listCount++;    //Enumeration through the list. 

        if (listCount >= attributeShower.Count || listCount < 0)     //If Enumeration is above the capacity of the list.
        {
            listCount = 0;      //Set to 0
        }
        cuName.text = attributeShower[listCount].name;                  //Shows the Unit's name
        cuHealth.text = attributeShower[listCount].health.ToString() + " / " + attributeShower[listCount].maxHealth.ToString(); //Shows the current and max health of the unit.
        cuAttack.text = attributeShower[listCount].attack.ToString();   //Shows the attack power of the Unit
        cuSpeed.text = attributeShower[listCount].speed.ToString();     //Shows the Speed of the Unit
        cuCurExp.text = attributeShower[listCount].currExp.ToString() + " / " + attributeShower[listCount].maxExp.ToString();   //Shows the current exp and the Max EXP of the Unit
        cuLevel.text = attributeShower[listCount].level.ToString();     //Shows the level of the Unit.      
    }

    public void saveButton_Click()   //Saving the state of the Game, Units, and Parties' states.
    {
        gameHandler.SaveGame();
        battleTextBox.text += ("Your Current Game has been Saved!!!!" + "\n");
    }

    public void loadGame_Click()     //Load the States of the last Game that was saved.
    {
        startFSM();    //Restart Game
        battleTextBox.text += ("Game Has Been Loaded." + "\n");   //Say game is loaded
        gameHandler = gameHandler.LoadGame();                       //Load the Game
        ggPhase.text = gameHandler.goodGuys.turnHandler.currentState.ToString();    //Display the current state for Good Guys
        bgPhase.text = gameHandler.badGuys.turnHandler.currentState.ToString();     //Display the State of the Bad Guys

        attributeShower = new List<Unit>();         //Repopulate the Atrribue Shower List.
        foreach (Unit u in gameHandler.goodGuys.team)//The Good Guys from the Load file in Attribute SHower.
        {
            attributeShower.Add(u);
        }

        foreach (Unit u in gameHandler.badGuys.team)//THe Bad guys from the load file in Attribute SHower.
        {
            attributeShower.Add(u);
        }
    }

    public void switchButtonReverse_Click()
    {
        listCount--;        //Enumeration through the list.
        if (listCount < 0)  //If count Ever goes below 0, it's now 0
        {
            listCount = attributeShower.Count - 1;
        }


        cuName.text = attributeShower[listCount].name;                  //Shows the Unit's name
        cuHealth.text = attributeShower[listCount].health.ToString() + " / " + attributeShower[listCount].maxHealth.ToString(); //Shows the current and max health of the unit.
        cuAttack.text = attributeShower[listCount].attack.ToString();   //Shows the attack power of the Unit
        cuSpeed.text = attributeShower[listCount].speed.ToString();     //Shows the Speed of the Unit
        cuCurExp.text = attributeShower[listCount].currExp.ToString() + " / " + attributeShower[listCount].maxExp.ToString();   //Shows the current exp and the Max EXP of the Unit
        cuLevel.text = attributeShower[listCount].level.ToString();     //Shows the level of the Unit.           
    }
}