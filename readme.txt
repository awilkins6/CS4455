•	Created a scene called Joshua_Final_Scene

•	Added an Images folder for UI Images (Moon Stone, Ship Parts)

•	Edited currencyText in CurrencyScript to get rid of “Moon Stones “ text

•	Changed GameManagerScript2 UpdateParts() method to display green “X” only when part is collected, disable text otherwise (hide it)

•	Removed animator from wrench parent GameObject to fix the animation glitch (this way it only grows/shrinks when the player is near it)

•	Changed around speed/object location for debugging

•	Added Images to UI canvas for ship parts and moon stone sprites

•	Changed x positions of currency text UI and ship part text UI to make room for images

•	Changed radii of both parent and child colliders for some ship parts to increase range

•	Changed CollectableProximity script to have “magnet” behavior for moonstones

•	Created PartProximity script so that ship parts still have old animation behavior
	o	Removed CollectableProximity on ship parts and replaced with PartProximity

•	Added player jump sound to player controller script and accompanying audio source to playernewcontrols

•	Added five Audio Sources to GameManager. These sounds were added by using static Booleans and static methods to trigger the event in other scripts(found that I had to do it this way)
	o	Game Music that pauses when pressing Escape (all code is in GameManagerScript2
	o	Purchase Item sound (some code is in CurrencyScript)
	o	Moonstone pick up sound (some code is in collectablepickup)
	o	Ship part pick up sound (some code is in partpickup)
	o	Game win jingle (all code in GameManagerScript2)
