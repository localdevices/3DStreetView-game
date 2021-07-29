# Build a Unity project to explore an ODM mesh

## Prerequisites
- You need to have Unity Hub installed and an empty project based on the default 3D template. Hopefully you followed [these instructions](/docs/unity_setup.md).
- You need a mesh with the y-axis facing up (normally ODM places the z-axis facing up, so you'll need to [rotate it in Meshlab according to these instructions](/docs/rotate_mesh_in_meshlab.md).

## Add the ODM mesh
- Open your file explorer, and in the Unity directory, go to the ```Assets``` subdirectory. In it, create a directory called ```my_location_mesh``` (or whatever name/description will make sense to you).
- Drop the entire ```odm_textured_model``` directory in there (maybe rename it so it's possible to distinguish it from any other ODM mesh), _including the .obj file with the y-axis facing up_ as per the mesh rotation instructions.
- Head back to the Unity editor, which will proceed to import the model (takes a few minutes). The directory should appear as a folder icon in the Assets pane, and if you click to enter it you should find the .obj file.
- Drag the .obj file into the Hierarchy window on the upper left (in the Sample Scene). It should appear in the Scene tab.

## Add the First-Person Character Controller
- In the ```GameObject``` menu, choose ```Create Empty```. Name it "player."
- Select the player in the Hierarchy tab, and in the Inspector tab, press ```Add Component```. Search for ```Character Controller``` and add it. You should now see a wireframe Minion-shaped capsule appear in the Scene tab.
- Click back on the player in the Hierarchy tab, right-click, and select ```Camera```. A new mini-window should appear showing the view from the camera, which will be from the point of view of the player capsule (if your mesh is positioned in view of the camera, you'll see it, otherwise it'll just show a blue sky and grey-brown blank ground).
- We can now remove the default camera. Right-click on the ```Main Camera``` object in the Heirarchy pane, and delete it. We don't need it since we have a camera on the player.
- With the camera selected, set the Y position in the Inspector to 1 (that'll just put the camera at the top of the capsule, which will make sense for a human-esque point of view).

### Add a script to control the player and camera
- In the Assets directory of this repo, there are some scripts called ```PlayerController.cs```. For now, they are different depending if you are building for WebGL or native run-on-the-computer executables, they have the same name but are in different subdirectories. In your file explorer, copy the appropriate script into the Assets directory of the project. When you return to the Unity editor, it will proceed to import the script.
- Select the player object in the Hierarchy pane. Drag the PlayerController script from the Assets pane into the lower part of the Inspector pane, which should have the effect of attaching the script to the player (whenever selecting the player, you'll now see the PlayerController script's properties in the Inspector pane, below the Character Controller component).
- In the Hierarchy pane, select the player. Then drag the child Camera into the Player Camera slot in the PlayerController script properties (which contains ```None (Transform)``` at the moment) in the Inspector. Once done, the Player Camera spot will read ```Camera (Transform)```. This links the camera to the corresponding object in the script (it's a detail that is easy to forget, which will cause the controls to not work).
- You should be able to press the play button at the top of the editor screen and try it now. To exit play mode, press the play button again (there's no stop button, and the pause button doesn't exit play mode). 

## Lighting
The single-point lighting that seems to be the default in Unity leaves nasty shadows in the scene. To fix this, select the ```Directional Light``` object in the Hierarchy pane, and, in the Inspector pane, set the ```Shadow Type``` property to ```No Shadows```. If your scene then appears overly brightly lit, reduce the ```Intensity``` to something less than 1 (for meshes that were shot in full daylight, a value of about 0.6 seems pleasant).

## Heads Up Display (HUD)
We need a way for people to know which keys to press to move, particularly in a WebGL game, which does not support joysticks or gamepads! The PlayerController we built uses a setup that will be somewhat familiar to experienced gamers; the left hand controls movement (translation) and the right hand controls twhere you are looking (rotation). On the keyboard, this translates to:

__Translation__
- W for forward
- S for backward
- A to move sideways (sidle) to the left
- D to sidle right
- E to levitate straight up in the air
- Q to sink back straight down
- The SPACE bar rapidly slows all movement in all three dimensions. If tapped briefly, it allows the player to slow down to maneuver, and if held down, it brings all movement to a stop.

__Rotation__
- O to look up
- L to look down
- K to look left
- ; (semicolon) to look right
The mouse also functions to look around. This can be confusing, as once the game starts, if the user clicks their mouse button within the game area, the mouse pointer disappears and all mouse movements are "captured" by the game. The ESC button releases the mouse back to the desktop.

__Other controls__
While the instructions are useful to get people started, they get in the way of normal exploration, so the H button toggles the instruction overlay to invisibility.

Some people (especially those of us raised on flight simulators, or more recently on drone flight controls) prefer the right-hand stick movements to mimic the movement of the "aircraft" we are controlling. This is known as an [Inverted Y-axis](https://www.theguardian.com/games/2020/feb/28/why-do-video-game-players-invert-the-controls). Pressing the Y button causes the game to switch to an inverted Y axis, swapping the function of the O and L keys (or equivalent mouse movements).

### Instructions Canvas
Unity has a Canvas element, which instead of being part of the 3D world, is like a flat transparency just in front of the camera.  We'll put the instructions on that.

Gameobject -> UI -> Canvas creates an empty Canvas and an EvenSystem. Select the Canvas object in the Hierarchy pane, and drag the CanvasController to the empty space in the Inspector pane below it.

Now hit the 2D button in the Scene pane, and zoom out a ludicrous amount until you see the whole Canvas, which will be a giant white square that makes the mesh look microsopic. 

Right-click on the Canvas in the Hierarchy pane, and select Text. Set the text to font size 28 and Bold. We set the color to Hex ```0F0101``` (a dark red). In the Text box in the Inspector, paste:

```
Q - Float down       W - Forward         E - Float up
A - Sidle left            S - Backward       D - Sidle right
      SPACE - Brakes! Slow down in all directions
```
Move that text block to a corner of the screen, and repeat with two more text blocks:

```
                               O - Look up       
K - Look  left         L - Look down     ; - Look right
            Or use your mouse to look around
```

```
ESC - Get your mouse back
Y - Invert Y-Axis
H - Hide instructions
```

# Build for WebGL
- Select ```File``` -> ```Build Settings```, select WebGL, and press ```Switch Platform```. That takes some time as Unity pre-processes a bunch of stuff.
- You'll need to disable compression on the build; for some reason the compression causes the WebGL app to load to 90% and stop.
  - In the Build Settings pane, push the ```Player Settings...``` button on the lower left. Select ```Player``` along the left, and in ```Publishing Settings``` set ```Compression Format``` to Disabled.
- Push the Build button. If you're on Linux and encounter a failure, it might be the library issue in the Gotchas section of the [Unity setup](/docs/unity_setup) instructions.
- If it works, it'll output a folder containing an index.html file and a couple of folders full of data. That's what you'll stick on a Web server somewhere.
  - To test it locally, ```cd``` into the folder, and start a tiny local webserver with ```python3 -m http.server --cgi 8360```. Then in your browser type the address ```http://localhost:8360/index.html```.
## Deploy
- Get a server and a domain name, set up the nameservers, install Nginx, [set up SSL with LetsEncrypt](https://www.digitalocean.com/community/tutorials/how-to-secure-nginx-with-let-s-encrypt-on-ubuntu-20-04), stick the index.html file and data folders in the www data directory.
