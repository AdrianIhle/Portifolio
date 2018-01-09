using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PlayerMovement : MonoBehaviour {
    GameObject Player;
    Rigidbody PlayerPhysics;

    StretchAndSquash physJumpAnim;

    public float forwardSpeed;
    public float jumpspeed;
    public float dodgespeed;
    public float maxSpeed;
    float forward;
    float dodge = 0;
    float jump = 0;

    public Vector3 PVelocity;

    public bool grounded;
    public Transform groundCheck;
    public float groundedRadius;
    public LayerMask whatIsGround;

    // Use this for initialization
    void Start()
    {
        Player = this.gameObject;
        PlayerPhysics = Player.GetComponent<Rigidbody>();
        physJumpAnim = Player.GetComponent<StretchAndSquash>();
        forward = forwardSpeed;
        dodge = dodgespeed;

    }


    // Update is called once per frame
    void Update () {
        PVelocity = PlayerPhysics.velocity;

        if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			jump = jumpspeed;
			print ("jump");
			physJumpAnim.triggerY = true;
		} else
			jump = 0;

		if (Input.GetKey (KeyCode.LeftArrow)) {
			dodge = -dodgespeed;
			print ("bolshevhik");
		}
		else if (Input.GetKey (KeyCode.RightArrow)) {
			dodge = dodgespeed;
			print ("rightt is might");
		} else
			dodge = 0;

		if (Input.GetKey (KeyCode.UpArrow))
			forward = forwardSpeed + 4;
		else if (Input.GetKey (KeyCode.DownArrow))
			forward = forwardSpeed - 4;
		else
			forward = forwardSpeed;
			
		
	}

	void FixedUpdate()
	{
		grounded = Physics.CheckSphere (groundCheck.position, groundedRadius, whatIsGround);
		PlayerPhysics.AddForce (new Vector3 (dodge, jump,forward));

        if (PlayerPhysics.velocity.magnitude > maxSpeed)
        {
            PlayerPhysics.velocity = Vector3.ClampMagnitude(PlayerPhysics.velocity, maxSpeed);
        }
    }
}
