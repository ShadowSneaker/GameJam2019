using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Player : Entity
{

    RaycastHit Hit;
    InteractableObject Active;
    CameraControl Cam;

    //internal RespawnScript RespawnPoint;

    public Text InteractText;


    protected override void Start()
    {
        base.Start();
        Cam = GetComponent<CameraControl>();
    }

    private void FixedUpdate()
    {
        //Debug.DrawRay(Cam.Cam.transform.position, Cam.Cam.transform.forward, Color.red , 5.0f);
        if (Physics.Raycast(Cam.Cam.transform.position, Cam.Cam.transform.forward, out Hit, 2.0f))
        {
            Debug.Log("Hit something");
            Active = Hit.transform.GetComponent<InteractableObject>();
            if (Active)
            {
                Debug.Log("Hit Activate");
                InteractText.enabled = true;
                InteractText.text = Active.ScreenInfo;

                if (Active.Active)
                {
                    if (Input.GetKeyDown("f"))
                    {
                        RespectsPayed();
                        Active.Interact();
                    }
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
        //RespawnPoint.RespawnPlayer();
    }


    public void RespectsPayed()
    {

    }
}
