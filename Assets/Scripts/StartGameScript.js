#pragma strict
//This script will fade the camera to black when you lean into an object
//tagged with "Fade". The object has to have a collider attached to it

//This script goes on only one of the fade boxes

var OVRCameraController : Transform;

function Start () {

}

function Update () {

}

//Setting variables for the fade out and scene switching (see FadeInOut.js)
function launchScene () {
	

		//OVRCameraController.GetComponent(fadeInOut).fade = true;
			//this sets the name of the scene you want to load
		OVRCameraController.GetComponent(fadeInOut).levelToLoad = "Level1";
		
		//this tells it to fade and load a level
		OVRCameraController.GetComponent(fadeInOut).changeLevelFade = true;

	
}

//Basic function to exit the game...
function exitGame () {
	
	Debug.Log("APP IS GOING TO QUIT!");
		Application.Quit();

}

//Basic function to exit to main...
function exitToMainMenu () {
	
		OVRCameraController.GetComponent(fadeInOut).levelToLoad = "GameMenu";
		
		//this tells it to fade and load a level
		OVRCameraController.GetComponent(fadeInOut).changeLevelFade = true;

}


//Basic function to launch credit screen...
function launchCredits () {
	
		OVRCameraController.GetComponent(fadeInOut).levelToLoad = "EndingCreds";
		
		//this tells it to fade and load a level
		OVRCameraController.GetComponent(fadeInOut).changeLevelFade = true;

}



