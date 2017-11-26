using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Manages a global variable and functions to be used in other scripts.
Using a singleton pattern.
*/
public class GameManager : MonoBehaviour {

	public Transform platformGenerator;
	private Vector3 platformStartPoint;

	public CloudianController thePlayer;
	private Vector3 playerStartPoint;

	private PlatformDestroyer[] platformList;

	private ScoreManager theScoreManager;

	public DeathMenu theDeathScreen;

	// Use this for initialization
	void Start () {

		//sets the original start positions of the player and platforms
		platformStartPoint = platformGenerator.position;
		playerStartPoint = thePlayer.transform.position;

		//variable sets to parameters from ScoreManager script
		theScoreManager = FindObjectOfType<ScoreManager>();
	}

	/*
	When the player dies the score will stop increasing,
	the player will be inactive,
	and the death menu will pop up.
	*/
	public void RestartGame ()
	{
		theScoreManager.scoreIncreasing = false;
		thePlayer.gameObject.SetActive(false);
		theDeathScreen.gameObject.SetActive(true);
	}


	//Purpose is to reset the game to be able to play again when in the Pause Menu.
	public void Reset ()
	{
		//Death Menu will disappear
		theDeathScreen.gameObject.SetActive(false);

		//Deactives all the platforms
		platformList = FindObjectsOfType<PlatformDestroyer> ();
		for (int i = 0; i < platformList.Length; i++) 
		{
			platformList [i].gameObject.SetActive (false);
		}

		//The player and platforms return to original start position
		thePlayer.transform.position = playerStartPoint;
		platformGenerator.position = platformStartPoint;

		//Activates the player
		thePlayer.gameObject.SetActive (true); 

		//resets score values
		theScoreManager.scoreCount = 0;
		theScoreManager.scoreIncreasing = true;
	}
}
