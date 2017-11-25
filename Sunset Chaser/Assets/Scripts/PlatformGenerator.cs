using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;
	public float distBetween;
	public Transform fixedPlat;

	private float platformWidth;



	public float distBetweenMin;
	public float distBetweenMax;

	//public GameObject[] thePlatforms;
	private int platformSelector;
	private float[] platformWidths;	


	public ObjectPooler[] theObjectPools;


	private float minHeight;
	public Transform maxHeightPoint;
	private float maxHeight;
	public float maxHeightChange;
	private float heightChange;


	// Use this for initialization
	void Start ()
	{
		//platformWidth = thePlatform.GetComponent<BoxCollider2D>().size.x;

		platformWidths = new float[theObjectPools.Length];

		for (int i = 0; i < theObjectPools.Length; i++) {
			platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}

		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;


	}
	
	// Update is called once per frame
	void Update ()
	{	
		//Sets "fixedPlat" as the new parent of the player GameObject.
		thePlatform.transform.SetParent (fixedPlat);

		//Same as above, except this makes the player keep its local orientation rather than its global orientation.
		thePlatform.transform.SetParent (fixedPlat, false);


		if (transform.position.x < generationPoint.position.x) {

			distBetween = Random.Range (distBetweenMin, distBetweenMax);

			platformSelector = Random.Range (0, theObjectPools.Length);

			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);

			if (heightChange > maxHeight) {
				heightChange = maxHeight;
			} else if (heightChange < minHeight) {
				heightChange = minHeight;
			}
				

			transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distBetween, heightChange, transform.position.z);



			//Instantiate (/*thePlatform */ thePlatforms[platformSelector], transform.position, transform.rotation);


			GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();

			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);

			transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);


		}
	}
}
