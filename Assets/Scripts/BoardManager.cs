using UnityEngine;
using System;
using System.Collections.Generic;
using Random = UnityEngine.Random;

public class BoardManager : MonoBehaviour {


	[Serializable]
	public class Count
	{
		public int minimum;
		public int maximum;

		public Count(int min, int max) 
		{
			minimum = min;
			maximum = max;
		}
	}

	public int columns = 8;
	public int rows = 8;
	public Count wallCount = new Count (5,9);
	public Count foodCount = new Count (1,5);
	public GameObject exit;
	public GameObject[] wallTiles;
	public GameObject[] floorTiles;
	public GameObject[] enemyTiles;
	public GameObject[] foodTiles;

	private Transform boardHolder; // parent of all board objects
	private List<Vector3> gridPositions = new List<Vector3>(); // tracks players and objects

	void InitialiseList()
	{
		gridPositions.Clear (); // clear list

		// fill game board with list of Vector 3's
		for (int x = 1; x < columns - 1; x++) {
			for(int y = 1; y < rows - 1; y++) {
				// add new vector with x, y values
				gridPositions.Add(new Vector3(x,y,0f));
			}
		}
	}

	void BoardSetup () { // lay out outer wall tiles and background of floor tiles
		boardHolder = new GameObject ("Board").transform;
		for (int x = -1; x < columns + 1; x++) {
			for(int y = -1; y < rows + 1; y++) {
				GameObject toInstantiate = floorTiles[Random.Range (0, floorTiles.Length)];
				if(x == -1 || x == columns || y == -1 || y == rows) {
					toInstantiate = wallTiles[Random.Range(0, wallTiles.Length)];
				}
				//Instantiate the GameObject instance using the prefab chosen for toInstantiate at the Vector3 corresponding to current grid position in loop, cast it to GameObject.
				GameObject instance =
					Instantiate (toInstantiate, new Vector3 (x, y, 0f), Quaternion.identity) as GameObject;
				
				//Set the parent of our newly instantiated object instance to boardHolder, this is just organizational to avoid cluttering hierarchy.
				instance.transform.SetParent (boardHolder);

				/*
				GameObject myInstance;
				myInstance = Instantiate(toInstantiate, new Vector3(x,y,0f), 
				                         Quaternion.identity) as GameObject // instance w/ no rotation
				myInstance.transform.SetParent(boardHolder);

				//GameObject myInstance = Instantiate(toInstantiate, new Vector3(x,y,0f), 
				  //                                Quaternion.identity) as GameObject // instance w/ no rotation
				//myInstance.transform.SetParent(boardHolder); // set to child
				*/
			}
		}
	}

	// places items like walls, enemys, and powerups
	Vector3 RandomPosition() {
		int randomIndex = Random.Range (0, gridPositions.Count);
		Vector3 randomPosition = gridPositions [randomIndex];
		gridPositions.RemoveAt (randomIndex); // assure two objects are not added at the same place
		return randomPosition;
	}

	void LayoutObjectAtRandom(GameObject[] tileArray, int minimum, int maximum)
	{
		int objectCount = Random.Range (minimum, maximum + 1); // controls how many of any object to spawn
		for (int i = 0; i < objectCount; i++) {
			Vector3 randomPosition = RandomPosition ();
			GameObject tileChosen = tileArray[Random.Range(0 , tileArray.Length)];
			Instantiate(tileChosen, randomPosition, Quaternion.identity);
		}

	}

	public void SetupScene(int level) {
		BoardSetup ();
		InitialiseList ();

		// instantiate a random number of wall tiles based on minimum and maximum, at randomized positions.
		LayoutObjectAtRandom (wallTiles, wallCount.minimum, wallCount.maximum);
		
		// instantiate a random number of food tiles based on minimum and maximum, at randomized positions.
		LayoutObjectAtRandom (foodTiles, foodCount.minimum, foodCount.maximum);
		
		// determine number of enemies based on current level number, based on a logarithmic progression
		int enemyCount = (int)Mathf.Log(level, 2f); // casted float to integer
		
		// instantiate a random number of enemies based on minimum and maximum, at randomized positions.
		LayoutObjectAtRandom (enemyTiles, enemyCount, enemyCount);
		
		//Instantiate the exit tile in the upper right hand corner of our game board
		Instantiate (exit, new Vector3 (columns - 1, rows - 1, 0f), Quaternion.identity);

	}
}
