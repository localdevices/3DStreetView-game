# Build a Unity project to explore an ODM mesh

## Prerequisites
- You need to have Unity Hub installed.
- You need a mesh with the y-axis facing up (normally ODM places the z-axis facing up, so you'll need to [rotate it in Meshlab according to these instructions](script/rotate_mesh_in_meshlab.md).

## Create the project
- Open Unity Hub, and hit the New button. From the templates, choose 3D.
  - Choose an appropriate directory and follow the instructions.

## Add the ODM mesh
- Open your file explorer, and in the Unity directory, go to the ```Assets``` subdirectory. In it, create a directory called ```odm_mesh```.
- Drop the entire ```odm_textured_model``` directory in there, _including the .obj file with the y-axis facing up_.
- Head back to the Unity editor, which will proceed to import the model (takes a few minutes).
- Drag the .obj file into the Hierarchy window on the upper left (in the Sample Scene).

## Add the First-Person Character Controller
Nice video that gives a lot of the process [here](https://www.youtube.com/watch?v=Gxmx69QVuRY)
- Go to Unity Asset Store in web browser
- Grab the Standard Assets
- Download them
- Import the FPS Controller and Utility tools
- Fix the compiler errors
  - Go to the github with the fix scripts and overwrite them in the file explorer
- In the ```Project``` window, go to ```Assets```, ```Standard Assets```, ```Characters```, ```FirstPersonCharacter```, ```Prefabs```, and drop the FPSController into the Hierarchy window.
- In the Hierarchy window, expand the FPSController arrow, and click the FirstPersonCharacter icon.
  - It'll probably place it in an unhelpful location. Head over to the Inspector and set the z position to 0.

