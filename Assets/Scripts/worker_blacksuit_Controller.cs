using UnityEngine;
using System.Collections;

public class worker_blacksuit_Controller : MonoBehaviour {
	private bool showText = false;
	private bool collided = false;

	private float currentTime = 0.0f, executedTime = 0.0f, timeToWait = 5.0f;
	
	void Update()
	{
		currentTime = Time.time;
		if(collided)
			showText = true;
		else
			showText = false;
		
		if(executedTime != 0.0f)
		{
			if(currentTime - executedTime > timeToWait)
			{
				executedTime = 0.0f;
				collided = false;
				Application.LoadLevel ("Beginning_01");
			}
		}

	}

	void OnCollisionEnter2D(Collision2D collision) {
		Debug.Log ("Success w/ using 2D collider.");
		print ("Success w/ using 2D collider");
		executedTime = Time.time;
		collided = true;
	}

	void OnGUI() {
		if (showText) {
			// Centered Box
			string msgText = "Hey, you! \n You can't spend all \n your time in the break room. \n Get back to work \n - this is NANDCorp!";
			GUI.Box (new Rect ((Screen.width) / 2 - (Screen.width) / 8, (Screen.height) / 2 - (Screen.height) / 8, (Screen.width) / 4, (Screen.height) / 4), msgText);
		}
	}
}