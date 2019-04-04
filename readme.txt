Playtest Update by Joshua Perry

IMPORTANT FOR SHOP - The global currency variable can be accessed by CurrencyScript.currency

List of things I added:

(In scene named Playtest_Scene_Perry)

1. Pause Menu
	a. Script to toggle menu with escape
	b. Restart/Quit buttons also with scripts

2. Win Menu
	a. Script to toggle menu when all parts are collected
	b. Main Menu/Quit buttons with scripts

3. Collectable counter
	a. Added Text component to canvas GameObject in the DayTime System
	b. Added script to text that actively updates currency
	c. right now everything just increments by 1

4. Ship Part UI Component
	a. Added text components to canvas GameObject in the DayTime System
	b. Added scripts to text that change text color from red to green when object is collected
	c. yeah this ui looks crappy for now but we can improve for final

(In scene Game_Menu)

5. Deleted most of the stuff not needed for the menu screen

6. Main menu camera
	a. CCTV Camera game object that is fixed on the water for nice start screen

7. Main Menu
	a. Canvas game object with play/quit buttons built in with scripts 