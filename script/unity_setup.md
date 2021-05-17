# Set up a Unity development environment

## On Ubuntu 20.04
- Download the UnityHub.appimage installer [from here](https://unity3d.com/get-unity/download), ```sudo chmod +x``` it, and run it (```./UnityHub.appimage```). If you don't have a Unity account you'll have to create one to manage the license procedure. [Instructions here](https://docs.unity3d.com/Manual/GettingStartedInstallingHub.html) from the official Unity documentation.
- From within the Unity Hub, create an editor Install. You might as well go for the latest Long-Term Support (LTS) version, which as of now is 2020.3. It gives you a selection of build targets; I've installed the Linux, Mac, Windows, and Android frameworks.
- Start a new project. Choose the 3D template. Put the project directory somewhere sensible (it defaults to your home directory).
- Go into the project directory, and drop the entire contents of the ```odm_texturing``` directory from OpenDroneMap into the ```Assets``` directory. That'll take a while, because Unity does some kind of processing and copying whilst pulling in the textures.
- Go back into the Unity Editor window, where a bunch of assets should now appear. Find the ```odm_textured_model_geo.obj``` file and drop it into the view window.  