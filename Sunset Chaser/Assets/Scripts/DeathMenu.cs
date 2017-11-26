using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

//Functions for a Death Menu screen for after the player dies.
public class DeathMenu : MonoBehaviour {

	public string mainMenuLevel;

	//Calls the GameManager's Reset function.
	public void Restart () {
		FindObjectOfType<GameManager>().Reset();
	}
	
	//Calls the GameManager's function to bring you to the Main Menu screen
	public void QuitToMainMenu () {
		SceneManager.LoadScene(mainMenuLevel);
	}
}
