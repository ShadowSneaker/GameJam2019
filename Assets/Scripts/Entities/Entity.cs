using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{
    public float MaxHealth = 100.0f;
    protected float Health;

    private float MovementSpeed;
    public float MaxSpeed = 600.0f;

    public float JumpStrength;

    private bool Dead;

    private Rigidbody Rigid;


    ///  Health Timer stuffs
    public bool CanRegen;
    public float RegenStrength = 2.0f;
    private bool StartHealthTimer;
    private float HealthTimer;
    public float MaxHealthTimer;

    public float HealthRegenDelay = 2.0f;

    
	// Use this for initialization
	void Start ()
    {
        Health = MaxHealth;
        MovementSpeed = MaxSpeed;

        Rigid = GetComponent<Rigidbody>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (CanRegen)
        {
            if (StartHealthTimer)
            {
                if (Health < MaxHealth)
                {
                    Health = Mathf.Lerp(Health, MaxHealth, RegenStrength * Time.deltaTime);
                }
                else
                {
                    Health = MaxHealth;
                    StartHealthTimer = false;
                }
            }
        }
	}


    public void TakeDamage()
    {
        Health -= 50.0f;

        StopCoroutine(HealthRegen());
        StartHealthTimer = false;
        HealthTimer = MaxHealthTimer;

        if (Health <= 0.0f)
        {
            Dead = false;

            // Play Death sound
        }
        else
        {
            // Play hurt sound
            StartCoroutine(HealthRegen());
        }

        float SpeedMultiplier;
        SpeedMultiplier = Mathf.Clamp(Health, 0.5f, 1);
        MovementSpeed = MaxSpeed * SpeedMultiplier;
    }


    private IEnumerator HealthRegen()
    {
        yield return new WaitForSeconds(HealthRegenDelay);
        StartHealthTimer = true;
    }


    public void Move(Vector3 MoveDir)
    {
        Vector3 Vec;
        Vec = new Vector3(MoveDir.x * MovementSpeed, Rigid.velocity.y, MoveDir.z * MovementSpeed);
        Rigid.velocity = Vec;

    }


    public void Jump()
    {
       if (OnGround())
       {
            Rigid.AddForce(Vector3.up * JumpStrength);
       }
    }


    public bool OnGround()
    {
        RaycastHit Hit;
        return Physics.Raycast(transform.position, Vector3.down, out Hit, 1.2f);
    }

    public float GetSpeed()
    {
        return MovementSpeed;
    }

    public float GetHealth()
    {
        return Health;
    }
}
