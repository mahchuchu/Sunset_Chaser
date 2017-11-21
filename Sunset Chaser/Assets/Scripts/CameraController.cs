using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public CloudianController cloudPlayer;

	private Vector3 lastPlayerPosition;
	private float distanceToMove;

	// Use this for initialization
	void Start () {
		cloudPlayer = FindObjectOfType<CloudianController>();
		lastPlayerPosition = cloudPlayer.transform.position;
	}
	
	// Update is called once per frame
	void Update () {
		distanceToMove = cloudPlayer.transform.position.x - lastPlayerPosition.x;

		transform.position = new Vector3(transform.position.x + distanceToMove, transform.position.y, transform.position.z);

		lastPlayerPosition = cloudPlayer.transform.position;

	}
}
