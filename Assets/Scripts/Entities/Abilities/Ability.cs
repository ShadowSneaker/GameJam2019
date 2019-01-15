using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Ability : MonoBehaviour
{

    public float Cooldown = 2.0f;
    private bool Active = true;

    public bool StartOnCooldown;

	// Use this for initialization
	void Start ()
    {
		if (StartOnCooldown)
        {
            StartCoroutine(StartCooldown());
        }
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    public void Cast()
    {
        if (Active)
        {
            StartCoroutine(StartCooldown());
        }
    }


    private IEnumerator StartCooldown()
    {
        Active = false;
        yield return new WaitForSeconds(Cooldown);
        Active = true;
    }


    public bool AbilityUp()
    {
        return Active;
    }
}
