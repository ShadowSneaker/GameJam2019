using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEMP : MonoBehaviour {

    public float Speed = 6.0f;
    public float JumpStrength = 8.0f;
    public float Gravity = 20.0f;

    CharacterController Control;

    Vector3 MoveDir;

	// Use this for initialization
	void Start ()
    {
        Control = GetComponent<CharacterController>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        if (Control.isGrounded)
        {
            MoveDir = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
            MoveDir = transform.TransformDirection(MoveDir);
            MoveDir *= Speed;

            if (Input.GetButton("Jump"))
            {
                MoveDir.y = JumpStrength;
            }
        }

        MoveDir.y -= Gravity * Time.deltaTime;

        Control.Move(MoveDir * Time.deltaTime);
	}
}
