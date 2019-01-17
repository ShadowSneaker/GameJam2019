using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InteractableObject : MonoBehaviour
{
    public bool Active = true;
    public ActivatableObject[] ActivateObjects;
    public string ScreenInfo;

    // Use this for initialization
    void Start ()
    {
		
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}


    public void Interact()
    {
        Active = false;
        for (int i = 0; i < ActivateObjects.Length; ++i)
        {
            ActivateObjects[i].Activate();
        }
    }
}
