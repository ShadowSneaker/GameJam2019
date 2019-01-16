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


    // Walking on wall angles
    float AdjustSpeed = 5.0f;
    private Quaternion FromRotation;
    private Quaternion ToRotation;
    private Vector3 TargetNormal;
    RaycastHit Hit;
    private float Weight = 1.0f;
    CameraControl Cam;

    public Transform RotateObj;


    // Use this for initialization
    void Start ()
    {
        Health = MaxHealth;
        MovementSpeed = MaxSpeed;

        Rigid = GetComponent<Rigidbody>();

        Attack = GetComponent<Ability>();
        TargetNormal = transform.up;
        Cam = GetComponent<CameraControl>();
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


    //private void FixedUpdate()
    //{
    //    if (StartRotate)
    //    {
            
    //        if (Physics.Raycast(transform.position, -Vector3.up, out Hit))
    //        {
    //            if (Hit.normal == RotateObj.up) return;
    //            if (Hit.normal != TargetNormal)
    //            {
    //                TargetNormal = Hit.normal;
    //                FromRotation = RotateObj.rotation;
    //                ToRotation = Quaternion.FromToRotation(Vector3.up, Hit.normal);

    //                Debug.Log(FromRotation);
    //                Debug.Log(ToRotation);

    //                Weight = 0;
    //            }
    //            if (Weight <= 1.0f)
    //            {
    //                Weight += Time.deltaTime * AdjustSpeed;
    //                RotateObj.rotation = Quaternion.Slerp(FromRotation, ToRotation, Weight);

    //                Cam.originalRotation = RotateObj.localRotation;
    //                Cam.CamOriginalRotation = Cam.transform.localRotation;
    //            }


    //            // Attempt 2
    //            //if (Hit.normal == transform.up) return;
    //            //
    //            //transform.rotation = Quaternion.Euler(Vector3.Slerp(transform.up, Hit.normal, AdjustSpeed));


    //            // Attempt 1
    //            //float DistanceToGround = Hit.distance;
    //            //
    //            //if (Hit.normal == transform.up) return;
    //            //
    //            //NewUp = Vector3.RotateTowards(transform.up, Hit.normal, AdjustSpeed * Mathf.Deg2Rad, 0);
    //            //transform.rotation = Quaternion.LookRotation(transform.forward, NewUp);
                

                


    //        }
    //    }
    //}


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
        //Vector3 Vec = Vector3.zero;
        //if (Physics.gravity.x > 0.0f || Physics.gravity.x < 0.0f)
        //{
        //    // Gravity along X
        //    Vec = new Vector3(Rigid.velocity.x, MoveDir.y * MovementSpeed, MoveDir.z * MovementSpeed);
        //}
        //else if (Physics.gravity.y > 0.0f || Physics.gravity.y < 0.0f)
        //{
        //    // Gravity along Y
        //    Vec = new Vector3(MoveDir.x * MovementSpeed, Rigid.velocity.y, MoveDir.z * MovementSpeed);
        //
        //}
        //else if (Physics.gravity.z > 0.0f || Physics.gravity.z < 0.0f)
        //{
        //    // Gravity along Z
        //    Vec = new Vector3(MoveDir.x * MovementSpeed, MoveDir.y * MovementSpeed, Rigid.velocity.z);
        //
        //}

        Vector3 Vec;
        Vec = new Vector3(MoveDir.x * MovementSpeed, Rigid.velocity.y, MoveDir.z * MovementSpeed);



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
