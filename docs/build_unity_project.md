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
- In the Assets directory of this repo, there are some scripts called ```PlayerController.cs```. For now, they are different depending if you are building for WebGL or native run-on-the-computer executables. In your file explorer, copy thisthe appropriate script into the Assets directory of the project. When you return to the Unity editor, it will proceed to import the script.
- Select the player object in the Hierarchy pane. Drag the PlayerController script from the Assets pane into the lower part of the Inspector pane, which should have the effect of attaching the script to the player (whenever selecting the player, you'll now see the PlayerController script's properties in the Inspector pane, below the Character Controller component).
- In the Hierarchy pane, select the player. Then drag the child Camera into the PlayerCamera slot in the PlayerController script properties (which probably says ```Transform None``` at the moment) in the Inspector. This links the camera to the corresponding object in the script (and is easy to forget, which will cause the controls to not work).
- You should be able to press the play button at the top of the editor screen and try it now. To exit play mode, press the play button again (there's no stop button, and the pause button doesn't exit play mode). 

## Lighting
The single-point lighting that seems to be the default in Unity leaves nasty shadows in the scene. Global illumination would be better, presumably. However, it seems as though this makes it tricky to build for WebGL. To be investigated. 

# Build for WebGL
- Select ```File``` -> ```Build Settings```, select WebGL, and press ```Switch Platform```. That takes some time as Unity pre-processes a bunch of stuff.
- You'll need to disable compression on the build; for some reason the compression causes the WebGL app to load to 90% and stop.
  - In the Build Settings pane, push the ```Player Settings...``` button on the lower left. Select ```Player``` along the left, and set ```Compression Format``` to Disabled.
- Push the Build button. If you're on Linux and encounter a failure, it might be the library issue in the Gotchas section of the [Unity setup](/docs/unity_setup) instructions.
- If it works, it'll output a folder containing an index.html file and a couple of folders full of data. That's what you'll stick on a Web server somewhere.
  - To test it locally, ```cd``` into the folder, and start a tiny local webserver with ```python3 -m http.server --cgi 8360```. Then in your browser type the address ```http://localhost:8360/index.html```.
## Deploy
- Get a server and a domain name, set up the nameservers, install Nginx, [set up SSL with LetsEncrypt](https://www.digitalocean.com/community/tutorials/how-to-secure-nginx-with-let-s-encrypt-on-ubuntu-20-04), stick the index.html file and data folders in the www data directory.
