using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrapDoor : MonoBehaviour {

    public Animation TDoor;


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            //TDoor.GetComponent<Animator>().SetBool("Open", true);
            TDoor.Play(TDoor.clip.name);
        }
    }


    //private void OnTriggerEnter(Collider other)
    //{
    //    if(other.gameObject.CompareTag("Player"))
    //    {
    //        TDoor.GetComponent<Animator>().SetBool("Open", true);
    //    }
    //}


}
