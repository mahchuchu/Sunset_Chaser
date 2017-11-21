using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;
	public float distBetween;
	public Transform newPlat;

	private float platformWidth;
	
	// Use this for initialization
	void Start () {
		platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;
	}
	
	// Update is called once per frame
	void Update ()
	{	
		//Sets "newPlat" as the new parent of the player GameObject.
        thePlatform.transform.SetParent(newPlat);

        //Same as above, except this makes the player keep its local orientation rather than its global orientation.
        thePlatform.transform.SetParent(newPlat, false);

		if (transform.position.x < generationPoint.position.x) {
			transform.position = new Vector3(transform.position.x + platformWidth + distBetween, transform.position.y, transform.position.z);
			Instantiate (thePlatform, transform.position, transform.rotation);
		}
	}
}
