using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Respawn : MonoBehaviour
{

    public Transform Spawnpoint;
    Entity PlayerEntity;
    //may not be needed
    bool Respawning;
    TransitionScript Transition;

    private void Start()
    {
        PlayerEntity = transform.GetComponent<Entity>();
        Respawning = false;
        Transition = FindObjectOfType<TransitionScript>();
    }

    // function to respawn player at that position
    public void RespawnPlayer()
    {
        if (Spawnpoint)
        {
            if (Transition)
            {
                Transition.PlayTransition();
                StartCoroutine(RespawnTimer());

            }
        }
        else
        {
            if (Transition)
            {
                Transition.Transition("MindGames");
            }
            else
            {
                SceneManager.LoadScene("MindGames");
            }
        }

    }


    private IEnumerator RespawnTimer()
    {
        yield return new WaitForSeconds(0.6f);
        PlayerEntity.transform.position = Spawnpoint.position;

    }
}
