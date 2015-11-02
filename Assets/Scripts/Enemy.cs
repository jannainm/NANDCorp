using UnityEngine;
using System.Collections;

public class Enemy : MovingObject
{

	public int playerDamage;

	private Animator animator;
	private Transform target; // stores players position
	private bool skipMove; // enemy moves every other turn

	// Use this for initialization
	protected override void Start ()
	{
		GameManager.instance.AddEnemyToList (this);
		animator = GetComponent<Animator> ();
		target = GameObject.FindGameObjectWithTag ("Player").transform;
		base.Start ();
	}
	
	// Update is called once per frame
	void Update ()
	{
	
	}

	protected override void AttemptMove <T> (int xDir, int yDir)
	{
		if (skipMove) {
			skipMove = false;
			return;
		}
		base.AttemptMove <T> (xDir, yDir);

		skipMove = true;
	}

	public void MoveEnemy ()
	{
		int xDir = 0;
		int yDir = 0;

		if (Mathf.Abs (target.position.x - transform.position.x) < float.Epsilon)
			yDir = target.position.y > transform.position.y ? 1 : -1;
		else
			xDir = target.position.x > transform.position.x ? 1 : -1;

		//Call the AttemptMove function and pass in the generic parameter Player, because Enemy is moving and expecting to potentially encounter a Player
		AttemptMove <Player> (xDir, yDir);
		
	}

	//OnCantMove is called if Enemy attempts to move into a space occupied by a Player, it overrides the OnCantMove function of MovingObject 
	//and takes a generic parameter T which we use to pass in the component we expect to encounter, in this case Player
	protected override void OnCantMove <T> (T component)
	{
		//Declare hitPlayer and set it to equal the encountered component.
		Player hitPlayer = component as Player;

		animator.SetTrigger ("enemyAttack");
		
		//Call the LoseFood function of hitPlayer passing it playerDamage, the amount of foodpoints to be subtracted.
		hitPlayer.LoseFood (playerDamage);
	}

}
