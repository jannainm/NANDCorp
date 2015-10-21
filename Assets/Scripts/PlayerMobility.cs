using UnityEngine;
using System.Collections;

public class PlayerMobility : MonoBehaviour 
{
	/// ////////////////////////////////////////////////
	/// GLOBAL VARS
	/// ////////////////////////////////////////////////
	public Rigidbody2D rigidBody; // rigid body object allows interaction with player sprite
	public Animator animate;
	public Quaternion rot;
	public float speed; // speed at which the character will move

	//bool characterFacingRight = true;
	// CAN ALSO HAVE BOOL OR SOMETHING FOR Z DIRECTION? TO FIGURE OUT WHICH AXIS IS WHICH..

	// Use this for initialization
	void Start () 
	{
		animate = GetComponent<Animator>();
		rigidBody = GetComponent<Rigidbody2D>();
		speed = 0.025f;
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
		if (Input.GetKey(KeyCode.W)) { // the W key moves character towards Positive Y-AXIS
			transform.Translate(Vector3.up * speed);
			RotatePlayer (horizontal, vertical, 1); // 1 means up
		}
		if (Input.GetKey(KeyCode.S)) { // the S key moves character towards Negative Y-AXIS
			transform.Translate(Vector3.down * speed);
			RotatePlayer (horizontal, vertical, 2); // 2 means down
		}
		if (Input.GetKey(KeyCode.A)) { // the A key moves charater towards Negative X-AXIS
			transform.Translate(Vector3.left * speed);
			RotatePlayer (horizontal, vertical, 3); // 3 means left
		}
		if (Input.GetKey (KeyCode.D)) { // the D arrow key moves charater towards Positive X-AXIS
			transform.Translate (Vector3.right * speed);
			RotatePlayer (horizontal, vertical, 4); // 4 means right
		}	
	}

	void RotatePlayer(float horizontal, float vertical, int direction) {
		int caseSwitch = direction;
		switch (caseSwitch) {
		case 1:
			//rot = Quaternion.LookRotation (transform.position, Vector3.down);
			//transform.eulerAngles = new Vector3 (0, 0, transform.eulerAngles.z);
			//transform.rotation = rot;
			//rigidBody.angularVelocity = 0;
			//rigidBody.AddForce (gameObject.transform.up * speed * vertical);
			break;
		case 2:
			//rot = Quaternion.LookRotation (transform.position, Vector3.down);
			break;
		case 3:
			//rot = Quaternion.LookRotation (transform.position, Vector3.left);
			break;
		case 4:
			//rot = Quaternion.LookRotation (transform.position, Vector3.right);
			break;
		default:
			break;
		}

		//transform.rotation = rot;
	}


	/// ////////////////////////////////////////////////
	/// Start tests here
	/// ////////////////////////////////////////////////
} // END

//// Rigidbody2D 
//public Rigidbody2D someBody;
//// Bool To See Which Way Character Is Facing
//bool characterFacingRight = true;
//// Speed At Which To Move Character 
//public float speed;
//
//// Animator 
//Animator characterAnimation;
//
//// Start Function
//void Start()
//{
//	characterAnimation = GetComponent<Animator> ();
//}
//
//// Update is called once per frame
//void FixedUpdate () 
//{
//	// Get Arrow Key Right Or Left
//	float movement = Input.GetAxis ("Horizontal");
//	
//	// Create Animator Variable To Check Whether To Transition From One Animation To Another
//	characterAnimation.SetFloat ("Movement Speed", Mathf.Abs (movement));
//	
//	// Change Velocity Based On Speed and Movement of Right or Left
//	someBody.velocity = new Vector2(movement * speed, 0.0f);
//	
//	// Check If We Need to Flip The Animation
//	if (movement > 0 && !characterFacingRight) 
//	{
//		FlipAnimation ();
//	} 
//	else if (movement < 0 && characterFacingRight) 
//	{
//		FlipAnimation();
//	}
//	
//}
//
//void FlipAnimation()
//{
//	// Set Character Facing Direction To Opposite or False
//	characterFacingRight = !characterFacingRight;
//	Vector3 currentScale = transform.localScale;
//	// Multiply Current Scale By Negative To Flip Direction
//	currentScale.x *= -1;
//	transform.localScale = currentScale;
//}
//}


//start or awake is first, update, fixed update
//
//public float speed = 0.025f;	// variable to control the speed of the charactere;
//public float turnSmoothing = 15f;
//public float speedDampTime = 0.1f;
//
//public Quaternion rot;
//
//void FixedUpdate() {
//	
//	float h = Input.GetAxis ("Horizontal");
//	float v = Input.GetAxis ("Vertical");
//	MovePlayer (h, v);
//}
//
//
//void MovePlayer(float h, float v) {
//	if (Input.GetKey(KeyCode.W)) { // the W key moves character towards Positive Y-AXIS
//		transform.Translate(Vector3.up * speed);
//		RotatePlayer (h, v, 1); // 1 means up
//	}
//	if (Input.GetKey(KeyCode.S)) { // the S key moves character towards Negative Y-AXIS
//		transform.Translate(Vector3.down * speed);
//		RotatePlayer (h, v, 2); // 2 means down
//	}
//	if (Input.GetKey(KeyCode.A)) { // the A key moves charater towards Negative X-AXIS
//		transform.Translate(Vector3.left * speed);
//		RotatePlayer (h, v, 3); // 3 means left
//	}
//	if (Input.GetKey (KeyCode.D)) { // the D arrow key moves charater towards Positive X-AXIS
//		transform.Translate (Vector3.right * speed);
//		RotatePlayer (h, v, 4); // 4 means right
//	}
//	
//}
//
//
//void RotatePlayer(float horizontal, float vertical, int direction) {
//	//Vector3 relativePos = target.position - transform.position;
//	//Quaternion rotation = Quaternion.LookRotation(relativePos);
//	//transform.rotation = rotation;
//	Rigidbody2D rigidBody = GetComponent<Rigidbody2D>();
//	Animator animate = GetComponent<Animator>();
//	int caseSwitch = direction;
//	
//	switch (caseSwitch)
//	{
//	case 1:
//		rot = Quaternion.LookRotation(transform.position, Vector3.up);
//		// only want z axis
//		transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
//		// smooth rotation
//		rigidBody.angularVelocity = 0;
//		rigidBody.AddForce (gameObject.transform.up * speed * vertical);
//		transform.rotation = rot;
//		break;
//	case 2:
//		rot = Quaternion.LookRotation(transform.position, Vector3.down);
//		break;
//	case 3:
//		rot = Quaternion.LookRotation(transform.position, Vector3.left);
//		break;
//	case 4:
//		rot = Quaternion.LookRotation(transform.position, Vector3.right);
//		break;
//	default:
//		break;
//	}
//	
//	transform.rotation = rot;
//	
//	// move rigid body obj to right...
//	//rigidBody.velocity.x = 10;
//	
//	//Vector3 relativePos = transform.position;
//	//rot = Quaternion.LookRotation (relativePos);
//	
//	
//	//rot = Quaternion.LookRotation(transform.position, Vector3.down);
//	//rot = Quaternion.LookRotation (relativePos);
//	
//	/*
//		// only want z axis
//		transform.eulerAngles = new Vector3(0, 0, transform.eulerAngles.z);
//		// smooth rotation
//		rigidBody.angularVelocity = 0;
//
//		rigidBody.AddForce (gameObject.transform.up * speed * vertical);
//
//*/
//	
//	
//	//float input = Input.GetAxis("Vertical");
//	//rigidbody24.force = 
//}
//
//}
