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

    private Ability Attack;

    private bool StartRotate = true;

    //set to one for no effect and only changed in traps;
    public float SpeedModifier = 1;

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

        Attack = GetComponent<Ability>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (CanRegen && !Dead)
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


    private void FixedUpdate()
    {
        //if (StartRotate)
        //{
        //    RaycastHit Hit;
        //    if (Physics.Raycast(transform.position, -Vector3.up, out Hit))
        //    {
        //
        //
        //        transform.rotation = Quaternion.FromToRotation(Vector3.right, Hit.normal);
        //        float DistanceToGround = Hit.distance;
        //        if (DistanceToGround > 2.2f)
        //        {
        //            Rigid.AddForce(-Vector3.up * 9.81f);
        //        }
        //    }
        //}
    }


    private void UseAttack()
    {
        if (Attack.AbilityUp())
        {
            Attack.Cast();
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
            Dead = true;

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
        Vector3 Vec = Vector3.zero;
        if (Physics.gravity.x > 0.0f || Physics.gravity.x < 0.0f)
        {
            // Gravity along X
            Vec = new Vector3(Rigid.velocity.x, MoveDir.y * MovementSpeed, MoveDir.z * MovementSpeed);
        }
        else if (Physics.gravity.y > 0.0f || Physics.gravity.y < 0.0f)
        {
            Vec = new Vector3(MoveDir.x * MovementSpeed, Rigid.velocity.y, MoveDir.z * MovementSpeed);

        }
        else if (Physics.gravity.z > 0.0f || Physics.gravity.z < 0.0f)
        {
            Vec = new Vector3(MoveDir.x * MovementSpeed, MoveDir.y * MovementSpeed, Rigid.velocity.z);

        }

        //Vector3 Vec;
        //Vec = new Vector3(MoveDir.x * MovementSpeed, Rigid.velocity.y, MoveDir.z * MovementSpeed);



        //Vec.x = new Vector3(MoveDir.x * MovementSpeed, Rigid.velocity.y, MoveDir.z * MovementSpeed).x; 
        //Vec.x = new Vector3(MoveDir.x * MovementSpeed, Rigid.velocity.y, MoveDir.z * MovementSpeed).y; 
        //Vec.x = new Vector3(MoveDir.x * MovementSpeed, Rigid.velocity.y, MoveDir.z * MovementSpeed).z; 
        //Vec = transform.TransformDirection(Vec);
        Rigid.velocity = Vec * SpeedModifier;

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
        RaycastHit HitInfo;
        return Physics.Raycast(transform.position, Vector3.down, out HitInfo, 1.2f);
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
