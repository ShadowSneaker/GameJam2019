using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallClosing : MonoBehaviour
{

    public GameObject Wall1;
    public GameObject Wall2;

    private bool TriggerHit;

    public float MovingSpeed;

	void Update ()
    {
		if(TriggerHit)
        {
            float speed = MovingSpeed * Time.deltaTime;

            Wall1.transform.position = Vector3.MoveTowards(Wall1.transform.position, Wall2.transform.position, speed);

            Wall2.transform.position = Vector3.MoveTowards(Wall2.transform.position, Wall1.transform.position, speed);
        }
	}

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            TriggerHit = true;
        }
    }

}
