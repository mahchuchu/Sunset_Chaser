using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script will make the objects (i.e. platforms) that are generated ahead of player to be activated,
and the ones that are destroyed after they are out of the Main Camera to be deactived.
The purpose of this script is to reuse objects so the game does not continue to create 
countless objects that will increase the amount of memory used and decrease the processing times.
*/
public class ObjectPooler : MonoBehaviour {

	public GameObject pooledObject;

	public int pooledAmount;

	List<GameObject> pooledObjects;

	// Use this for initialization
	void Start ()
	{
		//variable will get a list of the objects to reuse.
		pooledObjects = new List<GameObject> ();

		/*
		the amount of objects to be pooled will be created as set by the player 
		and will set the object to be inactive and adds it to the list.
		*/
		for (int i = 0; i < pooledAmount; i++) 
		{
			GameObject obj = (GameObject)Instantiate(pooledObject);
			obj.SetActive(false);
			pooledObjects.Add(obj);
		}
	}

	/*
	Will create and find the pooled object we will need to use,
	and add more to the list as necessary. Uses the inactive objects to be used next,
	and deactives ones we don't need.
	*/
	public GameObject GetPooledObject ()
	{

		for (int i = 0; i < pooledObjects.Count; i++) 
		{
			//if an object is not active, it will be returned as the next one to be used.
			if (!pooledObjects[i].activeInHierarchy) 
			{
				return pooledObjects[i];
			}
		}

		/*
		Will set the object to inactive, and add more objects as necessary
		and return the newly created object as the next active object.
		*/
		GameObject obj = (GameObject)Instantiate(pooledObject);
		obj.SetActive(false);
		pooledObjects.Add(obj);
		return obj;
	}
}
