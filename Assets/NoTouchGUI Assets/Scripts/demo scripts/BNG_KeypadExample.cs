using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BNG_KeypadExample : MonoBehaviour
{

    public List<Sprite> KeyedAnswerSprites; //this is the blocks up top that change when you input some code, these are the numbers
    public List<GameObject> emptyKeyAnswerBlocks; //this is the blocks up top that change when you input some code, these are blank
    public Sprite emptyAnswerBlock; //just one of the empty answer blocks for when we reset them

    private List<int> correctAnswer; //this holds the correct 5 digit sequence
    private List<int> currentAnswer; //this holds the current sequence
    private int keyIndex; //this will be our counter for number of keys pressed
    private SpriteRenderer sr; //the sprite renderer for the keyAnswerBlocks
    private int maxKey; //the length of the code
    private BNG_HideShowWindow toggleWindowScript;

	// Use this for initialization
	void Start () {

        keyIndex = 0; //key index only increments for correct answers
        maxKey = emptyKeyAnswerBlocks.Count; //the code is as many digits as there are correct code display blocks

        correctAnswer = new List<int>();

        //create your code for the correct answer here
        correctAnswer.Add(1);
        correctAnswer.Add(3);
        correctAnswer.Add(5);
        correctAnswer.Add(7);
        correctAnswer.Add(9);

        currentAnswer = new List<int>();

        toggleWindowScript = GetComponent<BNG_HideShowWindow>();

	}
	
	// Update is called once per frame
	void Update () {

        //constantly check if they got the right code when this is active
        if (transform.gameObject.activeInHierarchy)
        {
            if (currentAnswer.Count == maxKey) //since only right answers get added, this fills up when it's complete
            {

                print("YOU CRACKED THE CODE YOU SMARTY PANTS!");

                currentAnswer = new List<int>(); //empty the current answers so we can do it again
                keyIndex = 0; //reset the key index

                foreach (GameObject answerBlock in emptyKeyAnswerBlocks)
                {
                    sr = answerBlock.GetComponent<SpriteRenderer>();
                    sr.sprite = emptyAnswerBlock;
                }

                hardResetButtons(); // kludge: fix the zapper action reset on activate in a future update. see function below for more info.

                toggleWindowScript.doWindow(); //THIS FUNCTION IS WHAT HAPPENS WHEN THE CODE IS COMPLETED CORRECLTY (you can choose to open doors, reveal objects... you can do whatever you like)

            }
        }
	
	}

    void handleKey(int pressedKey)
    {
        int k; //the holder for our key so I can copy and paste easier :)

        switch (pressedKey)
        {
            case 0:
                k = 0;
                if (compareKeys(k)) //if the key pressed is the correct key
                {
                    sr = emptyKeyAnswerBlocks[keyIndex].GetComponent<SpriteRenderer>();
                    sr.sprite = KeyedAnswerSprites[k];
                    currentAnswer.Add(k);
                    keyIndex++;
                }
                break;
            case 1:
                k = 1;
                if (compareKeys(k)) //if the key pressed is the correct key
                {
                    sr = emptyKeyAnswerBlocks[keyIndex].GetComponent<SpriteRenderer>();
                    sr.sprite = KeyedAnswerSprites[k];
                    currentAnswer.Add(k);
                    keyIndex++;
                }
                break;
            case 2:
                k = 2;
                if (compareKeys(k)) //if the key pressed is the correct key
                {
                    sr = emptyKeyAnswerBlocks[keyIndex].GetComponent<SpriteRenderer>();
                    sr.sprite = KeyedAnswerSprites[k];
                    currentAnswer.Add(k);
                    keyIndex++;
                }
                break;
            case 3:
                k = 3;
                if (compareKeys(k)) //if the key pressed is the correct key
                {
                    sr = emptyKeyAnswerBlocks[keyIndex].GetComponent<SpriteRenderer>();
                    sr.sprite = KeyedAnswerSprites[k];
                    currentAnswer.Add(k);
                    keyIndex++;
                }
                break;
            case 4:
                k = 4;
                if (compareKeys(k)) //if the key pressed is the correct key
                {
                    sr = emptyKeyAnswerBlocks[keyIndex].GetComponent<SpriteRenderer>();
                    sr.sprite = KeyedAnswerSprites[k];
                    currentAnswer.Add(k);
                    keyIndex++;
                }
                break;
            case 5:
                k = 5;
                if (compareKeys(k)) //if the key pressed is the correct key
                {
                    sr = emptyKeyAnswerBlocks[keyIndex].GetComponent<SpriteRenderer>();
                    sr.sprite = KeyedAnswerSprites[k];
                    currentAnswer.Add(k);
                    keyIndex++;
                }
                break;
            case 6:
                k = 6;
                if (compareKeys(k)) //if the key pressed is the correct key
                {
                    sr = emptyKeyAnswerBlocks[keyIndex].GetComponent<SpriteRenderer>();
                    sr.sprite = KeyedAnswerSprites[k];
                    currentAnswer.Add(k);
                    keyIndex++;
                }
                break;
            case 7:
                k = 7;
                if (compareKeys(k)) //if the key pressed is the correct key
                {
                    sr = emptyKeyAnswerBlocks[keyIndex].GetComponent<SpriteRenderer>();
                    sr.sprite = KeyedAnswerSprites[k];
                    currentAnswer.Add(k);
                    keyIndex++;
                }
                break;
            case 8:
                k = 8;
                if (compareKeys(k)) //if the key pressed is the correct key
                {
                    sr = emptyKeyAnswerBlocks[keyIndex].GetComponent<SpriteRenderer>();
                    sr.sprite = KeyedAnswerSprites[k];
                    currentAnswer.Add(k);
                    keyIndex++;
                }
                break;
            case 9:
                k = 9;
                if (compareKeys(k)) //if the key pressed is the correct key
                {
                    sr = emptyKeyAnswerBlocks[keyIndex].GetComponent<SpriteRenderer>();
                    sr.sprite = KeyedAnswerSprites[k];
                    currentAnswer.Add(k);
                    keyIndex++;
                }
                break;

        }

    }

    bool compareKeys(int key)
    {

        //for this example we're going to use a sticky code, 
        //in which if they get a correct key in the correct sequence,
        //it will add it to the top

        //check key pressed, check keyIndex, if key pressed is equal to keyIndex @ answerKey then accept it, else, do nothing
        //return a true if it is the correct key

        if (key == correctAnswer[keyIndex])
        {
            return true;
        }
        else return false;


    }

    void hardResetButtons()
    {

        /*
         * FIX IN UPDATE:
         * 
         * TL DR: It won't be active if it comes up again, so we have to hard reset all the buttons to make sure
         *  
         * we have to do this b/c the last button pressed already has a function it's calling, 
         * since we're calling doWindow() from inside this function, instead of on it's callFunctionOnActivate property,
         * it is in the wrong order and will therefore not trigger the proper reaction for "Reset on Activate" inside zapperAction script. 
         * 
         * */

        GameObject keyGroup = GameObject.Find("KeypadGroupExample/KEYS");
        BNG_ZapperAction za;

        foreach (Transform key in keyGroup.transform)
        {

            za = key.gameObject.GetComponent<BNG_ZapperAction>();
            za.isActivated = false;
            za.canActivate = true;

        }

    }

    //handle key presses - this is what the zapper action script on this object is calling

    void pressed0()
    {
        handleKey(0);
    }

    void pressed1()
    {
        handleKey(1);
    }

    void pressed2()
    {
        handleKey(2);
    }

    void pressed3()
    {
        handleKey(3);
    }

    void pressed4()
    {
        handleKey(4);
    }

    void pressed5()
    {
        handleKey(5);
    }

    void pressed6()
    {
        handleKey(6);
    }

    void pressed7()
    {
        handleKey(7);
    }

    void pressed8()
    {
        handleKey(8);
    }

    void pressed9()
    {
        handleKey(9);
    }



}
