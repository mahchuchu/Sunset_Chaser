﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

//Functions for the Main Menu Screen
public class MainMenu : MonoBehaviour {

	public string sunsetChaserGame;
	public string instructions;
	public string menu;
	public string credits;

	//Allows the player to start the actual Sunset Chaser game.
	public void PlayGame () {
		SceneManager.LoadScene (sunsetChaserGame);
	}

	//Exits out of the game application.
	public void QuitGame () {
		Application.Quit ();
	}

	//Goes to scene that explains the game and how to play it.
	public void howToPlay () {
		SceneManager.LoadScene (instructions);
	}

	//returns back to the main menu scene.
	public void backToMain () {
		SceneManager.LoadScene (menu);
	}

	//Goes to the Credits scene.
	public void creditScreen() {
		SceneManager.LoadScene (credits);
	}

}
