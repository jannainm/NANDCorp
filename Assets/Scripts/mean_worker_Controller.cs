using UnityEngine;
using System.Collections;

public class mean_worker_Controller : MonoBehaviour {
	private bool showText = false;
	private bool collided = false;

	private float currentTime = 0.0f, executedTime = 0.0f, timeToWait = 3.0f;

	// Update is called once per frame
	void Update () {
		currentTime = Time.time;
		if (collided) {
			showText = true;
		} else 
			showText = false;

		if(executedTime != 0.0f)
		{
			if(currentTime - executedTime > timeToWait)
			{
				executedTime = 0.0f;
				collided = false;
			}
		}
	}

	void OnTriggerEnter2D(Collider2D collider) {
		collided = true;
		executedTime = Time.time;
	}

	void OnGUI() {
		if (showText) {
			// Centered Box
			string msgText = "\n\n Hey, you! \n I said work, now!";
			GUI.Box (new Rect ((Screen.width) / 2 - (Screen.width) / 8, (Screen.height) / 2 - (Screen.height) / 8, (Screen.width) / 4, (Screen.height) / 4), msgText);
		}
	}
}
