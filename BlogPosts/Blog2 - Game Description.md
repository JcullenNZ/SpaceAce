<h1>Game Design Document</h1>
The goal of this project is to design a game to be played on an arcade machine.<br>
With this in mind, I know I want to make a 2D game of some sort.
Originally, I considered creating a bubble buster game, however I lost inspiration and decided it would be more fun to make a sci-fi game.<br>
With an arcade style game, from my experience I have found that individual games should be short, fast-paced, and have some form of competitive element such as a highscore
to encourage players to come back.<br>
I have planned the game out as follows.<br>

<h2>Game Design Document: SpaceAce</h2>
SpaceAce is a spaceship shooter game where players control a spaceship to shoot alien spaceships. The objective is to score points and achieve a high score 
by destroying enemies and surviving as long as possible.<br>

<strong>Genre</strong><br>
Arcade Shooter<br>

<strong>Target Audience</strong><br>
Arcade players, so the game should be competitive and fast-paced.<br>

<strong>Platform</strong><br>
PC with an arcade controller input. 6 buttons and one joystick. This limits input to some extent.<br>

<strong>Setting + Story</strong><br>
The game is set in space, where the player controls a spaceship. The environment is filled with stars, planets, and asteroids to avoid.<br>
The player is a fighter ace tasked with defending space from endless waves of alien enemies. The player must utilize their piloting 
and shooting skills to defeat the alien hoard.<br>

<h2>Gameplay</h2><br>
<strong>Core Mechanics</strong><br>
Player Controls: The player moves the spaceship using the fightstick and shoots using buttons.<br>
Enemy Waves: Enemies spawn in waves, with each wave increasing in difficulty.<br>
Scoring: Players earn points for each enemy destroyed. Points accumulate to achieve high scores.<br>
Power-ups: Various power-ups appear to enhance the player's abilities, such as faster shooting, shields, and special weapons.<br>
Health System: Both player and enemies have health bars. The player loses a life when their health reaches zero.<br>

<strong>Game Loop</strong><br>
Start Game: The game begins with the player controlling their spaceship.<br>
Spawn Enemies: Enemies spawn in waves and move towards the player.<br>
Player Actions: The player moves, shoots enemies, and collects power-ups.<br>
Update Score: The score is updated based on enemies destroyed.<br>
Wave Progression: Each wave becomes progressively harder with more and stronger enemies.<br>
Game Over: The game ends when the player loses all lives. The final score is compared to high scores, and if it qualifies, it is saved.<br>

<h2>Features</h2>
<strong>Main Menu</strong><br>
High Scores Display: Shows the top X high scores. <br>
Start Game Button: Starts a new game. <br>
Settings Button: Opens the settings menu for audio settings.<br>
Name Input Screen: Allows the player to enter their initials (3 letters) for the high score list.<br>

<strong>Settings Menu</strong><br>
Audio Settings: Adjust background music and sound effects volume. <br>

<strong>Game</strong><br>
Player Controller: Handles player movement and shooting.<br>
Enemy Controller: Manages enemy behavior and wave spawning.<br>
Power-ups and Special Weapons: Enhances player abilities.<br>
Health System: Manages health for player and enemies.<br>
Score System: Tracks and updates the player's score.<br>
Pause: Pauses the game and give menu options

<strong>Game Over Screen</strong><br>
High Scores Display: Shows high scores and allows the player to see if they achieved a high score.<br>
Restart button: Restarts the game.<br>

<h2>UI Elements</h2>
Score Display: Shows the current score.<br>
Lives Display: Shows remaining lives.<br>
Timer: Counts the game duration.<br>
Wave Alerts: Alerts players to wave changes.<br>
Health Bars: Displays health for player and enemies.<br>


<h1>Milestones</h1>
As way to keep the project development on track, 3 milestones must be set to deliver a final game in time.<br>
The three milestones selected are:<br>
<ol>
  <li><a href="https://github.com/JcullenNZ/SpaceAce/blob/main/BlogPosts/Blog3 - Milestone1.md">Main menu view, Audio, Scene, Game and UI management</a></li>
  <li><a href="https://github.com/JcullenNZ/SpaceAce/blob/main/BlogPosts/Blog4 - Milestone2.md">Core game play, Enemy and player interactions, death</a></li>
  <li><a href="https://github.com/JcullenNZ/SpaceAce/blob/main/BlogPosts/Blog5 - Milestone3.md">Full game loop, scoring system, wave management</a></li>
</ol>

Beyond this, the game should be in a state where it is fully playable and anything beyond is 'extra spice'.
