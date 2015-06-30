using UnityEngine;
using System.Collections;

public class BNG_HideShowWindow : MonoBehaviour
{

    public GameObject windowToShowOrHide;

    private static BNG_ToggleCharacterController tcc; //the ultimate reference to the character controller

    private bool isOpen;


    // Use this for initialization
    void Start()
    {

        if (windowToShowOrHide.activeInHierarchy)
        {
            isOpen = true;
        }

        //you have to have the intro screen on b/c it holds the reference to toggle the character controller
        if (GameObject.Find("CharacterControllerObject") != null)
        {
            if (GameObject.Find("CharacterControllerObject").activeInHierarchy)
            {
                tcc = GameObject.Find("CharacterControllerObject").GetComponentInChildren<BNG_ToggleCharacterController>(); //there can only be one! of these references
                tcc.setupCC();

                //if the intro screen is not null, and is hidden, don't disable the character controller
                if (GameObject.Find("Intro Screen") != null)
                {
                    if (GameObject.Find("Intro Screen").transform.gameObject.activeInHierarchy) tcc.disablePlayer();
                }
            }
        }

    }

    public void doWindow()
    {

        if (isOpen) closeWindow();
        else openWindow();

    }

    void closeWindow()
    {
        if (tcc != null)
        {
            if (tcc.isEnabled == false)
            {
                windowToShowOrHide.SetActive(false);
                tcc.enablePlayer();
            }
        }
        else
        {
            windowToShowOrHide.SetActive(false);
        }

    }

    void openWindow()
    {

        if (tcc != null)
        {
            if (tcc.isEnabled == true)
            {
                windowToShowOrHide.SetActive(true);
                tcc.disablePlayer();
            }
        }
        else
        {
            windowToShowOrHide.SetActive(true);
        }

    }
}
