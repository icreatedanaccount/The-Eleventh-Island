using UnityEngine;
using System.Collections;


[RequireComponent(typeof(ParticleSystem))]

public class BNG_TargetAction : MonoBehaviour
{


    public int hp;
    public GameObject TurretObject;
    public Sprite killSprite;
    private BNG_TurretAction taScript;

    private ParticleSystem particles;
    private SpriteRenderer sr;
    
    //each target has this script that will collect damage and report status, as well as change sprite to dead sprite.
    //turret action can access this script by finding it, it will call the on hit function and kill functions

	// Use this for initialization
	void Start () {

        //get the script on the turret so we can do what we want with it
        taScript = TurretObject.GetComponent<BNG_TurretAction>();
        
        particles = new ParticleSystem();
        sr = GetComponent<SpriteRenderer>();
	}
	
	// Update is called once per frame
	void Update () {

        if (hp == 0)
        {
            sr.sprite = killSprite;
            return;
        }
	
	}

    void doHit()
    {
        hp--;

        taScript.hittingTarget(transform.gameObject);

        //you could do blood splatter or hit effects here.

        if (hp == 0)
        {
            doKill();
        }

    }

    void doWait()
    {
        //this is happening when the object is deactivated, an intermediary split second

    }

    void doKill()
    {
        //print("kill");
        hp = 0;
        
        //do some kill effects, particles or whatever.


        //you can set the layer to ignore raycast like this and the zapper will not hit it.
        transform.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");

        //you have 2 seconds before it blows!
        Destroy(transform.gameObject, 2f);

    }
}
