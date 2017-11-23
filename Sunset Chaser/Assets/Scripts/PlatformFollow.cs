using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFollow : MonoBehaviour {

//DELETE LATER

	private Rigidbody2D plat;

	public float moveSpeed;

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
	}
}
