RaidTA
Austin Jacobs
Brian Mejia


Quick controls
	Screen 1 
		Click and drag to move functions and link them
		Press "Done" on the bottom right once finished
	Screen 2
		Click on unit buttons then somewhere else to spawn them 
		Edit using "Edit" and the window on the top left 
		Save and Load on the bottom left
		Click "Start Raid" when you are done
	Screen 3
		1-6 to select units
		Left mouse to select where to move / target



In Depth explanations

Screen 1 - Visual Coding
	
	This is a demo of our visual coding system (WIP)
	Currently, the user is not able to create/spawn new functions, so they are given a few to work with
	
	The nodes given were designed for this encounter:
		- Spawn NPC 0 at start
		- If true
			- wait x seconds
			- DamageRaid
			- wait y seconds
			- SpawnSpell 0 at RandomPlayerLocation
			- Go back to the if statement
			
	Feel free to experiment and test your own ideas though!
	
	
	Start()
		This corresponds to Unity's Start() function. Execution from here will start when 
		the encounter begins
	
	Update()
		This corresponds to Unity's Update() function. Execution from here will start each
		frame of the encounter
	
	
	Blue nodes (Execution)
		These nodes control the execution of the program 
		Drag from the right side of one function to the left of another to link them together
		Unlink by dragging from the starting function again
	
	Green nodes (Input/Output)
		These nodes provide information to functions
		An output will only link to an input if the types match
		All functions that have input require a link to function properly
		
	Spell_id and Unit_id
		Currently the CastSpell and SpawnUnit use references to a spell_id and unit_id
		to determine the unit/spell to spawn.
		
		As of now there is only one NPC unit and one spell, so use id 0 for each
		

Screen 2 - Party Customization
	
	This is our party/raid customization screen
	
	Up to 6 units can be in this encounter
	
	It is recommended that you have at least one tank and one healer
	
	Edit units by clicking the Edit button, then the unit you want to edit
	From there its stats can be edited
	
	There is also local saving and loading of parties. Each party is saved
	by inputting the desired save name then clicking Save.
	
	Loading works by inputting the party name and pressing Load.
	
	
Screen 3 - Gameplay
	
	This is the meat of the practice tool
	
	Controls
		Select units using the number keys 1-6
	
		Once selected, use the left mouse button to select either a place to move
		or a target
	
		Units will automatically perform their function once they have a target
	
		DPS/Tank - Attacks current target
		Healer - Heals current target
	
	NPCs
		NPCs work off of a threat/enmity system. Essentially, the more damage or
		healing a unit does, the more threat they generate, with tanks generating
		much more per unit of damage
	
		An NPC will target the unit with the highest threat value
	
	Mechanics
		The spell that spawns, shown by a red circle, will damage all units inside
		for a specified amount
		
		DamageRaid will damage the party for a specified amount
	