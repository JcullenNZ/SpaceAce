<h1>Blog post 5 - Milestone 3</h1>
At the last milestone, the player could move, shoot, destroy enemies, and be killed. But there was no reward for killing enemies, nor was there an easy way to keep playing to get better!<br>
This is addressed in this post. By the end, there is a full game loop, a comprehensive scoring system, unending waves of enemies, and some beautification that has added.<br>

<h2>The Full loop</h2>
To create a proper game, the player must be able to get back into the action as quickly as they can. This means handling the death of the player by providing a Game Over scene.<br>
The screen was made with two buttons, one to start a new game and one to quit the game. The scene management is handled by the GameManager, with the action being called by the GameUIManager when the player dies, and also when a timer runs out. I will talk about that in the wave management. From this, the player can now make a full loop. <br>
[Unity_9WOxni8jpc](https://github.com/JcullenNZ/SpaceAce/assets/94792906/8f597c48-6cbf-4f12-96d3-b08737ddb512)<br>
As can be seen in the above gif, there is also a scoring system and wave system, as well as some of the beauitfication mentioned.<br>

<h2></h2>
