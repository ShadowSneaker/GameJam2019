using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Respawn : MonoBehaviour
{

    public Transform Spawnpoint;
    Entity PlayerEntity;
    //may not be needed
    bool Respawning;


    private void Start()
    {
        PlayerEntity = transform.GetComponent<Entity>();
        Respawning = false;
    }

    // function to respawn player at that position
    public void RespawnPlayer()
    {
        PlayerEntity.transform.position = Spawnpoint.position;
    }

}
