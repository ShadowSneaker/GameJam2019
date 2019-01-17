using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class ActivatableObject : MonoBehaviour
{
    public bool Active;
    public UnityEvent OnActivated;

    

    public virtual void Activate()
    {
        if (!Active)
        {
            Active = false;
            Activated();
            if (OnActivated != null)
            {
                OnActivated.Invoke();
            }
        }
    }


    protected virtual void Activated()
    {
    }
}
