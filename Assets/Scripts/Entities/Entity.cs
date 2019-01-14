using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float MaxHealth = 100.0f;
    protected float Health;

    public float MovementSpeed = 10.0f;

    
	// Use this for initialization
	void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    public void TakeDamage()
    {
        Health -= 50.0f;
    }
}
