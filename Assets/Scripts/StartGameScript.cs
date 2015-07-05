using UnityEngine;
using System.Collections;

public class StartGameScript : MonoBehaviour {

	
	ScreenFader fadeScr;
	public int SceneNumb;

	// Use this for initialization
	void Start () {
		fadeScr = GameObject.FindObjectOfType<ScreenFader>();
	}


	//TO LAUNCH OTHER SCENES : PL
	void launchScene(){
		fadeScr.EndSceneDefault();
	}
}
