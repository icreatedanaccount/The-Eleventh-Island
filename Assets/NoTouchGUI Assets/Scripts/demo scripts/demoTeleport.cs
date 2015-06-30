using UnityEngine;
using System.Collections;

public class demoTeleport : MonoBehaviour {

    public Transform newPos;
    public GameObject Player;
    public GameObject ReferenceToToggleCharController;
    public GameObject menuToClose;


	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}


    void teleport()
    {
        Player.transform.position = newPos.position;
        ReferenceToToggleCharController.GetComponent<BNG_ToggleCharacterController>().enablePlayer();
        menuToClose.SetActive(false);
        //GameObject.Find("demoMenu").transform.gameObject.SetActive(false);
    }
}
