using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Entity : MonoBehaviour
{

    public AudioManager AudioMan;

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


    // Walking on wall angles
    //float AdjustSpeed = 5.0f;
    //private Quaternion FromRotation;
    //private Quaternion ToRotation;
    //private Vector3 TargetNormal;
    //RaycastHit Hit;
    //private float Weight = 1.0f;
    

    //public Transform RotateObj;


    // Use this for initialization
    protected virtual void Start ()
    {
        Health = MaxHealth;
        MovementSpeed = MaxSpeed;

        Rigid = GetComponent<Rigidbody>();

        Attack = GetComponent<Ability>();
        //TargetNormal = transform.up;
        //Cam = GetComponent<CameraControl>();
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
        AudioMan.Play("HurtGrunt");
        StopCoroutine(HealthRegen());
        StartHealthTimer = false;
        HealthTimer = MaxHealthTimer;

        if (Health <= 0.0f)
        {
            Dead = true;
            OnDeath();
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


    protected virtual void OnDeath()
    {

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
        AudioMan.Play("FootSteps");
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

    public void PlaySound(string sound)
    {
        Debug.Log("Function Called");
        AudioMan.Play(sound);
    }

}
