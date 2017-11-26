using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
Will destroy the platforms unneeded after the player has past them.
To be used in conjuction with the point at which the platform should be destroyed.
*/
public class PlatformDestroyer : MonoBehaviour {

	public GameObject platformDestructionPoint;

	// Use this for initialization
	void Start () {

		//will find the point the platform will be destroyed
		platformDestructionPoint = GameObject.Find("PlatformDestructionPoint");
	}
	
	// Update is called once per frame
	void Update ()
	{

		/*
		When the platform point goes before the dynamically moving point of destruction
		it will be deactivated, to be used with the ObjectPooler script, and will be 
		actived when it will be needed again after generating it to it's new further position.
		*/
		if (transform.position.x < platformDestructionPoint.transform.position.x) {
			gameObject.SetActive(false);
		}
	}
}
