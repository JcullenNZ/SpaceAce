<h1>Milestone1</h1>
As stated in <a href="https://github.com/JcullenNZ/SpaceAce/blob/main/BlogPosts/Blog2 - Game Description.md">Blog2</a>, this is the first of three milestones.<br>

In this blog I plan to:
- Make the main menu
- Implement managers for Scene, UI, Audio
- Get the game to change scene
- Get the game to quit
- Implement the player controls

One of the first things I did, was to find inspiration for the aesthetic of the game. I appraoched the building of the main menu as a way to ground me in the project and
to make sure the style would match throughout. I looked at exisiting space and science fiction user interfaces, and liked the look of some, but wanted something that
appealed to the retro idea of an arcade machine, and also gave some arcade feel.<br>
I asked Dall-e to give me some inspiration. I had already envisioned that I wanted the ship's cockpit as the main menu environment. After some refinement the image that best reflected my idea was found.<br>
![image](https://github.com/JcullenNZ/SpaceAce/assets/94792906/c76eeed8-605f-4be5-a918-ee0fc64464e6)
<br>
From here, I felt I could start designing the main menu.<br>

Starting with the main menu was mainly for me to get familiar with working with Unity and connecting code to objects.<br>
I started by creating the canvas and placing buttons onto the scene. I was fortunate to find the Electronic Highway font in TextMeshPro also fit the style of the game.<br>
<img width="170" alt="MainMenu-Hierarchy" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/11bae3a8-5e8f-4e67-987e-877b462cca93">
<img width="423" alt="MainMenu" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/d614e93c-5130-4ee3-bca3-261407678892"> <br>

With the first view designed, I needed a UIManager to handle the interactions of the UI, eg. would be responsible for handling the opening of new views in the UI. <br>
<img width="375" alt="UIManager" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/cb1e8f01-f49f-44b4-be68-094a78f4d865">
<img width="301" alt="UIManager_Hierarchy" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/4b4f11e7-efe9-4448-8b16-c028aa5216bb"><br>
The declarations allow for inspector assignment of all the relevant game objects.<br>
The simple  SetActive() methods on the assigned game objects meant it was easy to handle the first goal. The event system enabled navigation and selecting the buttons at this point, and I used the OnClick method attached to the Button attribute to set views active and inactive. This was fine for changing to the settings view, but to add functionality to the audio settings and navigate into NewGame and Quit, an AudioManager and GameManager were required. 
<img width="188" alt="MainMenu_HierarchyFULL" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/b7208ef2-2de6-4106-948a-648fb9a9224b"><br>
The AudioManager and GameManager were made into prefabs and the singleton pattern was implemented as I knew these objects would persist over multiple scenes. Singleton allows me to have multiple instances of these objects across different scenes, but ensure only one is kept when the scene is loaded.<br>
<img width="492" alt="GameMgr_Singleton" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/fad85b2c-8bde-4924-bd69-a7197548ed2d"><br>

To handle the scene management, I created the LoadScene() method. The UnityEngine.SceneManager name space loads the scenes by name, making this very extensible. Additionally, I added the event invocation when the scene loaded. 
<img width="412" alt="GameManager" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/fa5cf620-ac0b-45e7-95f0-b2b2746ff95b"><br>
This would be useful when any classes may need to know about changing scenes - such as the AudioManager changing the music based on the scene.<br>

My initial implementation of the AudioManager was not as tidy as the one I ended up with here. Originally, I had it set so that each sound would play by index of an sfx array and a soundtrack array, and each audio source would have its volume set individually. I followed a Rehope Games tutorial in order to make the AudioManager work with the Unity audio mixer.<br>
<img width="307" alt="AudioManager_inspector" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/8f198498-2dd8-40d6-84b9-caeef7d13545">
<img width="494" alt="AudioManager_Params" src="https://github.com/JcullenNZ/SpaceAce/assets/94792906/96bd3f6e-d774-484e-a30b-6ceea957faaa"><br>
This script also listens for the OnSceneChange from the GameManager to change music when the scene starts.<br>
Additionally, it includes the SetMusicVolume and SetSFXVolume methods, which are called when the value of the slider is changed. I started with the AudioManager tied to the sliders in the Settings menu, but then decided it made more sense to keep the UI elements tied to the UIManager. <br>
![MainMenu](https://github.com/JcullenNZ/SpaceAce/assets/94792906/96c8b7ae-8915-4c36-a1e6-c5bf3f3fa975)<br>


Up until now, all of the interactions have been handled by the default event system. My next task is to set up a Player Input using the new Unity Input System which will be the first section of <a href="https://github.com/JcullenNZ/SpaceAce/edit/main/BlogPosts/Blog4 - Milestone2.md">Blog3-Milestone2</a>.












