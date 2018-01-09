using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovementPhone : MonoBehaviour {

	GameObject Player;
	Rigidbody PlayerPhysics;

	StretchAndSquash physJumpAnim;


	public float forwardSpeed;
	public float jumpspeed;
	public float dodgespeed;
    public float maxSpeed;
	public float minSpeed;
	public float backwardsForceMultiplier;
	float BFM;
	float forward;
	float dodge = 0;
	float jump = 0;

    public Vector3 PVelocity;

    public float phoneX;
    public float phoneZ;

	public float sensitivity;

	public bool grounded;
	public Transform groundCheck;
	public float groundedRadius;
	public LayerMask whatIsGround;

	// Use this for initialization
	void Start () {
		Player = this.gameObject;
		PlayerPhysics = Player.GetComponent<Rigidbody> ();
		physJumpAnim = Player.GetComponent<StretchAndSquash> ();
        forward = forwardSpeed;
        dodge = dodgespeed;

    }

	// Update is called once per frame
	void Update () {
        PVelocity = PlayerPhysics.velocity;


	}

	void FixedUpdate()
	{
		if (PlayerPhysics.velocity.magnitude > maxSpeed)
		{
			print ("maxspeed");
			PlayerPhysics.velocity = Vector3.ClampMagnitude(PlayerPhysics.velocity, maxSpeed);
		}


        print(Input.touches);
        if (Input.touches.Length != 0 && grounded)
        {
            jump = jumpspeed;
            print("jump");
            physJumpAnim.triggerY = true;
        }
        else
            jump = 0;

        phoneX = Input.acceleration.x;
        phoneZ = Input.acceleration.z;

        dodge = phoneX * dodgespeed;
        forward = phoneZ * forwardSpeed;

		if (phoneZ > 0) {
			BFM = backwardsForceMultiplier;
		} else
			BFM = 1;

        grounded = Physics.CheckSphere (groundCheck.position, groundedRadius, whatIsGround);
		PlayerPhysics.AddForce(new Vector3( dodge*sensitivity, jump, Mathf.Clamp(-forward*sensitivity*BFM, minSpeed, maxSpeed)));




    }


}
