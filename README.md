# GamesEngines1CA

Games Engines 1 Assignment

Simon O’Leary – C15413218


Flight simulator set in a procedurally generated world

--Player controlled aircraft(Helicopter)

--Procedural world

--Trees of varying color swaying

--Audio player (Trees pulse to audio) 

Controls (Keyboard):

--Mouse to look around

--W,A,S,D to control movement (Arrow keys work too)

--E to Enter/Exit helicopter 

--F to spawn helicopter where youre looking 

--T to reload scene 

Demonstration Video:

[![YOUTUBE](http://img.youtube.com/vi/EtD-Ph55v4w/0.jpg)](http://www.youtube.com/watch?v=EtD-Ph55v4w)

Video Link: https://youtu.be/EtD-Ph55v4w

What is going on:

When the program is run a perlin noise function is used to generate the procedural terrain which the player is on (Takes place in the infiniteTerrain.cs script). The world will generate around the player as they move, destroying tiles too far away. Trees of various colors are placed using the same function. There is a cap on the number of trees which can be in the scene at one time which can be changed in the (treepool.cs) script. The trees are spawning at the high points on the terrain, leaving the valleys to act like a path for the player. These two features were touched on in class and adapted from a youtube series available here: https://www.youtube.com/watch?v=dycHQFEz8VI

If the player enables the AudioAnalyzer (And 'FloraGen(WithAudio)') the trees will pulse in time with the music playing (Default Imagine Dragons - Zero). This was discussed in class and I tried to implement it differently in a different scene (AudioVizAlt) but was unable to make anything more exciting.

The player look and movement both feel good and responsive. If the player presses F they will spawn a helicopter prefab which is controllable. This is done via raycasting(PhysicsSpawner.cs script) and to control it they need to walk up to it and press E (EnterVehicle.cs). Once theyve entered the player camera and controller are disabled and the player becomes a child of the helicopter (EnterVehile.cs). This is so the procedural world will generate as you fly. The player can exit the vehicle at any time by pressing E again. 

The scene can be reloaded by pressing T which will reset the music if it is playing and place the back where they began. Its also worth noting the trees sway slightly to make them look a little better. I created other tree prefabs using probuilder but they have some issues with colliders.

What didn't make it in:

I had planned to make this have the option of VR but was unable to due to issues with steam VR and importing assets. I didnt have enough time to test it so I left it out of the final build.

