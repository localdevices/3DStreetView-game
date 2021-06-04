# Rotate a mesh in Meshlab
OpenDroneMap outputs meshes with the Cartesian axes oriented the way a cartographer would expect them (x-axis pointing east, y-axis pointing north, and z-axis pointing up). The scripts in Unity generally function with axes pointing in the way the makes sense for a video game (x-axis toward the right of the screen, y-axis toward the top of the screen, and z-axis pointing up from the screen toward the viewer).

There are only two obvious ways to deal with this; we could write/modify our Unity scripts to see the z-axis as up, or we could rotate the meshes created by ODM to face upward in the y-axis direction. for now, we'll rotate the meshes (though this is probably not the best long-term solution as eventually we'll want to incorporate more geography into the game).

## Instructions
- Install [Meshlab](https://www.meshlab.net/), open it, and press ```file``` -> ```Import Mesh```. In the ODM output folder, you should see a file called ```odm_textured_model_geo.obj```. Select it. It should open and appear on screen.
- Find the button ```Draw XYZ axes in world coordinates``` and press it, you''ll see the axes appear. You can zoom in and out and rotate the mesh with the mouse.
  - If the coordinates in the photos uploaded to ODM were accurate, the z-axis arrow will be pointing straight up from the ground in the mesh. However, it's not uncommon for the mesh to be askew due to low-accuracy GNSS elevation measurements. Don't worry about it; we're just going to rotate the mesh until the y-axis (green) arrow is pointing straight up.
- Select ```Filters``` -> ```Normals, Curvatures, and Orientation``` -> ```Transform: Rotate```.
  - If you check the Preview checkbox, you'll either be able to see the mesh rotate in real-time as you select the relevant angles, _or_ you'll see your computer bog down trying to keep up (in which case you might as well uncheck the box again and go with trial and error).
  - By default it rotates around the x-axis, which conveniently is exactly what you want if the mesh is well-oriented with the z-axis up; you just rotate by either 90&deg; or 270&deg; so that the green y-axis arrow points up. Otherwise you will have to rotate on a few axes before getting it perfectly straight (experiment until it looks right). 
  - You can continue rotating the mesh on the screen to see your progress.
- Once you've got the mesh rotated so that the y-axis faces up, go to ```File``` -> ```Export Mesh As``` and give it a name (I usually name it something like ```my_location_y-axis_up``` to make it easier to figure out which one to use later). 
