using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bed : MonoBehaviour
{
    // there will be a function in bed that gets the spawn point transform and sets it to that bed fornow i have it as a trigger collision

    //sets the players new spawnpoint
    private Player User;

    private void Start()
    {
        User = FindObjectOfType<Player>();
    }


    public void SleepyBoi()
    {
        User.GetComponent<Respawn>().Spawnpoint = transform;
    }

}
