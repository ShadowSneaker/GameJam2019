using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{


    // upon collision with the spike trap

    private void OnCollisionEnter(Collision Col)
    {
        if(Col.gameObject.CompareTag("Player"))
        {
        
            Col.gameObject.GetComponent<Entity>().TakeDamage();
        }
    }

}
