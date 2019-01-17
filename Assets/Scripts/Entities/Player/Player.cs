using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{

    RaycastHit Hit;
    InteractableObject Active;
    CameraControl Cam;

    internal Respawn RespawnPoint;

    public Text InteractText;


    protected override void Start()
    {
        base.Start();
        Cam = GetComponent<CameraControl>();
    }

    private void FixedUpdate()
    {
        if (Physics.Raycast(Cam.Cam.transform.position, Cam.Cam.transform.forward, out Hit, 2.0f))
        {
            Active = Hit.transform.GetComponent<InteractableObject>();
            if (Active)
            {

                if (Active.Active)
                {
                    InteractText.enabled = true;
                    InteractText.text = Active.ScreenInfo;
                    if (Input.GetKeyDown("f"))
                    {
                        RespectsPayed();
                        Active.Interact();
                    }
                }
                else
                {
                    InteractText.enabled = false;
                }
            }
            else
            {
                InteractText.enabled = false;
            }
        }
        else
        {
            InteractText.enabled = false;
        }

    }


    protected override void OnDeath()
    {
        RespawnPoint.RespawnPlayer();
    }


    public void RespectsPayed()
    {

    }
}
