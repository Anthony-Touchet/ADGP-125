# ADGP-125
Project Description:
	The project is designed to simulate combat between two parties. The parties can have any amount of fighters, and the Units will attack the slowest Unit of the other team. Each Unit will be assigned to a team and will have certain attributes associated with them. These attributes will be explained further on. Lastly, each Unit will have an item that can increase the attributes of the Unit when used. 

Actual Project:
Interfaces:
	IGameManager: This Inference will be used by the GameController class to keep track of the states of the parties and stats of the units of the parties. This Inference will have the following:
Party goodGuys {get; set;} - This will be the first party of the Game. This field will access the Private _goodGuys of the GameManager Class.
Party badGuys {get; set;} - This will be the second party of the Game. This field will access the Private _badGuys of the GameManager Class.

CreateParty
Parameters: Party create, string type
Accessibility type: public
Return Type: Party 
Description:  This function will define what it means to create a party. Taking in which party will be created and the name that each of the Units of that class will be called.

StartMachine
 Parameters: n/a
Accessibility type: public
Return Type: TurnStates 
Description:  This function will define what it means to start the finite state machine. 

GameControl 
Parameters: n/a
Accessibility type: public
Return Type: GM
Description:  This function will define how the machine will transfer between each state.
	
	IStats: This Inference will be used by Units and Items. These fields will access private variables within the class that uses this inference.
Int health {get; set;} - this field will access the currentHealth attribute of the class.
Int attack {get; set;} - this field will access the attack attribute of the class.
Int speed {get; set;} - this field will access the speed attribute of the class.
String name {get; set;} - this field will access the name attribute of the class.

IParty: This inference will be used by the two parties in the program. The fields will access private variables within the class. 
List<Unit> team { get; set; } - This will access the list of Units within the Party.

Unit currUnit { get; set; } - This field will access the current attacking Unit of the party. 

FSM<TurnStates> turnHandler { get; set; } - This field will be used to access the FSM of the Party.

Attack
Parameters: IParty other
Accessibility type: public
Return Type:  IParty
Description: This function will take in the other party and attack it.

UseItem
 Parameters: n/a
Accessibility type: public
Return Type:  Unit 
Description:  This function will use an item on the current Unit. 

BattleRanks:
	TurnStates: These are Enums that will determine what functions and math will be performed. The following states also have the numerical values:
WAIT = 0
USE = 1
ATTACK = 2
END = 3

	Unit: Inheriting from IStats and having the private variables of the fields with _ in front of them. Example: health in inference, _health in Unit class as the private variable. Unit also has the following variables.

maxHealth 
Accessibility type: Public 
Type: int 
Description: this integer will determine how high _health can become.

inPar 
Accessibility type: Public 
Type: bool 
Description: This bool will identify if the Unit is in a party or not.

currExp 
Accessibility type: Public 
Type: double 
Description: this number will identify if the Unit will level up compared to another number.

maxExp 
Accessibility type: Public 
Type: double 
Description: this is the number that currExp will be compared to to determine if the Unit’s level will increase.

level 
Accessibility type: Public 
Type: int 
Description: as this number increases, other attributes associated with the Unit will also increase.

uitem 
Accessibility type: Public 
Type: Item 
Description: this will be the associated item that the unit will carry.

_health 
Accessibility type: Private 
Type: int 
Description: This number will determine if the Unit will be able to continue to fight or not.

_speed 
Accessibility type: Private 
Type: int 
Description: this number will determine when the Unit will attack compared to the rest of their party.

_attack
 Accessibility type: Private 
Type: int 
Description: this is how much health will be subtracted from the Unit this Unit attacks.

_name 
Accessibility type: Private 
Type: string 
Description: This is what the console/program will call this Unit.

	Party: Inheriting from IParty, This class will hold Units and keep track of which state the party is in as well. This class will also write to a string that will store what happened to the Units.
BatLog 
Accessibility type: Public static 
Type: string 
Description: this string will hold all text the class writes out. This text will be transferred between classes.

_turnHandler 
Accessibility type: Private 
Type: FSM<TurnStates> 
Description: this is the FSM that handles the state of the party.(See FSM Class)

_team 
Accessibility type: Private 
Type: List<Unit> 
Description: This is the list of Units that the Party will hold. 

_currUnit 
Accessibility type: Private 
Type: Unit 
Description: This will identify which Unit will attack. THis will change after each turn.

Party 
Parameters: n/a
Accessibility type: Public 
Return Type: Party
Description:  This Constructor will set all the states and transitions of the class.

AddUnit:
Parameters: Unit u
Accessibility type: Public 
Return Type: bool 
Description:  this Function will add the Unit in the Parameters to the List of Units of the Party.

Attack:
Parameters: IParty other
Accessibility type: Public  
Return Type: IParty
Description:  this function will take the stats of the _currUnit and change the Unit of the other IParty with the lowest speed.

PartyHealth:
Parameters: n/a
Accessibility type: Public 
Return Type: bool 
Description:  this will return true if the party has at least one Unit who’s health is greater than zero.

UseItem:
Parameters: n/a
Accessibility type: Public 
Return Type: Unit 
Description:  This function will take the item of the currUnit and add the stats of that item to the Unit. The Item will then set all of it’s stats to zero.

CheckLevl:
Parameters: Unit other
Accessibility type: Public 
Return Type: void 
Description:  This function will check to see if other’s currExp is greater or equal to its maxExp. If so, then other’s level will increase by one and an attribute of other will increase depending on what level other is going to. 

