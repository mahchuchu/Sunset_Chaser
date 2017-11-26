using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script's main purpose is to have the Main Camera follow the Player
along the X-axis while the Player progress through the game.
*/
public class CameraController : MonoBehaviour {

	public CloudianController cloudPlayer;

	private Vector3 lastPosition;
	private float distanceToMove;


	//Use this for initialization
	void Start () {

		//Finds the script for the Player sets it to variable cloudPlayer
		cloudPlayer = FindObjectOfType<CloudianController>();

		//variable lastPosition to get it's previous dynamically moving position
		lastPosition = cloudPlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {

		//sets the rate at which the camera would move
		distanceToMove = cloudPlayer.transform.position.x - lastPosition.x;

		//updates the Players previous dynamically moving position 
		lastPosition = cloudPlayer.transform.position;

		//makes the camera move only right at the same rate as the Player
		transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);
	}
}
