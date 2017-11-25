using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;
	public float distBetween;
	public Transform fixedPlat;

	private float platformWidth;

	private float[] platformWidths;

	public float distBetweenMin;
	public float distBetweenMax;

	public GameObject[] thePlatforms;
	private int platformSelector;

	//public ObjectPooler theObjectPool;

	// Use this for initialization
	void Start ()
	{
		//platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;

		platformWidths = new float[thePlatforms.Length];

		for (int i = 0; i < thePlatforms.Length; i++) {
			platformWidths[i] = thePlatforms[i].GetComponent<BoxCollider2D>().size.x;
		}

	}
	
	// Update is called once per frame
	void Update ()
	{	
		//Sets "fixedPlat" as the new parent of the player GameObject.
        thePlatform.transform.SetParent(fixedPlat);

        //Same as above, except this makes the player keep its local orientation rather than its global orientation.
        thePlatform.transform.SetParent(fixedPlat, false);


		if (transform.position.x < generationPoint.position.x) {

			distBetween = Random.Range(distBetweenMin, distBetweenMax);

			platformSelector = Random.Range(0, thePlatforms.Length);

			transform.position = new Vector3(transform.position.x + platformWidths[platformSelector] + distBetween, transform.position.y, transform.position.z);



			Instantiate (/*thePlatform */ thePlatforms[platformSelector], transform.position, transform.rotation);

			/*
			GameObject newPlatform = theObjectPool.GetPooledObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);
			*/
		}
	}
}
