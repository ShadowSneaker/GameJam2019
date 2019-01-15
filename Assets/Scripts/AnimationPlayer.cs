using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AnimationPlayer : MonoBehaviour
{
    public bool PlayOnStart;
    public bool Reversed;

    private Animation Anim;


	// Use this for initialization
	void Start ()
    {
        Anim = GetComponent<Animation>();

        if (Anim)
        {
            if (PlayOnStart)
            {
                Anim.Play(Anim.clip.name);
            }
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
}
