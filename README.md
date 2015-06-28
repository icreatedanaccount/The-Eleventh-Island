# The Eleventh Island
Is an adventure/exploration first-person game using randomized maze generators on different levels. 
Developed with Unity 3D (5.1f3)


IMPORTANT
-------
Assets currently in use : Medieval Environment + Standard Assets (Water4 + GlobalFog).

CONVERTED PROJECT TO UNITY 5.1 !

UI BUILDER : https://www.assetstore.unity3d.com/en/#!/content/29757

AncientStatues (Assets) were not added to repo for size issues... (See Dropbox)

DONE
-------

0. Maze generation algorithm
0. 3D Prefab for top-opened cubes synchronized with Grid.js script
0. Algorithm directions and grid size set from inspector
0. Ground and spawn area, Water (Daylight reflection + wave animation)
0. Rock and ground textures added to plateau, Fog, Skybox (Day)
0. First Person controls
0. RigidBody caracter
0. Add camera to player
0. Edit Grid script -> maze is generated on top of the plateau
0. Resize Maze to fit environment and player's body (too small and walls to thin)
0. Resize Cells to 6x6 units and enlarge walls
0. Added Oculus Integration for runtime and builds (CTRL-P to escape rift in game mode)
0. Fade in for Scene (https://gist.github.com/NovaSurfer/5f14e9153e7a2a07d7c5)
0. Add Rock Prefabs to environment (cliffs)
0. Add Audio Source (Ambient Music)
0. Saturation (Main Camera)
0. Depth Of Field (Main Camera)
0. Motion Blur (Main Camera)
0. Vignettes (Main Camera)
0. Bloom and Sparkles (Main Camera)
0. STATUES ! (main entrance + end)

TODO
-------
0. Add Start Menu
0. Add Pause feature
0. Write level completion script (fade out to next scene when player steps on final platform) https://www.youtube.com/watch?v=jtSVnV9iVk8
...

BUGS
-------
1- Fog is not rendering on water -> FIXED
