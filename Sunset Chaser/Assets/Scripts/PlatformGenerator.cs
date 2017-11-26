using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script will create platforms ahead of the player to be used.
This include randomly selecting distance between the platform both width and height,
randomly selecting with platforms to use,
and keeping the same size ratio for all newly generated platforms.
*/
public class PlatformGenerator : MonoBehaviour {

	public GameObject thePlatform;
	public Transform generationPoint;
	public Transform fixedPlat;

	public float distBetween;	
	public float distBetweenMin;
	private float platformWidth;
	public float distBetweenMax;

	private int platformSelector;
	private float[] platformWidths;	

	public ObjectPooler[] theObjectPools;

	private float minHeight;
	private float maxHeight;

	private float heightChange;
	public float maxHeightChange;
	public Transform maxHeightPoint;

	// Use this for initialization
	void Start () {

		//Sets variable to the length of each object to be generated into an array
		platformWidths = new float[theObjectPools.Length];

		//for each of the object to be generated, it will add the objects sizes into the array
		for (int i = 0; i < theObjectPools.Length; i++) 
		{
			platformWidths[i] = theObjectPools[i].pooledObject.GetComponent<BoxCollider2D>().size.x;
		}

		//sets lowest and highest heights platforms will be generated
		minHeight = transform.position.y;
		maxHeight = maxHeightPoint.position.y;
	}
	
	// Update is called once per frame
	void Update () {	

		/*
		Sets "fixedPlat" as the new parent of the player GameObject.
		makes the newly generated platform have the same size as the parent.
		*/
		thePlatform.transform.SetParent (fixedPlat);

		//Same as above, except this makes the player keep its local orientation rather than its global orientation.
		thePlatform.transform.SetParent (fixedPlat, false);


		if (transform.position.x < generationPoint.position.x) 
		{
			//randomly selects how far apart the generated platform will be from the previous one.
			distBetween = Random.Range (distBetweenMin, distBetweenMax);

			//randomly selects the different platform to be used.
			platformSelector = Random.Range (0, theObjectPools.Length);

			//randomly select the heights of all the platforms to be generated.
			heightChange = transform.position.y + Random.Range (maxHeightChange, -maxHeightChange);

			//this won't allow the generated platform to be higher or lower than the max height allowed
			if (heightChange > maxHeight) 
			{
				heightChange = maxHeight;
			} 
			else if (heightChange < minHeight) 
			{
				heightChange = minHeight;
			}
				
			//incorporates all the randomly generated aspects for the newly generated platforms into one variable.
			transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2) + distBetween, heightChange, transform.position.z);

			/*
			Will use the next available inactive pooled object to be used and 
			gives it the same randomly generated aspects as previous objects and 
			sets it to be active.
			*/
			GameObject newPlatform = theObjectPools[platformSelector].GetPooledObject();
			newPlatform.transform.position = transform.position;
			newPlatform.transform.rotation = transform.rotation;
			newPlatform.SetActive (true);

			//the position will move the end of the previous platform than more in the middle.
			transform.position = new Vector3(transform.position.x + (platformWidths[platformSelector] / 2), transform.position.y, transform.position.z);
		}
	}
}
