﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaterScript : MonoBehaviour {

    public float slowingamount = 0.5f;
    private float originalamount;

    private void OnTriggerEnter(Collider other)
    {
        Entity Thing = other.gameObject.GetComponent<Entity>();

        originalamount = Thing.SpeedModifier;

        Thing.SpeedModifier -= slowingamount;


        FindObjectOfType<AudioManager>().Play("RiplingWater");
    }

    

    private void OnTriggerExit(Collider other)
    {
        Entity Thing = other.gameObject.GetComponent<Entity>();
        FindObjectOfType<AudioManager>().Play("RiplingWater");
        Thing.SpeedModifier += slowingamount;
    }

}
