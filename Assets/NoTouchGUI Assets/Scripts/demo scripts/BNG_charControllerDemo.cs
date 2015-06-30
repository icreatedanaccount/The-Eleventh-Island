using UnityEngine;
using System.Collections;

public class BNG_charControllerDemo : MonoBehaviour
{

    public GameObject VRPlayer = null;
    public GameObject DiveVRPlayer = null;
    public GameObject CardboardVRPlayer = null;
    public GameObject nonVRPlayer = null;
    private GameObject Player;
    [HideInInspector]
    public bool shouldRotate = false;
    private float totalRot = 0;

	// Use this for initialization
	void Start () {

        if (nonVRPlayer != null && nonVRPlayer.activeInHierarchy)
        {
            Player = nonVRPlayer;
            //VRPlayer = null;
        }
        else if (VRPlayer.activeInHierarchy || DiveVRPlayer.activeInHierarchy || CardboardVRPlayer.activeInHierarchy)
        {
            Player = VRPlayer;

            if (!Player.activeInHierarchy)
            {
                Player = DiveVRPlayer;

                if (!Player.activeInHierarchy)
                {
                    Player = CardboardVRPlayer;

                    if (!Player.activeInHierarchy)
                    {
                        Debug.LogWarning("NO ACTIVE PLAYER. Character Controller demo will not function.");
                    }
                } 

            }
        }



	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (shouldRotate)
        {
            float newRoty = (Player.transform.rotation.eulerAngles.y + (Time.deltaTime * 200));
            
            totalRot += (Time.deltaTime * 180);
            Player.transform.rotation = Quaternion.Euler(Player.transform.rotation.eulerAngles.x, newRoty, Player.transform.rotation.eulerAngles.z);

            if (totalRot >= 180)
             {
                 shouldRotate = false;
                 totalRot = 0;

                 if(Player.name == "Player for VR" || Player.name == "VR Player for Durovis Dive" || Player.name == "VR Player for Goolge Cardboard") Player.SendMessage("enableC");
             }
        }
	
	}

    void jumpAndSpin()
    {
        shouldRotate = true;

		if (VRPlayer.activeInHierarchy && !nonVRPlayer.activeInHierarchy)
        {
            if (VRPlayer.name == Player.name)
            {

                Player.SendMessage("jumpAndSpin", this); //i setup a function from within the DiveFPSController so I could control it since it's not a standard asset
                Player.SendMessage("disableC");
            }
        }
		else if (nonVRPlayer.activeInHierarchy && !VRPlayer.activeInHierarchy)
        {
            if (Player.name == nonVRPlayer.name)
            {
                Player.SendMessage("jumpAndSpin", this);
            }

        }
        
    }
}
