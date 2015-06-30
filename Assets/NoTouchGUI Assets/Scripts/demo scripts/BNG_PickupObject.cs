using UnityEngine;
using System.Collections;

public class BNG_PickupObject : MonoBehaviour
{

    public bool respawnMe;  // does object respawn
    public float respawnTime = 5f; // if so, how long should it wait
    
    private bool pickedUp = false;
    private GameObject clone;
    private Vector3 ogPos;

	// Use this for initialization
	void Start () {

        clone = transform.gameObject;
        ogPos = transform.position;
        
	}
	
    void doGun()
    {
        print("YOU PICKED UP A SWEEEEET GUN, YO!");
        transform.position = new Vector3(transform.position.x, transform.position.y + 1000, transform.position.z);
        pickedUp = true;

        if (respawnMe) StartCoroutine(WaitToRespawn(respawnTime));
        else DestroyImmediate(transform.gameObject);
       
    }

    void doAmmo()
    {

        print("YOU PICKED UP SOME AMMO!");
        transform.position = new Vector3(transform.position.x, transform.position.y + 1000, transform.position.z);
        pickedUp = true;

        if (respawnMe) StartCoroutine(WaitToRespawn(respawnTime));
        else DestroyImmediate(transform.gameObject);

    }
    

    IEnumerator WaitToRespawn(float respawnTime)
    {
        yield return new WaitForSeconds(respawnTime);
        transform.position = ogPos;

    }
}
