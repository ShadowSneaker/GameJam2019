using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGRoundMusic : MonoBehaviour
{

    public AudioManager Audio;
	
	
	void Update ()
    {
        Audio.Play("CreepyMusic");	
	}
}
