using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackGRoundMusic : MonoBehaviour
{

    public AudioManager Audio;
	
	
	void Start()
    {
        Audio.Play("CreepyMusic");	
	}
}
