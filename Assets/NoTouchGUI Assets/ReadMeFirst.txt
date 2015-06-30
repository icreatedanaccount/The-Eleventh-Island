///////////////////////////////////////////////

NO TOUCH GUI for VR QUICK START GUIDE

///////////////////////////////////////////////

First of all, thanks for purchasing the No Touch GUI system!

I hope you will enjoy it and get as much use out of it as I do. 
I really hope you rate it, it really helps me out and that would be 
awesome of you.

/******************************************************/

YOU MUST DO THESE STEPS FOR THE DEMO
& PREFABS TO WORK!!!

Since I can’t include external assets in my project, 
there are a few things you need to do to get the Demo 
scene working properly whether you’re using it for VR 
or regular 3D. The prefabs in the project will have missing
components and not work until these steps are completed!

1. Download the Durovis Dive Unity Plugin from 
https://www.durovis.com/sdk.html and the Google 
Cardboard Unity Plugin located at 
https://developers.google.com/cardboard/unity/download
 
2. Open your project and import the No Touch GUI for VR Asset
 
3. Import the Durovis Dive & Google Cardboard packages 
by going to Assets -> Import Package -> Custom Package 
and select the unity package when prompted. On the import 
dialogue make sure you select Import All.
 
4. If it’s not already there, import the Standard Character 
Controllers by going to Assets -> Import Package -> Character 
Controller. On the import dialogue make sure you select Import All.
 
5. Navigate to the “NoTouchGUI Assets/Scripts/external scripts”
folder and drag the file called “DiveFPSControllerForNotouchGUI.js”
into the “Dive” folder.
 
6. Navigate to the “NoTouchGUI Assets/Scripts/external scripts” folder
and drag the file called “FPSInputControllerForNoTouchGUI.js”
into the “Standard Assets/Character Controllers/Sources/Scripts” folder.
 
7. Navigate to the “NoTouchGUI Assets/Prefabs” folder and 
select the “VR Player for Durovis Dive” prefab, it will have a 
missing script reference. You need to navigate to the “Dive” 
folder in your project view and drag the “DiveFPSControllerForNotouchGUI.js” 
script into the missing script slot in the inspector. You should do this 
for the “Player for VR” prefab as well but it has been depreciated.
 
8. Navigate to the “NoTouchGUI Assets/Prefabs” folder and select 
the “NON VR PLAYER” prefab, it will have a missing script reference.
 Navigate to the “Standard Assets/Character Controllers/Sources/Scripts” 
 folder in your project view and drag the “FPSInputControllerForNoTouchGUI.js”
 script into the missing script slot in the inspector. Do this for the 
 “Vr Player for Google Cardboard” prefab as well.
 
9. Now, you can open the Demo Scene found in the “NoTouchGUI Assets/Scenes”
folder and activate either the “Player for VR”, “VR Player for Durovis Dive”, 
“VR Player for Google Cardboard” or the “NON VR PLAYER” game objects 
and be able to move about the scene. You can use the keyboard (WASD)
 keys to move, or look down and use the autowalk toggle.


//////////////////////////////////////////////////////////////////////////////////////////


HERE ARE THE BASIC STEPS FOR SETTING
UP NO TOUCH GUI FOR VR:

(if you would like a detailed explaination, please
check out the PDF documentation in this folder)

1. Drop one of the Player prefabs from the prefabs folder into your scene.
This player already has the camera group setup the way
you want it, with the Player (controller, motor, fps
controller scripts) -> Cam Group (mouse look script/
Open Dive Sensor script) -> Camera, Crosshairs
(BNG_Zapper script attached to crosshairs) 

2. To create a button, drop one of the icon sprites in your scene
or select any game object you want to interact with, we'll call
this the "button" from now on. 

5. Add the BNG_ZapperAction script to your button.

6. Test your game, the crosshairs should change color when
they hover over the object.

7. If not, see trouble shooting section in the PDF.

8. You can go ahead and tweak the settings under the 
Zapper Action script. Check out the demo scene and feel 
free to use any code you need to setup interaction in 
your project.

9. Enjoy! Please rate if you like it, and if you have 
any issues I would be super happy to help you out!

There is a section in the PDF about setting up this 
project for Durovis Dive plugin to use with VR, 
if you drop in the VR Player prefab it should work just fine.


//////////////////////////////////////////////////////////////////////////////////////////


Other than that, hit me up with any questions 
@BaconNeckGames #NoTouchGUI, 
www.baconneckgames.com/contact-us, 
or dev@baconneckgames.com


THANKS FOR PURCHASING!!!


- sean @ bacon neck games



Oh and also, I am creating a new website with forums so we
can jam out and I can setup a proper support channel and also
checkout all the cool projects people are doing with No Touch GUI.
If you are using it in your project, I would love to check it out! Thanks!


(c) 2014 Bacon Neck Games, LLC. All rights reserved.