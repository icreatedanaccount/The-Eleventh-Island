using UnityEngine;
using System.Collections;

public class BNG_ToggleCharacterController : MonoBehaviour
{

    /* determine what the active player is vr or non vr
     * get references to all the controllers and buttons
     * disable and enable these when windows are open or closed
     * */

    
    public float rayLengthWhenPlayerDisabled = 5f;

    private static CharacterController pcc;
    private static BNG_Zapper chscript;
    private static GameObject Player;
    private static GameObject CamGroup;
    private static GameObject walkButton;
    private static float ogRay;

    private int doOnce = 0;

    [HideInInspector]
    public bool isEnabled = true;

    public void setupCC() //this is a fake singleton that will setup some static references for the character controller to use. FLAG: This may be an issue if you want to have more than 1 Zapper Script.
    {
        if (doOnce < 1)
        {

            print("Character Controller has been successfully setup. You are free to move about the demo.");

            GameObject tempPlayer = GameObject.Find("NON VR PLAYER");

            if (tempPlayer != null)
            {
                Player = tempPlayer;

                CamGroup = GameObject.Find("CAM SYSTEM");
                walkButton = GameObject.Find("NON VR PLAYER/UI ELEMENTS/walkBtn");

                if(Player.GetComponent<CharacterController>() != null) pcc = Player.GetComponent<CharacterController>();
                chscript = GameObject.FindObjectOfType<BNG_Zapper>(); //there is only one zapper so only one script to find
                ogRay = chscript.rayLength;
            }
            else
            {
                //check for our VR Player Types
                tempPlayer = GameObject.Find("Player for VR");
                if (tempPlayer == null || !tempPlayer.activeInHierarchy) tempPlayer = GameObject.Find("VR Player for Durovis Dive");
                if (tempPlayer == null || !tempPlayer.activeInHierarchy) tempPlayer = GameObject.Find("VR Player for Google Cardboard"); //for some reason it doesn't like an if/else stmt here
                
                if (tempPlayer != null)
                {
                    Player = tempPlayer;
                    
                    if (tempPlayer.name == "VR Player for Durovis Dive" || tempPlayer.name == "Player for VR") CamGroup = GameObject.Find("Dive_Camera");
                    else if (tempPlayer.name == "VR Player for Google Cardboard") CamGroup = GameObject.Find("Head");

                    if (tempPlayer.name == "Player for VR") walkButton = GameObject.Find("Player for VR/UI ELEMENTS/walkBtn");
                    else if (tempPlayer.name == "VR Player for Durovis Dive") walkButton = GameObject.Find("VR Player for Durovis Dive/UI ELEMENTS/walkBtn");
                    else if (tempPlayer.name == "VR Player for Google Cardboard") walkButton = GameObject.Find("VR Player for Google Cardboard/UI ELEMENTS/walkBtn");

                    if (Player.GetComponent<CharacterController>() != null) pcc = Player.GetComponent<CharacterController>();
                    chscript = GameObject.FindObjectOfType<BNG_Zapper>(); //there is only one [active] zapper so only one script to find
                    ogRay = chscript.rayLength;
                }
                else
                {
                    Debug.LogError("No Active Player Found on this Scene. Please activate one of the Players (NON VR PLAYER or Player for VR)");
                    return;
                }
            }

            doOnce++;
        }
    }

    public void enablePlayer()
    {
        //this means a window was closed so get player references to it's components and turn them on
        //also set the ray length to the original ray length in Zapper script
        print("ENABLING PLAYER CONTROLLER");

        isEnabled = true;
        pcc.enabled = true;
        walkButton.SetActive(true);
        chscript.rayLength = ogRay;

    }

    public void disablePlayer()
    {
        //this means a window is open so get player references to it's components and shut them off
        //also set the ray length to something higher like a 4 or 5,
        //but make sure they can't activate more objects from where they will be stuck
        //if they activated another window it could screw things up but we can fix later

        print("DISABLING PLAYER CONTROLLER");

        isEnabled = false;
        pcc.enabled = false;        
        walkButton.SetActive(false);
        chscript.rayLength = rayLengthWhenPlayerDisabled;        

    }
}
