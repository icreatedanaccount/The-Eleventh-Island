#pragma strict
//This script will fade the camera to black when you lean into an object
//tagged with "Fade". The object has to have a collider attached to it

//This script goes on only one of the fade boxes

var OVRCameraController : Transform;
var pause : GameObject;
var isPaused : boolean;

function Start () {
	pause = GameObject.FindWithTag("PauseScreen");
	isPaused = false;
}

function Update () {
	if (Input.GetKeyDown (KeyCode.Escape))
			isPaused = !isPaused;

		
		if (isPaused){
			Time.timeScale = 0f;
			pause.SetActive(true);
		}
		else{
			Time.timeScale = 1.0f;
			pause.SetActive(false);
		}
		
		if (isPaused && Input.GetKeyDown(KeyCode.Q)){
			Debug.Log("Passe dans le if");
			isPaused = !isPaused;
			Time.timeScale = 1.0f;
			OVRCameraController.GetComponent(fadeInOut).levelToLoad = "GameMenu";
		
			//this tells it to fade and load a level
			OVRCameraController.GetComponent(fadeInOut).changeLevelFade = true;
		}
}



