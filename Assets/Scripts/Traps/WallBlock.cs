using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBlock : MonoBehaviour
{


    public GameObject BlockingWall;

    


    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Player"))
       {

            BlockingWall.GetComponent<Animator>().SetBool("CloseWall", true);
       }
    }


}
