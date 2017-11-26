using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Functions for the Main Menu Screen
public class MainMenu : MonoBehaviour {

	public string sunsetChaserGame;

	//Allows the player to start the actual Sunset Chaser game.
	public void PlayGame () {
		SceneManager.LoadScene (sunsetChaserGame);
	}

	//Exits out of the game application.
	public void QuitGame () {
		Application.Quit ();
	}
}
