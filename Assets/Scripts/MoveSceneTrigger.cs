using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class MoveSceneTrigger : MonoBehaviour {
	ScreenFader fadeScr;
	public int SceneNumb = 1;
	
	void Start(){
		fadeScr = GameObject.FindObjectOfType<ScreenFader>();
		Debug.Log(fadeScr.ToString());
	}
	
	void OnTriggerEnter(Collider col){
		if(col.gameObject.tag == "Player"){
			fadeScr.EndScene(SceneNumb);

		}
	}
}