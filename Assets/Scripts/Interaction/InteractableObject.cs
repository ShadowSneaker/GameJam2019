using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;


public class InteractableObject : MonoBehaviour
{
    public bool Active = true;
    public ActivatableObject[] ActivateObjects;
    public UnityEvent EventObject;

    public string ScreenInfo;

    private Animation Anim;

    private void Start()
    {
        Anim = GetComponent<Animation>();
    }


    public virtual void Interact()
    {
        if (Active)
        {
            Active = false;

            if (Anim)
            {
                Anim.Play(Anim.clip.name);
            }

            for (int i = 0; i < ActivateObjects.Length; ++i)
            {
                ActivateObjects[i].Activate();
            }
            
            
            if (EventObject != null)
            {
                EventObject.Invoke();
            }
        }
    }


    public void ActivateObject()
    {
        Active = true;
    }
}
