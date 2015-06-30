using UnityEngine;
using System.Collections;

public class BNG_SlidingDoor : MonoBehaviour
{
    
    public float openSpeed = 1.0f;
    public float smooth = 5.0f;
    public float moveDistance = 5.1f;
    private Vector3 startPos;
    private Vector3 endPos;
    private float startTime;
    private float journeylength;
    private bool canOpen = true;
    private bool canClose = false;
    private bool isOpening = false;
    private bool isClosing = false;
    private bool isOpen = false;
    private bool isClosed = true;

	// Use this for initialization
	void Start () {

        startPos = transform.position;
        endPos = new Vector3(startPos.x, startPos.y - moveDistance, startPos.z);	

	}
	
	// Update is called once per frame
	void Update () {

        if (isOpening && canOpen && !isOpen)
        {
            doOpen();

        }
        else if(isClosing && canClose && !isClosed)
        {
            doClose();

        }

	}

    void OpenDoor()
    {
        canOpen = true;
        isOpening = true;
        canClose = false;
        isClosing = false;

        startTime = Time.time;
        journeylength = Vector3.Distance(transform.position, endPos);     
   
    }

    void CloseDoor()
    {
        canClose = true;
        isClosing = true;
        canOpen = false;
        isOpening = false;

        startTime = Time.time;
        journeylength = Vector3.Distance(transform.position, startPos);
    }

    void doOpen()
    {

        float distCovered = (Time.time - startTime) * openSpeed;
        float fracJourney = distCovered / journeylength;
        transform.position = Vector3.Lerp(transform.position, endPos, fracJourney);

        if (transform.position == endPos)
        {
            //done
            isOpening = false;
            canOpen = false;
            isOpen = true;
            isClosing = false;
            canClose = true;
            isClosed = false;
        }

    }

    void doClose()
    {
        float distCovered = (Time.time - startTime) * openSpeed;
        float fracJourney = distCovered / journeylength;
        transform.position = Vector3.Lerp(transform.position, startPos, fracJourney);

        if (transform.position == startPos)
        {
            //done
            isClosing = false;
            canClose = false;
            isClosed = true;
            isOpening = false;
            canOpen = true;
            isOpen = false;
        }
    }

}
