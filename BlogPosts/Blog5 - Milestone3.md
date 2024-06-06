<h1>Blog post 5 - Milestone 3</h1>
At the last milestone, the player could move, shoot, destroy enemies, and be killed. But there was no reward for killing enemies, nor was there an easy way to keep playing to get better!<br>
This is addressed in this post. By the end, there is a full game loop, a comprehensive scoring system, unending waves of enemies, and some beautification that has added.<br>

<h2>The Full loop</h2>
To create a proper game, the player must be able to get back into the action as quickly as they can. This means handling the death of the player by providing a Game Over scene.<br>
The screen was made with two buttons, one to start a new game and one to quit the game. The scene management is handled by the GameManager, with the action being called by the GameUIManager when the player dies, and also when a timer runs out. I will talk about that in the wave management. From this, the player can now make a full loop. <br>
[Unity_9WOxni8jpc](https://github.com/JcullenNZ/SpaceAce/assets/94792906/8f597c48-6cbf-4f12-96d3-b08737ddb512)<br>
As can be seen in the above gif, there is also a scoring system and wave system, as well as some of the beauitfication mentioned. This includes a pause menu. The Pause is triggered by a button press in the input system, which the GameUIManager subscribes to and calls the ShowPause method. When in the pause screen, the time scale is set to 0, such that the game is properly paused. Upon un-pausing and **Eject**(ending the game), this is reset. This is similar to how it works in the main menu, and allows the player to end the game early.

<h2>The Unending Waves</h2>
In order to become the top Space Ace, the player needs to face a lot of enemies. A new class was created, the Wave Manager.<br>

<img width="565" alt="WaveManager_top" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/17d44b7e-4dc0-4616-9519-ceb47f60d0ee"><img width="310" alt="Unity_WjdO8rG8RK" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/4b64eeeb-89b9-4d51-8aa3-a759b278d3a5"><br>

The declarations tie in with the inspector. The prefabbed enemies, of which there are 3 types with different health, speeds, and weapons, are able assigned to be instatiated. There are empty game objects scattered around the play area to act as spawn points from their transformations. They are childed to the camera so that they move relative to the player too.
Under that, the wave settings control how the waves behave. <br>
<img width="754" alt="WaveManager_Spawn" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/bc43b3eb-1106-4108-b62c-e31422fb03b2"><br>
Starting the wave is a coroutine that starts by sending out a message for any event listeners.<br>
It then waits for a defined time, the timeBetweenWaves, to provide a break in the action. Once that returns, the wave is active and SpawnEnemy() is called the number of times for enemies per wave.<br>
SpawnEnemy as a method handles which enemies to spawn from the array of supplied enemies. By using the indexes of enemies, each wave can be tailored to increase in difficulty. Currently, the first round holds only easy enemies, but as the waveCount increases, the option of spawning harder enemies opens up.
They are also spawned at a random location from the array of spawnpoints, meaning every game will be different.<br>
<img width="498" alt="WaveManager_Update" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/7ad04bed-a0eb-432b-b20e-d04ef255f39b">
The final part of the wave manager is the update. This is where, as enemies are killed, it checks to see if you have finished the wave. The first thing when you complete a wave is to set the score of the wave and an event is sent out to notify any listening scripts. The loop then continues.<br>

The GameUIManager is listening to the wave manager, and it uses it to show the wave information for the player.<br> 
<img width="654" alt="Unity_NirbrsKHVE" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/5f3809a2-5a5d-440b-9ad0-408ab550c3c0"><br>
<img width="659" alt="GameUIManager_WaveActions" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/81e35650-ec3f-4c91-a73c-5d7a318eca3e"><br>
This handles the GUI information about the wave, presenting good player feedback. 


