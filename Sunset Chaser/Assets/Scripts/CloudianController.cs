using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudianController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;

	private Rigidbody2D myBody;

	public bool grounded;
	public LayerMask whatIsGround;

	private Collider2D myCollider;

	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D>();
		myCollider = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update ()
	{

		grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);
		
		myBody.velocity = new Vector2 (moveSpeed, myBody.velocity.y);

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (grounded) {
				myBody.velocity = new Vector2 (myBody.velocity.x, jumpForce);
			}
		}
	}
}
