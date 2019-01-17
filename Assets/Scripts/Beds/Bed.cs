using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    // there will be a function in bed that gets the spawn point transform and sets it to that bed fornow i have it as a trigger collision

        //sets the players new spawnpoint
    private void OnTriggerEnter(Collider other)
    {
        other.GetComponent<Respawn>().Spawnpoint = transform;
    }



}
