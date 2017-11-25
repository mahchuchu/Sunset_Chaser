using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CloudianController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;

	public float jumpTime;
	private float jumpTimeCounter;

	private bool stoppedJumping;

	private Rigidbody2D myBody;

	public bool grounded;
	public LayerMask whatIsGround;
	public Transform groundCheck;
	public float groundCheckRadius;

	//private Collider2D myCollider;

	public GameManager theGameManager;


	// Use this for initialization
	void Start () {
		myBody = GetComponent<Rigidbody2D>();
		//myCollider = GetComponent<Collider2D>();
		jumpTimeCounter = jumpTime;

		myBody.freezeRotation = true;

		stoppedJumping = true;
	}
	
	// Update is called once per frame
	void Update ()
	{

		//grounded = Physics2D.IsTouchingLayers (myCollider, whatIsGround);

		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

		myBody.velocity = new Vector2 (moveSpeed, myBody.velocity.y);

		if (Input.GetKeyDown (KeyCode.Space)) {
			if (grounded) {
				myBody.velocity = new Vector2 (myBody.velocity.x, jumpForce);
				stoppedJumping = false;
			}
		}

		if (Input.GetKey (KeyCode.Space) && !stoppedJumping) {
			if (jumpTimeCounter > 0) {
				myBody.velocity = new Vector2 (myBody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		if (Input.GetKeyUp (KeyCode.Space)) {
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}

		if (grounded) {
			jumpTimeCounter = jumpTime;
		}

	}

	void OnCollisionEnter2D (Collision2D other)
	{
		if (other.gameObject.tag == "killbox") {
			theGameManager.RestartGame ();
		}
	}
			

}
