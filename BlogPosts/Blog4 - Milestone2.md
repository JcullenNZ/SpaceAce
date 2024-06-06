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
The Player Controller script is in charge of all the player actions, such as movement and weapons. It can be seen above that the inspector has access to rotation speed, movespeed, and the weapon to be assigned.
<img width="450" alt="Player_params" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/82376bb6-437b-4eac-9061-b2ad74f66b3f">

<img width="450" alt="Player_ControllerScript" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/467eba76-3b27-40c3-80ea-535b6bb4c577">
