#pragma strict

//this script needs to know what object has yor fadeInOut script attached to it
//so it can controll the fadeInOut script's variables.
var OVRCameraController : Transform;

function Start () {

}

function Update () {
	
	if (Input.GetKeyDown(KeyCode.Space)) {
		
		//this sets the name of the scene you want to load
		OVRCameraController.GetComponent(fadeInOut).levelToLoad = "Level1";
		
		//this tells it to fade and load a level
		OVRCameraController.GetComponent(fadeInOut).changeLevelFade = true;
		
		//if you want to fade without loading a level use this.
		//true will start it fading to black
		//false will start it fading to clear
		//OVRCameraController.GetComponent(fadeInOut).fade = true; 
	}
	
}