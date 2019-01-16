using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallTrigger : MonoBehaviour
{

    public Animation BlockingWall;
    // only turned true when the trap closes in on the player
    public bool CloseTrap;

    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Player"))
       {
            if (CloseTrap)
            {
                WallClosing[] Child = GetComponentsInChildren<WallClosing>();

                for (int i = 0; i < Child.Length; ++i)
                {
                    Child[i].WallsMoving = true;
                }
            }

            BlockingWall.Play(BlockingWall.clip.name);
       }
    }


}
