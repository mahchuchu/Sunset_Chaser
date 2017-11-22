using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFollow : MonoBehaviour {

	private Rigidbody2D plat;

	public float moveSpeed;
	//public GameObject[] deletePlat;

	// Use this for initialization
	void Start () {
		plat = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		plat.velocity = new Vector2 (moveSpeed, plat.velocity.y);

		if (gameObject.name == "cloudP1(Clone)") {
			Destroy (GetComponent<Rigidbody2D>());
		}

		/*deletePlat = GameObject.FindGameObjectWithTag ("ground");
		for (int i = 0; i < deletePlat.Length; i++) {
			Destroy(GetComponent<Rigidbody2D>());
		}*/

	}
}
