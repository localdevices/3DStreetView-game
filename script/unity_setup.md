# Set up a Unity development environment

## On Ubuntu 20.04
- Download the UnityHub.appimage installer [from here](https://unity3d.com/get-unity/download), make it executable with ```sudo chmod +x UnityHub.AppImage```, and run it (```./UnityHub.appimage```). If you don't have a Unity account you'll have to create one to manage the only moderately unpleasant license procedure. [Instructions here](https://docs.unity3d.com/Manual/GettingStartedInstallingHub.html) from the official Unity documentation.
- From within the Unity Hub, assuming you've gotten it running, create an editor Install. You might as well go for the latest Long-Term Support (LTS) version, which as of now is 2020.3. It gives you a selection of modules; I've installed the Linux, Mac, Windows, and Android frameworks so I can build running games for all of the above.
- Start a new project. Choose the 3D template. Put the project directory somewhere sensible (it defaults to your home directory).

That should do it. Assuming this all worked, you now have an fresh, empty Unity project based on the 3D template. Now [head to the next step, wherein you'll build a Unity project containing the mesh from OpenDroneMap](script/build_unity_project.md).

There's a further snag coming up, when the Standard Assets package doesn't work with the current release of Unity, but the fix is documented in the instructions coming up next!