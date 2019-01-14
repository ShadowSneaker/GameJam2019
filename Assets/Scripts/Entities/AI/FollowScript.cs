using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class FollowScript : MonoBehaviour
{
    public Transform FollowObject;

    private NavMeshAgent Nav;
    private Entity This;


	// Use this for initialization
	void Start ()
    {
        This = GetComponent<Entity>();
        Nav = GetComponent<NavMeshAgent>();

        Nav.speed = This.MaxSpeed;
	}
	
	// Update is called once per frame
	void Update ()
    {
        Nav.destination = FollowObject.position;
	}
}
