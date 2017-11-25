﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

	public string mainMenuLevel;

	public GameObject pauseMenu;

	public void Pause ()
	{
		//if (Input.GetKeyDown (KeyCode.Escape)) {
			Time.timeScale = 0f;
			pauseMenu.SetActive (true);
		
	}

	public void Resume ()
	{
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
	}

	public void Restart () {
		Time.timeScale = 1f;
		pauseMenu.SetActive(false);
		FindObjectOfType<GameManager>().Reset();
	}
	

	public void QuitToMainMenu () {
		Time.timeScale = 1f;
		SceneManager.LoadScene(mainMenuLevel);
	}
}
