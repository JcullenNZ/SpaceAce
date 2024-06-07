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
This handles the GUI information about the wave, providing good player feedback.<br>
There are two other main new pieces of information the GameUIManager handles, that being updating the player's name and score to the HUB.<br>

Speaking of score...
<h2>The High Scores</h2>'
Finally, there is proof that you are the top SpaceAce!<br>
The HighScoreManager is responsible for handling the loading, saving, and adding of highscores. It stores the scores as a JSON file, stored locally on the machine under 'Application.persistantPath'/highscores.json. For windows, this means it is stored in the AppData under the game company name. 
<img width="644" alt="HighScoreMgr" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/831ab378-8da2-45fb-b3b4-ec51218c97dc"><br>
<img width="570" alt="HighScore_saveload" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/bfa0d260-b97f-420e-ac47-f4f74bb4dd1f"><br>
<img width="689" alt="HighSCore_add" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/f190fefd-1c18-40ae-a7ce-36c36af6056f"><br>

The AddHighSCore method takes a highscore, checks if there is space for a new highscore and if the score is indeed a highscore, then when it is, removes the lowest score and places it in the correct position on the leader board.<br>
<img width="655" alt="Unity_CvnJC266u1" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/81623e73-e4e9-41d2-8abb-61651c9531f9">

The leaderboard shows on the game over screen, and is displayed by the highscoretable script.
<img width="698" alt="Code_FTG0Q2pk0T" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/7f5ad790-6d0b-430a-aa01-9ca6f0619872">
There is a prefab in the table, which contains 3 game objects with a TextMeshPro component. These are then filled in the DisplayHighScores method by reading through the HighScores object returned by the GetHighScores method in the HighscoreManager. A table is also added to the first screen.
<img width="655" alt="Unity_2WgLnSClNW" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/4f972535-9037-473e-81b6-8963ea5ac1e3">




