# Set up a Unity development environment

## On Ubuntu 20.04
- Download the UnityHub.appimage installer, ```sudo chmod +x``` it, and run it (```./UnityHub.appimage```). If you don't have a Unity account you'll have to create one to manage the license procedure.
- Install a framework and stuff (so far I've only installed the Windows and Linux frameworks)
- Start a new project. Choose the 3D template. Put the project directory somewhere sensible (it defaults to your home directory).
- Go into the project directory, and drop the entire contents of the ```odm_texturing``` directory from OpenDroneMap into the ```Assets``` directory. That'll take a while, because Unity does some kind of processing and copying whilst pulling in the textures.
- Go back into the Unity Editor window, where a bunch of assets should now appear. Find the ```odm_textured_model_geo.obj``` file and drop it into the view window.  