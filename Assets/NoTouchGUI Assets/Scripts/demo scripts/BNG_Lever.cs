using UnityEngine;
using System.Collections;

public class BNG_Lever : MonoBehaviour
{

    public bool positionUp = true;
    public float leverSpeed = 1.0f;

    public GameObject callbackOnFlipDown = null; //object to call a FlippedDown function on when the switch is done flipping, this game object should have a script with a FlippedDown function
    public GameObject callbackOnFlipUp = null;  //object to call a FlippedUp functionon when the switch is done flipping, this game object should have a script with a FlippedUp function

    private float rotationAmount = 90.0f;
    private Vector3 startRot;
    private Vector3 endRot;
    private float startTime;
    private float journeylength;

    private bool canFlip = true;
    private bool isFlipping = false;
    

	// Use this for initialization
	void Start () {

        startRot = transform.rotation.eulerAngles;

	}
	
	// Update is called once per frame
	void Update () {

        if (canFlip && isFlipping)
        {
            if (positionUp)
            {
                doFlipDown();
            }
            else
            {
                doFlipUp();
            }          

        }
	
	}

    public void leverDown() //levers up move it down
    {
     
        canFlip = true;
        isFlipping = true;

        startTime = Time.time;
        journeylength = 90;
        endRot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z + rotationAmount);

    }

    public void leverUp() //levers down move it up
    {
        canFlip = true;
        isFlipping = true;

        startTime = Time.time;
        journeylength = 90;
        endRot = new Vector3(transform.rotation.eulerAngles.x, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z - rotationAmount);
    }

    void doFlipDown()
    {
        float distCovered = (Time.time - startTime) * leverSpeed;
        float fracJourney = distCovered / journeylength;
        
        Vector3 newRot = Vector3.Lerp(transform.rotation.eulerAngles, endRot, fracJourney);
        transform.rotation = Quaternion.Euler(newRot.x, newRot.y, newRot.z);

        if (transform.rotation.eulerAngles.z >= (endRot.z - .1))
        {
            //done
            canFlip = true;
            isFlipping = false;
            positionUp = false;

            if(callbackOnFlipDown != null) callbackOnFlipDown.SendMessage("FlippedDown");

        }
    }

    void doFlipUp()
    {

        float distCovered = (Time.time - startTime) * leverSpeed;
        float fracJourney = distCovered / journeylength;
        
        Vector3 newRot = Vector3.Lerp(transform.rotation.eulerAngles, endRot, fracJourney);
        transform.rotation = Quaternion.Euler(newRot.x, newRot.y, newRot.z);

        if (transform.rotation.eulerAngles.z <= (endRot.z + .1))
        {
            //done
            canFlip = true;
            isFlipping = false;
            positionUp = true;

            if (callbackOnFlipUp != null) callbackOnFlipUp.SendMessage("FlippedUp");
        }

    }

    

}
