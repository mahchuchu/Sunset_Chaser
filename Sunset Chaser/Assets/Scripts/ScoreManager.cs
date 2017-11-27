using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

/*
This script will manage all the scoring functions for the game. 
This includes a current score, a high score, and how they will be updated.
*/
public class ScoreManager : MonoBehaviour {

	public Text scoreText;
	public Text highScoreText;

	public float scoreCount;
	public float highScoreCount;

	public float pointsPerSecond;

	public bool scoreIncreasing;

	// Use this for initialization
	void Start () {

		if (PlayerPrefs.HasKey("HighScore"))
		{
			highScoreCount = PlayerPrefs.GetFloat("HighScore");
		}
	}
	
	// Update is called once per frame
	void Update () {	

		//increases and updates the score based on how long the player can survive 
		if (scoreIncreasing) {
			scoreCount += pointsPerSecond * Time.deltaTime;
		}

		/*
		if the score obtained becomes higher thand the previous high score
		then the new high score will be updated.
		*/
		if (scoreCount > highScoreCount) {
			highScoreCount = scoreCount;
			PlayerPrefs.SetFloat("HighScore", highScoreCount);
		}
		 
		//the score will be shown on the screen as rounded whole numbers
		scoreText.text = "Score: " + Mathf.Round(scoreCount);
		highScoreText.text = "High Score: " + Mathf.Round(highScoreCount);
	}

	public void resetHigh ()
	{
		highScoreCount = 0;
		PlayerPrefs.SetFloat("HighScore", highScoreCount);
	}

}
