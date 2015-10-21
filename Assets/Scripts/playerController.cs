using UnityEngine;
using System.Collections;

public class playerController : MonoBehaviour
{
	
	private Animator animator;
	
	// Use this for initialization
	void Start()
	{
		animator = this.GetComponent<Animator>();
	}

	// Update is called once per frame
	void Update()
	{
		
		var vertical = Input.GetAxis("Vertical");
		var horizontal = Input.GetAxis("Horizontal");
		
		if (vertical > 0)
		{
			animator.SetInteger("Direction", 2);
			animator.SetFloat("Speed", 1.0f);
		}
		else if (vertical < 0)
		{
			animator.SetInteger("Direction", 0);
			animator.SetFloat("Speed", 1.0f);
		}
		else if (horizontal < 0)
		{
			animator.SetInteger("Direction", 1);
			animator.SetFloat("Speed", 1.0f);
		}
		else if (horizontal > 0)
		{
			animator.SetInteger("Direction", 3);
			animator.SetFloat("Speed", 1.0f);
		}
		else
		{
			animator.SetFloat("Speed", 0.0f);
		}
	}

}
