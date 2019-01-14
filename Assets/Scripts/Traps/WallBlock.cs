using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallBlock : MonoBehaviour
{

    public GameObject NodeObject;
    public GameObject TriggerPoint;

    public float CloseSpeed;

    private bool TriggerEntered;


    void Update()
    {
        if(TriggerEntered)
        {
            
            float speed = CloseSpeed * Time.deltaTime;

            transform.position = Vector3.MoveTowards(transform.position, NodeObject.transform.position, speed);
        }
    }


    private void OnTriggerEnter(Collider other)
    {
       if(other.gameObject.CompareTag("Player"))
       {
           
            TriggerEntered = true;
       }
    }


}
