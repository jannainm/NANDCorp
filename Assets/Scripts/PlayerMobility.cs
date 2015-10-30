using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour 
{
	/// ////////////////////////////////////////////////
	/// GLOBAL VARS
	/// ////////////////////////////////////////////////
	private Rigidbody2D rigidBody; // rigid body object allows interaction with player sprite
	private Animator animate;
	//private Quaternion rot;
	private float speed; // speed at which the character will move
	//private float thrust; // used for speed of velocity in AddForce() to rigidBody
	//private float walkSpeed;
	//private float curSpeed;
	//private float maxSpeed;
	//private float sprintSpeed;
	
	//private CharacterStat plStat;

	// Use this for initialization
	void Start () 
	{
		//plStat = GetComponent<CharacterStat>();
		animate = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody2D>();
		//walkSpeed = (float)(plStat.Speed + (plStat.Agility/5));
		//sprintSpeed = walkSpeed + (walkSpeed / 2);
		speed = 0.025f;
		//thrust = 10f;
	}
	
	// Update is called once per frame
	void FixedUpdate () 
	{
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		MovePlayer (horizontal, vertical);
	}

	void MovePlayer(float horizontal, float vertical) // h is horizontal, v is vertical
	{
		/*
		curSpeed = walkSpeed;
		maxSpeed = curSpeed;

		// Move senteces
		GetComponent<Rigidbody2D>().velocity = new Vector2(Mathf.Lerp(0, Input.GetAxis("Horizontal")* curSpeed, 0.8f),
		                                   Mathf.Lerp(0, Input.GetAxis("Vertical")* curSpeed, 0.8f));
		*/

		if (Input.GetKey (KeyCode.W)) { // the W key moves character towards Positive Y-AXIS
			animate.SetInteger ("Direction", 2);
			animate.SetFloat ("Speed", 1.0f);
			transform.Translate (Vector3.up * speed);
			//Rigidbody2D.velocity.y = vertical * thrust;
			// equivalent to line above
			// rigidBody.AddForce(Vector3.up * thrust);
		} else if (Input.GetKey (KeyCode.S)) { // the S key moves character towards Negative Y-AXIS
			animate.SetInteger ("Direction", 0);
			animate.SetFloat ("Speed", 1.0f);
			transform.Translate (Vector3.down * speed);
		} else if (Input.GetKey (KeyCode.A)) { // the A key moves charater towards Negative X-AXIS
			animate.SetInteger ("Direction", 1);
			animate.SetFloat ("Speed", 1.0f);
			transform.Translate (Vector3.left * speed);
		} else if (Input.GetKey (KeyCode.D)) { // the D arrow key moves charater towards Positive X-AXIS
			animate.SetInteger ("Direction", 3);
			animate.SetFloat ("Speed", 1.0f);
			transform.Translate (Vector3.right * speed);
		} else {
			animate.SetFloat("Speed", 0.0f);
		}
	}


	/// ////////////////////////////////////////////////
	/// Start tests here
	/// ////////////////////////////////////////////////
} // END