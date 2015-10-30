using UnityEngine;
using System.Collections;

public class worker_blacksuit_Controller : MonoBehaviour {
	private Rigidbody2D rigidBody;
	//private bool talk = false;

	// Use this for initialization
	void Start () {
		rigidBody = GetComponent<Rigidbody2D>; 
	}
	
	// Update is called once per frame
	void Update () {
		OnTriggerStay (rigidBody);
	}

	void OnTriggerStay(Collider target)
	{
		if(target.tag == "worker_blacksuit_idle_south")
		{
			Vector3 getPixelPos = Camera.main.WorldToScreenPoint( target.ClosestPointOnBounds );
			getPixelPos.y = Screen.height - getPixelPos.y;
			GUI.Label( new Rect(getPixelPos.x,getPixelPos.y,200f,100f) , "It's Me, Mario! :D");
		}

	}
}
