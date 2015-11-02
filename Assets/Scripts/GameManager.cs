using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{

	public float levelStartDelay = 2f;
	public float turnDelay = .1f;
	public static GameManager instance = null;              //Static instance of GameManager which allows it to be accessed by any other script.
	public BoardManager boardScript;                       //Store a reference to our BoardManager which will set up the level.
	public int playerFoodPoints = 100;
	[HideInInspector] public bool playersTurn = true;

	private Text levelText;
	private GameObject levelImage;
	private int level = 2;                                  //Current level number, expressed in game as "Day 1".
	private List<Enemy> enemies;
	private bool enemiesMoving;
	private bool doingSetup;

	void Awake ()
	{

		//Check if instance already exists
		if (instance == null) {
			//if not, set instance to this
			instance = this;
		}

		//If instance already exists and it's not this:
		else if (instance != this) {	
			//Then destroy this. This enforces our singleton pattern, meaning there can only ever be one instance of a GameManager.
			Destroy (gameObject);
		}
		//Sets this to not be destroyed when reloading scene
		DontDestroyOnLoad (gameObject);
		enemies = new List<Enemy> ();
		boardScript = GetComponent<BoardManager> ();
		InitGame ();
	}

	private void OnLevelWasLoaded(int index) {
		level++;

		InitGame();
	}

	void InitGame ()
	{
		doingSetup = true;

		levelImage = GameObject.Find("LevelImage");
		levelText = GameObject.Find("LevelText").GetComponent<Text>();
		levelText.text = "Day " + level;
		levelImage.SetActive(true);
		Invoke ("HideLevelImage", levelStartDelay);

		enemies.Clear ();
		boardScript.SetupScene (level);
	}

	private void HideLevelImage() {
		levelImage.SetActive(false);
		doingSetup = false;
	}

	public void GameOver ()
	{
		levelText.text = "After " + level + " days, you starved.";
		levelImage.SetActive(true);
		enabled = false;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// works
		//if (enemiesMoving) {
		if (playersTurn || enemiesMoving || doingSetup) {
			return;
		}
		StartCoroutine (MoveEnemies ());
	}

	public void AddEnemyToList (Enemy script)
	{
		enemies.Add (script);
	}

	IEnumerator MoveEnemies ()
	{

		enemiesMoving = true;
		yield return new WaitForSeconds (turnDelay);
		if (enemies.Count == 0) {
			yield return new WaitForSeconds (turnDelay);
		}

		for (int i = 0; i < enemies.Count; i++) {
			//Call the MoveEnemy function of Enemy at index i in the enemies List.
			enemies [i].MoveEnemy ();
			
			//Wait for Enemy's moveTime before moving next Enemy, 
			yield return new WaitForSeconds (enemies [i].moveTime);
		}
		playersTurn = true;
		enemiesMoving = false;
	}
}
