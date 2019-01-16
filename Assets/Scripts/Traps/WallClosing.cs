using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClosing : MonoBehaviour
{

    public bool WallsMoving;

    private void OnCollisionEnter(Collision collision)
    {
        Entity Other = collision.gameObject.GetComponent<Entity>();
        if(Other)
        {
            if (WallsMoving)
            {
                Other.TakeDamage();
                Other.TakeDamage();
            }
        }
    }
}
