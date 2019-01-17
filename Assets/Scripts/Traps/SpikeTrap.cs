using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpikeTrap : MonoBehaviour
{


    // upon collision with the spike trap

    private void OnCollisionEnter(Collision Col)
    {
        Entity Other = Col.gameObject.GetComponent<Entity>();
        if(Other)
        {
            FindObjectOfType<AudioManager>().Play("SpikeTrap");
            Other.TakeDamage();
        }
    }

}
