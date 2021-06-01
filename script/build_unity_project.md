# Build a Unity project to explore an ODM mesh

## Prerequisites
- You need to have Unity Hub installed and an empty project based on teh 3D template running. Hopefully you followed [these instructions](/script/unity_setup.md).
- You need a mesh with the y-axis facing up (normally ODM places the z-axis facing up, so you'll need to [rotate it in Meshlab according to these instructions](/script/rotate_mesh_in_meshlab.md).

## Add the ODM mesh
- Open your file explorer, and in the Unity directory, go to the ```Assets``` subdirectory. In it, create a directory called ```odm_mesh```.
- Drop the entire ```odm_textured_model``` directory in there, _including the .obj file with the y-axis facing up_.
- Head back to the Unity editor, which will proceed to import the model (takes a few minutes).
- Drag the .obj file into the Hierarchy window on the upper left (in the Sample Scene). It should appear in the Scene tab.

## Add the First-Person Character Controller
- In the ```GameObject``` menu, choose ```Create Empty```. Name it "player."
- Select the player in the Hierarchy tab, and in the Inspector tab, press ```Add Component```. Search for ```Character Controller``` and add it. You should now see a wireframe Minion-shaped capsule appear in the Scene tab.
- Click back on the player in the Hierarchy tab, right-click, and select ```Camera```. A new mini-window should appear showing the view from the camera, which will be from the point of view of the player capsule (if your mesh is positioned in view of the camera, you'll see it, otherwise it'll just show a blue sky and grey-brown blank ground).
- Right-click on the ```Main Camera``` object in the Heirarchy pane, and delete it. We don't need it since we have a camera on the player.
- With the camera selected, set the Y position in the Inspector to 1 (that'll just put the camera at the top of the capsule, which will make sense for a human-esque point of view).

### Add a script to control the player and camera
- In the Assets directory of this repo, there's a script called ```PlayerController.cs```. In your file explorer, copy this script into the Assets directory of the project. When you return to the Unity editor, it will proceed to import the script.
- Select the player object in the Hierarchy pane. Drag the PlayerController script from the Assets pane into the lower part of the Inspector pane, which should have the effect of attaching the script to the player (whenever selecting the player, you'll now see the PlayerController script's properties in the Inspector pane, below the Character Controller component).
- In the Hierarchy pane, select the player. Then drag the child Camera into the PlayerCamera slot in the PlayerController script properties (which probably says ```Transform None``` at the moment) in the Inspector. This links the camera to the corresponding object in the script (and is easy to forget, which will cause the controls to not work).
- You should be able to press the play button at the top of the editor screen and try it now. To exit play mode, press the play button again (there's no stop button, and the pause button doesn't exit play mode). 

## Lighting
The single-point lighting that seems to be the default in Unity leaves nasty shadows in the scene. Global illumination would be better, presumably. However, it seems as though this makes it tricky to build for WebGL. To be investigated. 

# Build for WebGL
- Select ```File``` -> ```Build Settings```, select WebGL, and press ```Switch Platform```. That takes some time as Unity pre-processes a bunch of stuff.
- Push the Build button?