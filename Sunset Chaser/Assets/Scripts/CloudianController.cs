using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudianController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;

	private Rigidbody2D myBody;

	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{
		myBody.velocity = new Vector2 (moveSpeed, myBody.velocity.y);

		if (Input.GetKeyDown (KeyCode.Space)) {
			myBody.velocity = new Vector2 (myBody.velocity.x, jumpForce);
		}
	}
}
