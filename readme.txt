One of the main things that may need to be done if this code is merged into a separate version is to create a tag called “The Player” 
in Edit-> Project Settings and assign the player game object to this tag at the top of the Inspector. 
This will allow the collectables to detect that the player is interacting with them rather than aliens.

I have added several different prefabs that have scripts and animations embedded within them. 

The main collectable currency is moon stones, which have four different prefab appearances. 
These were obtained through the “Toon Crystals” free asset on the Unity store. 
Each of these crystals has a capsule trigger collider that is controlled through the CollectableProximity script. 

This script basically makes it so that when the player gets close, the object will grow and shrink to draw the player’s attention. 
This script will toggle an animation when the player triggers the collider, which has been set to a large radius so it can be triggered at a distance.

Each Toon Crystal then has a sphere child game object that also has a collider but no mesh rendering. 
When this child collider is triggered, the CollectablePickUp script will remove the entire GameObject (parent included) from the scene. 
There is also commented code that provides an example of how to increment currency when this happens.

I have also added three ship collectable parts (for now) that behave similarly to the moon stones.
The first is a wrench (free Unity Store asset), the second a satellite (Nate's space pack), and the third a cockpit (space pack as well.) 
Each ship part has been added to the prefab list and has similar scripting to the moon stones. 
For example, when the player is close to the ship part, it will grow and shrink, and when the player runs over the ship part, it will be removed. 
There is commented code to suggest how to set a Boolean when the part is collected that may trigger some event in the game.
