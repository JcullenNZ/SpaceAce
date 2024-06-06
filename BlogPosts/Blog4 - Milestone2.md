<h1>Blog Post 4 - Milestone 2</h1>
In this blog post, I will establish the basic game loop. That includes:
- creating player input
- player
- enemy
- interactions
- weapon systems

<h2>Player Input</h2>
At the last milestone, all the interactions were with UI and could be handled by the event system. Now I needed to control the player object as it moved around in the world.<br>
Using the new Input System from Unity makes mapping controller interactions simple so I installed the package and created the Input Actions. I knew I would need to the player to move with the left stick and at a minimum shoot. I started with that, and added a pause action too. This covered the 'InGame' actions. <br>
<img width="825" alt="PlayerControls" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/464952bc-bcef-47a2-a329-ba5ed74e9d9c"><br>
When the button is pressed, a message is sent to say the action was performed. Any object can subscribe to this and listen for the action, and call a method in response.<br>
With this set up, I created the player.<br>

<h2>Player</h2>
The Player game object is made up of several parts. The object takes two scripts, PlayerController and player health, and has one child object.<br>
<img width="298" alt="Player_Inspector" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/fb11edf6-1a87-467e-baac-b7c520b40e40"><br>
The Player Controller script is in charge of all the player actions, such as movement and weapons. It can be seen above that the inspector has access to rotation speed, movespeed, and the weapon to be assigned.<br>
<img width="450" alt="Player_params" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/82376bb6-437b-4eac-9061-b2ad74f66b3f">

<img width="450" alt="Player_ControllerScript" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/467eba76-3b27-40c3-80ea-535b6bb4c577">
The script establishes the listener for the input actions, and assigns the relevant methods.<br>
Shoot calls the attached weapon object shoot method. This maintains separation and allows weapons to be made as prefabs as the enemy will also have weapons.<br>

The Player Health script is an implementation of an interface, as both the player and enemies use this. I created it with a view to be expandable with extra features later.<br>
<img width="446" alt="PlayerHealth" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/b6074a05-1602-4190-bf2b-f4ab1245ef01"><br>
The most notable part of this is that there is an event for when the player dies.

<h2>Enemy</h2>
The Enemy operates very similarly to the player. It has both a controller and a health script, and has a weapon object as a child.<br>
<img width="558" alt="Code_rEWje3HeHG" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/f6884ffb-a5ed-48ad-b337-8bb44a7cbe50"><br>
The enemy controller implements a basic enemy AI to rotate and move toward the player, and to fire the weapon. There is an interesting bug that I can not fix where the enemies rotate in the x- and y-axes, which makes them harder to hit and sometimes it looks like cool maneuveres, so I have decided it is a feature.<br>
The Enemy Health is the same as the player health, and able to be set in the inpsector.

<h2>Weapon</h2>
The weapon was made with the idea that it would handle all shots. It would control how often it could fire, would instatiate the projectile, would assign the damage, the speed of the projectile, and where it was 'mounted' to the ships.<br>
<img width="790" alt="Weapon" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/6a2cf577-1b4f-45cc-a816-05881cc743d8">
The most interesting part of this is that it runs a co-routine to delay the next shot.<br>
The projectile is a basic capsule sprite with a script and a collider2D. <br>
<img width="754" alt="projectile" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/adbd2f42-ee1d-4845-94bf-2ebda7857f9d">
To make correct interactions with the objects, the projectile checks to see if the other collider has the correct tag. The projectile, player, and all enemies have a corresponding tag to correctly handle interactions. By having the health managers, it makes it easy to call the TakeDamage methods.<br>

At this point, the player can move around in the game area, enemies will move towards the player and shoot automatically, and the player and enemies can die as they are supposed to. One of the key parts of this game was also the ability to have an infinite map, and an infinite number of enemies, so that only the best SpaceAce would make it to the leader board. These will be handled by the next milestone.


