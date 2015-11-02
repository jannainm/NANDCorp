using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Player : MovingObject
{

	public int temp = 1;
	public int wallDamage = 1;
	public int pointsPerFood = 10;
	public int pointsPerSoda = 20;
	public float restartLevelDelay = 1f;
	public Text foodText;

	private Animator animator;

	private int food;

	// Use this for initialization
	protected override void Start ()
	{
		animator = GetComponent<Animator> ();
		food = GameManager.instance.playerFoodPoints;
		foodText.text = "Food: " + food;
		base.Start ();
	}

	private void OnDisable ()
	{
		GameManager.instance.playerFoodPoints = food;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if (!GameManager.instance.playersTurn) return;

		int horizontal = 0;
		int vertical = 0;

		horizontal = (int) (Input.GetAxisRaw ("Horizontal"));
		vertical = (int) (Input.GetAxisRaw ("Vertical"));

		if (horizontal != 0) {
			vertical = 0;
		}

		if (horizontal != 0 || vertical != 0) {
			AttemptMove<Wall> (horizontal, vertical);
		}
	}

	protected override void AttemptMove <T> (int xDir, int yDir)
	{
		food--;
		foodText.text = "Food: " + food;
		base.AttemptMove <T> (xDir, yDir);
		//RaycastHit2D hit;
		CheckIfGameOver ();
		GameManager.instance.playersTurn = false;	// players turn has ended
	}

	protected override void OnCantMove <T> (T component)
	{
		Wall hitWall = component as Wall;
		hitWall.DamageWall (wallDamage);
		animator.SetTrigger ("PlayerChop");
	}

	private void OnTriggerEnter2D (Collider2D other)
	{
		if (other.tag == "Exit") {
			Invoke ("Restart", restartLevelDelay);
			enabled = false;
		} else if (other.tag == "Food") {
			food += pointsPerFood;
			foodText.text = "+" + pointsPerFood + " Food: " + food;
			other.gameObject.SetActive (false);
		} else if (other.tag == "Soda") {
			food += pointsPerSoda;
			foodText.text = "+" + pointsPerSoda + " Food: " + food;
			other.gameObject.SetActive (false);
		}
	}

	private void Restart ()
	{
		Application.LoadLevel (Application.loadedLevel);
	}

	public void LoseFood (int loss)
	{
		// CAN ADD ANIMATION FOR BEING HIT
		//animator.SetTrigger("PlayerHit");
		food -= loss;
		foodText.text = "-" + loss + " Food: " + food;
		CheckIfGameOver (); // check for end of game since player lost food

	}

	void CheckIfGameOver ()
	{
		if (food <= 0) {
			GameManager.instance.GameOver ();
			// OR ADD SECTION HERE TO LOAD LAST LEVEL OR CLOSING SCREEN
		}
	}
}
