using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour {

	public string sunsetChaserGame;

	public void PlayGame ()
	{
		SceneManager.LoadScene (sunsetChaserGame);
	}

	public void QuitGame ()
	{
		Application.Quit ();
	}


}
