#pragma strict
//This script will fade the camera to black when you lean into an object
//tagged with "Fade". The object has to have a collider attached to it

//This script goes on only one of the fade boxes

var OVRCameraController : Transform;

function Start () {

}

function Update () {

}

function OnTriggerEnter (other : Collider) {
	
	if (other.tag == "Player") {
		//OVRCameraController.GetComponent(fadeInOut).fade = true;
			//this sets the name of the scene you want to load
		OVRCameraController.GetComponent(fadeInOut).levelToLoad = "Level1";
		
		//this tells it to fade and load a level
		OVRCameraController.GetComponent(fadeInOut).changeLevelFade = true;
	}
	
}

function OnTriggerExit (other : Collider) {
	
	if (other.tag == "Player") {
		//OVRCameraController.GetComponent(fadeInOut).fade = false;
	}
	
}