# Escape Xenon

A game by Team K-PAWP

## Team Members

Nate Knauf - nate.knauf@gatech.edu - nknauf3

Cesar Porcayo - cesarporcayo@gatech.edu - cporcayo3

Eugene Ahn - eahn98@gatech.edu - eahn33

Alexander Wilkins - awilkins6@gatech.edu - awilkins6

Joshua Perry - jperry45@gatech.edu - jperry45

## How To Play

No installation requirements

Instructions:
* WASD / Arrow Keys / Left Joystick to move
* Mouse / Right Joystick to look around
* Mouseclick or Right Trigger to shoot grapple
* Space or Cross button to jump
* T or Square button to build turret
* E or Triangle button to open shop

Game Objectives:
You have crash-landed on an alien planet Xenon.
Explore the map and collect moonstones during the day to purchase upgrades.
Spend moonstones to build turrets to defend your ship from aliens that spawn at night.
Survive long enough to collect all 5 missing ship parts so you can repair your ship and Escape Xenon.

## Game Rubric

### 3D Feel Game:
* The player controls a clear virtual avatar in the form of the main robot character.
* The player can explore a 3D world through physics-based locomotion with responsive analog controls
* There is a clearly defined ultimate goal: collect all 5 missing ship parts
* Start Menu and Pause Menu with Restart Button implemented

### Precursors to Fun Gameplay
* Main goal (collect 5 ship parts) communicated through GUI icons of missing parts
* Sub-goals made clear with currency counter, day-night timer, and in-game shop with item descriptions
* There are meaningful interesting choices and dilemmas, mainly in the tradeoff between collecting currency and preparing for the alien waves vs. spending daytime exploring for ship parts
* Player choices affect the game world by placing turret objects on the ground, which interact with and kill aliens, and by removing moonstone and ship part objects from the environment on pick-up
* Survival and winning revolves around balancing time spent preparing vs. exploring
* Game punishes player for neglecting ship by having aliens damage the ship, requiring repairs or causing the game to be lost if the player is gone for too long
* Difficulty progresses as a greater number of aliens spawn each night

### 3D Character with Real-Time Control
* Robot control and locomotion through the world via rolling and grpapling is a predominant part of gameplay
* Although the rolling ball is derivative of an earlier assignment, the Grapple mechanic is entirely original
* Unique character with responsive physics animations (bobbing head, rotating rings on ball body, flying grapple hook with wire)
* Player has direct analog control of character movement via joystick
* Smooth camera that uses Raycasting to avoid clipping through objects
* Auditory feedback for jumps, grapple shots

### 3D World with Physics and Spatial Simulation
* Unique 3D environment hand-crafted with a variety of prefabs, primitives, and meshes scattered throughout the map
* Distinct regions of the map with unique aesthetics
* Audio clips for essentially all user interactions with the world
* Steep cliffs at edges of game world, with invisible walls preventing the player from leaving the game area
* Variety of different 3D environments that must be explored and overcome in different ways with locomotion and the grapple mechanic
* Consistent spatial simulation based on TimeScale

### Real-time NPC Steering Behaviors / Artificial Intelligence
* Self-made AI agents as aliens that navigate towards the ship from random spawn locations
* Alien agents dodge obstacles (turrets) placed in their way by player
* Alien agents have two states: Seek Ship and Attack Ship, with different behaviors and animations
* Turret agents have two states: Idle and Attack Alien
* Aliens utilize Root motion with simple animation and smooth continuous motion
* Turrets play shooting sound effects, Aliens cry "oof!" when they die

### Polish
* Large variety of regions within the map with unique aesthetics
* Stylistically consistent User Interface
* Continuously updating health bars for the Ship and Aliens
* Start Menu and Pause Menu GUI with ability to quit or restart
* Environment acknowledges player via collectable items reacting to nearby player and zooming towards nearby player
* Audio representation of many game effects
* Variety of particle effects and line / trail renderers
* Consistent artistic style & color palette
* Both 2D Game Music and 3D location-based sound effects
* Dynamic day-night system with moving shadows & realistic lighting
* Helpful UI overlay showing important game state information

### Fun / Gestalt / "Flow"
* Immersive from start-to-finish
* Grappling is a really fun and responsive mechanic
* Player can gradually become skilled at locomotion by learning how to use grappling-sequences to accelerate faster than rolling movement
* Difficulty increases over time to match Player's learning of the game mechanics

## Known Bugs:

None

## External Resources:

Variety of Creative-Commons textures
Space Kit and Space UI-Pack from Kenney.nl
Day and Night cycle derivative of free asset from Skyblood Games
Other Free Assets: Progress Bar, Toon Crystals Pack, Space Debris Models
Icons from Unity Standard Assets

## Who did what:

Nate Knauf:
* Project Management, Merging & Interoperability
* Alien & Turret AI
* Robot Locomotion & Controls
* Wrote the README

Cesar Porcayo:
* Environment & Level Design
* Original Grapple Mechanic
* Title Logo

Eugene Ahn:
* Upgrade Shop

Alexander Wilkins:
* Day-Night cycle
* Alien Model & Animation

Joshua Perry:
* Collectible System - ship parts and currency
* Collectible Animations
* Start and Pause Menus

Everyone:
* Game Pitch
* Playtesting
* Playtest Analysis

## Unity Scenes

`MAIN menu.unity` is the main menu and default scene

`MAIN game.unity` is the game environment
