using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*
All the functions for a Pause Menu when the player stop the game mid-game.
Includes ability to resume the game from the same moment it was pause,
restart the game if necessary, or return to the main menu.
*/
public class PauseMenu : MonoBehaviour {

	public string mainMenuLevel;

	public GameObject pauseMenu;


	//Pauses the game mid-game, will use a button and turn on Pause Menu.
	public void Pause ()
	{
		//Freezes the screen of the game.
		Time.timeScale = 0f;
		pauseMenu.SetActive (true);
	}

	//Resumes the game where it was left off and turns off the Pause Menu.
	public void Resume ()
	{
		//Unfreezes the game to normal speed
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
	}

	//Restarts the game from the beginning, turns off Pause Menu.
	public void Restart () 
	{
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);

		//Calls the Reset function from GameManager
		FindObjectOfType<GameManager>().Reset();
	}
	
	//Unfreezes game to normal speed and takes you to the Main Menu scene.
	public void QuitToMainMenu () 
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene(mainMenuLevel);
	}

	void Update ()
	{
		if (Input.GetKeyDown (KeyCode.Escape) && pauseMenu.activeSelf == false) {
			Pause ();
		}
	}
}
