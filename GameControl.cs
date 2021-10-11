using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour {

	public static GameControl instance = null;

	[SerializeField]
	GameObject restartButton;

	[SerializeField]
	Text highScoreText;

	[SerializeField]
	Text yourScoreText;

	[SerializeField]
	GameObject[] obstacles;

	[SerializeField]
	Transform spawnPoint;

	[SerializeField]
	float spawnRate = 2f;
	float nextSpawn;

	[SerializeField]
	float timeToBoost = 5f;
	float nextBoost;

	int highScore = 0, yourScore = 0;

	public static bool gameStopped;

	// Use this for initialization
	void Start () {
		
		if (instance == null) 
			instance = this;
		else if (instance != this)
			Destroy (gameObject);

		// Declare variables
		restartButton.SetActive (false);
		yourScore = 0;
		gameStopped = false;
		Time.timeScale = 1f;
		highScore = PlayerPrefs.GetInt ("highScore");
		nextSpawn = Time.time + spawnRate;
		nextBoost = Time.unscaledTime + timeToBoost;
	}
	
	// Update is called once per frame
	void Update () {

		// Updates score texts
		highScoreText.text = "High Score: " + highScore;
		yourScoreText.text = "Wires Cut: " + yourScore;

		// Checks if it is time to spawn an obstacle
		if (Time.time > nextSpawn)
			SpawnObstacle ();

		// Checks if it is time to speed up the game
		if (Time.unscaledTime > nextBoost && !gameStopped)
			BoostTime ();
	}

	// If player is hit
	public void PlayerHit()
	{
		// Set new high score if your wire cut score is higher
		if (yourScore > highScore)
			PlayerPrefs.SetInt("highScore", yourScore);
		// Stop game and show restart button
		Time.timeScale = 0;
		gameStopped = true;
		restartButton.SetActive (true);
	}

	void SpawnObstacle()
	{
		// Spawns random obstacle from array at spawn point off screen
		nextSpawn = Time.time + spawnRate;
		int randomObstacle = Random.Range (0, obstacles.Length);
		Instantiate (obstacles [randomObstacle], spawnPoint.position, Quaternion.identity);
	}

	void BoostTime()
	{
		// Speeds up game
		nextBoost = Time.unscaledTime + timeToBoost;
		Time.timeScale += 0.25f;
	}

	public void IncreaseYourScore()
	{
		// Adds value to player's score
		yourScore += 1;
	}

	public void RestartGame()
	{
		// Restarts the game and resets player score
		SceneManager.LoadScene("Game");
		yourScore = 0;
	}

}
