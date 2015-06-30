using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class BNG_LightSwitchDemo : MonoBehaviour {

    public List<Light> LightArray;
    private BNG_Lever lever;

    private bool isOn; //simple flag to check to make sure we are only turning things on or off and not some on, some off

	// Use this for initialization
	void Start () {

        lever = GetComponentInChildren<BNG_Lever>();
	
	}

    void FlippedDown() //this is what the lever will call when it is done flipping so action happens after the switch is flipped not immediately
    {
        foreach (Light lights in LightArray)
        {

            Light templight = lights;

            if (templight.intensity == 1) isOn = true;

            if (isOn)
            {
                templight.intensity = .05f; //just a simple example, we could dim them, fade them, change their color, etc
                isOn = false;

            }

        }
    }

    void FlippedUp() //this is what the lever will call when it is done flipping so action happens after the switch is flipped not immediately
    {
        foreach (Light lights in LightArray)
        {
            Light templight = lights;

            if (templight.intensity == 0.05f) isOn = false;

            if (!isOn)
            {
                templight.intensity = 1f;
                isOn = true;

            }

        }
    }
}
