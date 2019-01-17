using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : ActivatableObject
{
    public bool Locked = true;


    public override void Activate()
    {
        if (!Active)
        {
            if (!Locked)
            {
                Active = false;
                Activated();
                if (OnActivated != null)
                {
                    OnActivated.Invoke();
                }
            }
            else
            {
                Locked = false;
            }
        }
    }
}