FSM: This class will handle what state the class is in, the current state, and what are valid transitions between all of its states. These Classes will all be templated for Genericism. T will represent the type of the objects.

	Link<T>: This is the transitions of the class. This struct will represent all the valid transitions of this class.

From
Accessibility type: Public 
Type: T 
Description: This is where the transition starts.

to 
Accessibility type: Public
Type: T 
Description: This is where the transition ends.

	FSM<T>: This class is the FSM. THis class stores all valid states and transitions and moves the current state of the FSM by checking against the states and valid transition.

currentState 
Accessibility type: Public  
Type: T
Description: this will be the current state that the program is in.

states 
Accessibility type: Public 
Type: List<T> 
Description: this is the list of all valid states.

trans 
Accessibility type: Public 
Type: List<Link<T>> 
Description: this will be a list of all the valid transitions of the class.

FSM 
Parameters: T state
Accessibility type: Public 
Return Type: FSM
Description: this constructor will set the FSM’s current state to that of the state parameter and add that state as well. 

AddState
Parameters: T state
Accessibility type: Public 
Return Type: bool 
Description: this function will add a state to the list of valid states.

AddTransition: 
Parameters: T from, T to
Accessibility type: Public 
Return Type: bool 
Description: this function will add a valid transition to the list of valid transitions. 

SwitchStates: 
Parameters: T to
Accessibility type: Public 
Return Type: bool 
Description: This will be the only way the current state can change. This function will check a list of valid transitions and change it if the currentState to the to parameter is a valid transition. 

GM: This class will control how the other classes interact with each other and how the states of the parties are defined. Inherits from the IGameManager inference. This class is also a singleton. 
goodGuys 
Accessibility type: private
Type: Party 
Description: this will be the first party.

badGuys 
Accessibility type: private
Type: Party 
Description: this will be the second party

 _instance 
Accessibility type: Static private
Type: GM
Description: this will reference the only existing GM in the program.

instance 
Accessibility type: Static public
Type:GM
Description: the public field for accessing the _instance of the GM class.

CreateParty:
Parameters: Party create, string type
Accessibility type: Public  
Return Type: Party
Description:  this function will create a party for the GM class.

StartMachine
Parameters: n/a
Accessibility type: public
Return Type: TurnStates
Description:  this function will start the FSM of the two parties.

GameControl
Parameters: n/a
Accessibility type: Public
Return Type: GM 
Description:  this function dictates the flow of the states and what each state will do.

SaveGame: 
Parameters: n/a
Accessibility type: public
Return Type: GM
Description: This function will serialize the parties and save them to an outside XML file.

LoadGame:
	Parameters: n/a
	Accessibility type: public
	Return Type: GM 
Description:This will take the outside XML file of the save file and set the parties to these parties.

GUI for Project: The following is a basis of the code that both programs, Windows Forms and Unity GUI, will use. Set up may be different but both will have the same functions. The Parameters and Accessibility are different between Programs, but how the functions act are key. All return types are Void. UGUI for Unity WF for Windows Forms.

nextFSMPhase
		Parameters: UGUI: n/a
		  WF: object sender, EventArgs e
		Accessibility type: UGUI:public
		  WF: Private
		Return Type: void(for both)
Description: This function will perform all the math associated with the FSM, set the FSM text for both parties, set the currUnit for both parties, and reset the cache of text for the BattleLog Text Box.
	
startFSM 
		Parameters: UGUI: n/a
		  WF: object sender, EventArgs e
		Accessibility type: UGUI:public
		  WF: Private
		Return Type: void(for both)
Description: This function will create both parties to begin, then adds all the Units to another list that will show their attributes/stats. THis function will also start the machine, initially change the state text, clear the Battle Box Text, and turn-on/set-active all buttons that are disabled.

switchButton_Click
		Parameters: UGUI: n/a
		  WF: object sender, EventArgs e
		Accessibility type: UGUI:public
		  WF: Private
		Return Type: void(for both)
Description: This function will go iterate down the list of attribueShower populated by the startFSM function. This Function will also change the text that displays the attribute values.

switchButtonReverse_Click
		Parameters: UGUI: n/a
		  WF: object sender, EventArgs e
		Accessibility type: UGUI:public
		  WF: Private
		Return Type: void(for both)
Description: This function will go iterate up the list of attribueShower populated by the startFSM function. This Function will also change the text that displays the attribute values.

saveButton_Click
		Parameters: UGUI: n/a
		  WF: object sender, EventArgs e
		Accessibility type: UGUI:public
		  WF: Private
		Return Type: void(for both)
Description: Calls the SaveGame function of the GM and puts text on the Battle Box that tells the player they have saved their game.

loadGame_Click
		Parameters: UGUI: n/a
		  WF: object sender, EventArgs e
		Accessibility type: UGUI:public
		  WF: Private
		Return Type: void(for both)
Description: this function will reset the game by calling the startFSM function. The program will then tell the user that the program has been saved as well. The GM will then be set to the GM.LoadGame function, and the Phase text will also be reset. Lastly, the AttributeShower list will then be updated by emptying it and adding all valid Units.


Errors with Program:
 Loading then reset Party’s attack order: This problem only occurs when the game is loaded and the current attacking party resets back to the begining order of attacking. This gives the attacking party more chances if their file is loaded. 
Cause: From the data I have collected, it seems that the party will attack on the current, but has no idea where that unit is on the order of the team.
Possible Solution: The program would need to check where the Unit is in the List of Fighters of the party. The program would get their location, set the next current to the next Unit down the list, and proceed. 
