using UnityEngine;
using System.Collections;
using System.Collections.Generic;

/* This turret script works fine, it's not great, you will probably want to tweak the settings a bit,
 * I thought about setting the timers all to 0 and using a Coroutine to handle the 'hit delay' 
 * but I will try to make a cool update in the future with a real turret demo in it's own scene with game logic to replace this one*/


public class BNG_TurretAction : MonoBehaviour
{
    public GameObject gunLeft; //the 2 guns are our way to get to the particle systems in them, and I was going to use them to recoil too but didn't have time yet
    public GameObject gunRight;
    public GameObject walkButtonVR; // had to do this b/c we're running different player models in the same scene, it's a kludge for sure. i didn't feel like messing with it anymore.
    public GameObject walkButtonCardboardVR; // had to do this b/c we're running different player models in the same scene, it's a kludge for sure. i didn't feel like messing with it anymore.
    public GameObject walkButtonDiveVR; // had to do this b/c we're running different player models in the same scene, it's a kludge for sure. i didn't feel like messing with it anymore.
    public GameObject walkButtonNonVR; // had to do this b/c we're running different player models in the same scene, it's a kludge for sure. i didn't feel like messing with it anymore.


    private GameObject Player;
    private GameObject walkButton;
    private GameObject CamGroup;
    private CharacterController pcc;
    private BNG_Zapper chscript;
    private GameObject cam;
    private bool inTurret;
    private Vector3 turretOriginalPosition;
    private Quaternion turretOriginalRotation;
    private Vector3 camOriginalPosition;
    private Quaternion camOriginalRotation;
    private GameObject playerRespawnPoint;
    private GameObject camPosMarker;
    private bool isShooting;
    private bool canShoot;
    private float ogRay;
    [HideInInspector]
    public GameObject objectBeingHit;
    private GameObject quitBtn;
    private int score;

	// Use this for initialization
	void Start () {

        setupPlayerAndCam();

        inTurret = false;

        turretOriginalPosition = transform.position;
        turretOriginalRotation = transform.rotation;

        chscript = GameObject.Find("Crosshair").GetComponent<BNG_Zapper>();
        if (chscript == null) Debug.LogError("It seems like you are trying to use this script but do not have the BNG_Zapper script attached to your 'Crosshair' game object.");

        quitBtn = GameObject.Find("Quit Turret");
        quitBtn.SetActive(false);

        ogRay = chscript.rayLength;

        gunLeft.GetComponentInChildren<ParticleSystem>().Stop(false);
        gunRight.GetComponentInChildren<ParticleSystem>().Stop(false);

        canShoot = true;
        isShooting = false;

        score = 0;
    }
	
	
    void setupPlayerAndCam()
    {

        GameObject tempPlayer = GameObject.Find("NON VR PLAYER");

        if (tempPlayer != null)
        {
            Player = tempPlayer;
            CamGroup = GameObject.Find("CAM SYSTEM");
            camOriginalRotation = CamGroup.transform.rotation;
            pcc = Player.GetComponent<CharacterController>();
            camPosMarker = GameObject.Find("camtransformforturret_nonVR");
            walkButton = walkButtonNonVR;
            playerRespawnPoint = GameObject.Find("nonVRPlayerRespawnPoint");
        }
        else
        {
            tempPlayer = GameObject.Find("Player for VR");
            if (tempPlayer == null || !tempPlayer.activeInHierarchy) tempPlayer = GameObject.Find("VR Player for Durovis Dive");
            if (tempPlayer == null || !tempPlayer.activeInHierarchy) tempPlayer = GameObject.Find("VR Player for Google Cardboard");

            if (tempPlayer != null)
            {
                Player = tempPlayer;

                // if Dive or Cardboard
                if (tempPlayer.name == "VR Player for Durovis Dive" || tempPlayer.name == "Player for VR") CamGroup = GameObject.Find("Dive_Camera");
                else if (tempPlayer.name == "VR Player for Google Cardboard") CamGroup = GameObject.Find("Head");                

                camOriginalRotation = CamGroup.transform.rotation;
                pcc = Player.GetComponent<CharacterController>();

                if (tempPlayer.name == "VR Player for Durovis Dive" || tempPlayer.name == "Player for VR") camPosMarker = GameObject.Find("camtransformforturret_VR");
                else if (tempPlayer.name == "VR Player for Google Cardboard") camPosMarker = GameObject.Find("camtransformforturret_VR");//camtransformforturret_CarboardVR");

                if (tempPlayer.name == "Player for VR") walkButton = walkButtonVR;
                else if (tempPlayer.name == "VR Player for Durovis Dive") walkButton = walkButtonDiveVR;
                else if (tempPlayer.name == "VR Player for Google Cardboard") walkButton = walkButtonCardboardVR;
                
                playerRespawnPoint = GameObject.Find("VRPlayerRespawnPoint");

            }
            else
            {
                Debug.LogError("No Activate Player Found on this Scene. Please activate one of the Players (NON VR PLAYER or one of the VR Players");
            }
        }

    }
    
    void SetupTurret()
    {
        inTurret = true;

        quitBtn.SetActive(true);

        pcc.enabled = false;
        walkButton.SetActive(false);
        
        Player.transform.position = camPosMarker.transform.position;
        CamGroup.transform.rotation = camPosMarker.transform.rotation; //this is still gonna kick to the mouse look script and point wherever you are looking

        transform.parent = Player.transform.GetComponentInChildren<Camera>().transform.parent; //setting the turrets transform to that of the players camera so the turret is inside the CamGroup and will rotate with the mouse/vr headset
        transform.position = turretOriginalPosition;
        transform.rotation = turretOriginalRotation;

        chscript.rayLength = 100; // setting it crazy high so you can hit far away targets

    }

    void ExitTurret()
    {
        
        inTurret = false;

        quitBtn.SetActive(false);

        Player.transform.position = playerRespawnPoint.transform.position;
        CamGroup.transform.rotation = camOriginalRotation;

        if (Player.name == "Player for VR" || Player.name == "VR Player for Durovis Dive" || Player.name == "VR Player for Google Cardboard") Player.SendMessage("jumpAndSpin");

        pcc.enabled = true;
        walkButton.SetActive(true);

        transform.parent = Player.transform.parent; //assuming player is in the top of the hierarchy
        transform.position = turretOriginalPosition;
        transform.rotation = turretOriginalRotation;        

        chscript.rayLength = ogRay; // since we set it crazy high so you can hit far away targets, gotta set it back

    }


    public void hittingTarget(GameObject hitObject)
    {

        objectBeingHit = hitObject;
        //print(hitObject);

        isShooting = true;      

        //add muzzle flash
        gunLeft.GetComponentInChildren<ParticleSystem>().Emit(1);
        gunRight.GetComponentInChildren<ParticleSystem>().Emit(1);

        //do points
        score += 50;
        print("Score: " + score);

        //do whatever other shooting logic here (recoil, effects, etc for when target is hit) 

    }


}

