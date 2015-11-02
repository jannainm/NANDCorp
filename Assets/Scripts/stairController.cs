using UnityEngine;
using System.Collections;

public class stairController : MonoBehaviour {
	
	void OnTriggerEnter2D (Collider2D collider) {
		Debug.Log ("Success w/ using 2D BOX collider.");
		print ("Success w/ using 2D BOX collider");
		Application.LoadLevel ("Scene_Basement_002");
	}
}
