using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BNG_DemoMenu : MonoBehaviour
{

    public List<GameObject> Menus;

    private List<int> currentMenuChoices = new List<int>(); //sfx, music, autoaim, difficulty

    private GameObject selectedDifficultyOption = null;

	// Use this for initialization
	void Start () {

        currentMenuChoices.Add(1); //sfx is on
        currentMenuChoices.Add(1); //music is on
        currentMenuChoices.Add(0); //autoaim is off
        currentMenuChoices.Add(1); //difficulty is 'tough'

        activateMenu(Menus);
        
	}

    #region drop down activation functions

    //you have to set functions for each drop down item b/c we can't pass in a reference to the object through the SendMessage function that ZapperAction uses (too complicated)

    void loadDifficultyMenu()
    {
        openMenu(Menus[2]); //hardcoded, not smart! for demo purposes only. larger menus get really complicated fyi.
        closeMenu(Menus[1]);

        resetActivationFor(GameObject.Find("menuItems_BackToOptionsMenuFromDifficultymenu"));
    }

    void closeDifficultyMenu()
    {
        closeMenu(Menus[2]); //hardcoded, not smart! for demo purposes only. larger menus get really complicated fyi.
        openMenu(Menus[1]);

        resetActivationFor(GameObject.Find("menuItems_DifficultyDropDown"));
        resetActivationFor(GameObject.Find("menuItems_OptionsMenuBackToMainBtn"));
    }

    void loadOptionsMenu()
    {
        openMenu(Menus[1]); //hardcoded, not smart! for demo purposes only. larger menus get really complicated fyi.
        closeMenu(Menus[0]);

        resetActivationFor(GameObject.Find("menuItems_OptionsMenuBackToMainBtn"));
        
    }

    void closeOptionsMenu()
    {
        closeMenu(Menus[1]); //hardcoded, not smart! for demo purposes only. larger menus get really complicated fyi.
        openMenu(Menus[0]);

        resetActivationFor(GameObject.Find("menuItems_Options"));
    }

    void closeAllMenus()
    {
        for (int i = 0; i < Menus.Count; i++)
        {
            closeMenu(Menus[i]);
        }

    }

    #endregion


    #region Button Activation Functions

    void playGame() { print("PLAY GAME: You can do stuff like load levels/scenes or transport the player to another location"); }
    void quitGame() { print("QUIT GAME: You can quit application or quit to main menu from here."); closeAllMenus(); }
    void saveAndClose() { print("SAVE AND CLOSE: Maybe write the options to some code and load them for next time!"); }

    // you could plug in your "gameDifficultyManager" to this script and then use these functions to change the difficulty. for example: gameDifficultyManager.setDifficulty(0); where 0 easy
    void setDifficultyToEasy() { print("Difficulty Set To: Easy");  setDifficulty(0); } //remember currentMenuChoices[3] is difficulty options
    void setDifficultyToTough() { print("Difficulty Set To: Tough");  setDifficulty(1); }
    void setDifficultyToChallenging() { print("Difficulty Set To: Challenging"); setDifficulty(2); }
    void setDifficultyToInsane() { print("Difficulty Set To: Insane!!! OH SNAP!"); setDifficulty(3); }

    void setDifficulty(int x)
    {

        if (currentMenuChoices[3] == x) return;

        int currentDifficulty = currentMenuChoices[3];

        int count = 0;        
          
        foreach (Transform menuItem in Menus[2].transform) //Menu's 2 are the difficulty options
        {

            if (count == currentDifficulty)
            {
                //print("FOUND CURRENT: " + menuItem.gameObject.name);
                resetActivationFor(menuItem.gameObject);
                menuItem.gameObject.tag = "NoTouchButton";
            }

            count++;

        }

        count = 0;

        foreach (Transform menuItem in Menus[2].transform) //Menu's 2 are the difficulty options
        {
            if (count == x)
            {
                //print("SET NEW: " + menuItem.gameObject.name);
                setActivationFor(menuItem.gameObject);
                menuItem.gameObject.tag = "Untagged";
            }

            count++;
        }

        count = 0;

        currentMenuChoices[3] = x;        
        
    }

    //same with toggles :)
    void turnSFXOff() { print("Turning Sound Off"); currentMenuChoices[0] = 0; } //remember currentMenuChoices[0] is sfx options
    void turnSFXOn() { print("Turning Sound On"); currentMenuChoices[0] = 1; }

    void turnMusicOff() { print("Turning Sound Off"); currentMenuChoices[1] = 0; } //remember currentMenuChoices[1] is music options
    void turnMusicOn() { print("Turning Sound On"); currentMenuChoices[1] = 1; }

    void turnAutoAimOn() { print("Turning AutoAim On"); currentMenuChoices[2] = 1; } //remember currentMenuChoices[2] is autoaim options
    void turnAutoAimOff() { print("Turning AutoAim Off"); currentMenuChoices[2] = 0; }

    // and this just makes something visible or not
    void showAboutScreen() { print("Show the about screen here please. Right in my face."); }

    #endregion


    void activateMenu(List<GameObject> Menus) //this goes and gets all the children of sub menus and hides them
    {

        foreach (GameObject menu in Menus)
        {
            foreach (Transform menuItem in menu.transform)
            {

                if (menuItem.transform.parent.name == Menus[0].gameObject.name)
                {
                    //if inactive set to active
                    if (!menuItem.transform.gameObject.activeInHierarchy)
                    {
                        menuItem.transform.gameObject.SetActive(true);
                    }
                }
                else
                {
                    //set inactive if active for others but primary
                    if (menuItem.transform.gameObject.activeInHierarchy)
                    {
                        menuItem.transform.gameObject.SetActive(false);
                    }
                }

            }
        }
    }


    void openMenu(GameObject menu){


        //find out what menu is open, turn it off, but save for turning on later.

        foreach (Transform menuItem in menu.transform)
        {
            //if inactive set to active
            if (!menuItem.transform.gameObject.activeInHierarchy)
            {
                menuItem.transform.gameObject.SetActive(true);
            }
        }

    }

    void closeMenu(GameObject menu)
    {
        foreach (Transform menuItem in menu.transform)
        {
            //if inactive set to active
            if (menuItem.transform.gameObject.activeInHierarchy)
            {
                menuItem.transform.gameObject.SetActive(false);
            }
        }
    }

    void resetActivationFor(GameObject go)
    {
        //print("RESET THIS GAME OBJECT: " + go);
        if (go == null)
        {
            Debug.LogWarning("Try checking your reference that you're passing into this function 'resetActivationFor'. Needs to find a specific game object.");
            return;
        }
        else
        {
            if (go.GetComponent<BNG_ZapperAction>() != null)
            {
                BNG_ZapperAction za = go.GetComponent<BNG_ZapperAction>();
                za.isActivated = false;
                za.canActivate = true;

                if (go.GetComponent<SpriteRenderer>() != null)
                {
                    SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
                    sr.color = Color.white;
                }
            }
            
        }

    }

    void setActivationFor(GameObject go)
    {
        //print("RESET THIS GAME OBJECT: " + go);
        if (go == null)
        {
            Debug.LogWarning("Try checking your reference that you're passing into this function 'resetActivationFor'. Needs to find a specific game object.");
            return;
        }
        else
        {
            if (go.GetComponent<BNG_ZapperAction>() != null)
            {
                BNG_ZapperAction za = go.GetComponent<BNG_ZapperAction>();

                if (go.GetComponent<SpriteRenderer>() != null)
                {
                    SpriteRenderer sr = go.GetComponent<SpriteRenderer>();
                    sr.color = za.newColorOnHover;
                }

            }

        }

    }
    
    

}
