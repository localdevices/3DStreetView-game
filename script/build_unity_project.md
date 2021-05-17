# Build a Unity project to explore an ODM mesh

## Prerequisites
- You need to have Unity Hub installed and an empty project based on teh 3D template running. Hopefully you followed [these instructions](/script/unity_setup.md).
- You need a mesh with the y-axis facing up (normally ODM places the z-axis facing up, so you'll need to [rotate it in Meshlab according to these instructions](/script/rotate_mesh_in_meshlab.md).

## Add the ODM mesh
- Open your file explorer, and in the Unity directory, go to the ```Assets``` subdirectory. In it, create a directory called ```odm_mesh```.
- Drop the entire ```odm_textured_model``` directory in there, _including the .obj file with the y-axis facing up_.
- Head back to the Unity editor, which will proceed to import the model (takes a few minutes).
- Drag the .obj file into the Hierarchy window on the upper left (in the Sample Scene).

## Add the First-Person Character Controller
Nice video that gives a lot of the process [here](https://www.youtube.com/watch?v=Gxmx69QVuRY)
- Go to Unity Asset Store. In the ```Window``` menu there's a link to the Unity Asset Store, which anyway opens in a web browser (it's also [here](https://assetstore.unity.com/)). You have to be signed in to a Unity account to make this work, but presumably you have an account that you created in order to install the Unity Hub; let's hope you remember the password.
- Grab the Standard Assets (as of time of writing, they're called _Standard Assets for Unity 2018.4_). You can't download them directly, you click a link ```Open in Unity``` and, if all goes well, return to the Unity editor and download them via the Package Manager.
- After downloading the Standard Assets, you need to import them. You only actually need to import the FPS Controller and Utility sections, but I don't think it does a great deal of harm to import everything (maybe it makes your eventual builds bigger, but not obviously from what I can see). 
- [Fix the compiler errors](/script/fix_standard_asset_compiler_errors.md) which will otherwise prevent you from using the Standard Assets.
- In the Hierarchy window, expand the FPSController arrow, and click the FirstPersonCharacter icon.
  - It'll probably place it in an unhelpful location. Head over to the Inspector and set the z position to 0.

