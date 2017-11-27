using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
This script involves every function and ability of the Player "Cloudian" (Cloud Character)
It includes player speed, how the player jumps, interaction with the ground tags, and player's death
*/
public class CloudianController : MonoBehaviour {

	public float moveSpeed;
	public float jumpForce;

	public float jumpTime;
	private float jumpTimeCounter;
	private bool stoppedJumping;

	private Rigidbody2D myBody;

	public bool grounded;
	public LayerMask isGround;
	public Transform groundCheck;
	public float groundCheckRadius;

	public GameManager theGameManager;

	public AudioSource jumpSound;
	public AudioSource deathSound;

	// Use this for initialization
	void Start () {

		//myBody will have access to the physics of the player
		myBody = GetComponent<Rigidbody2D>();

		//how high the player can jump to the maximum height they can jump.
		jumpTimeCounter = jumpTime;

		//makes it so the player sprite will always be upright.
		myBody.freezeRotation = true;
	}
	
	// Update is called once per frame
	void Update () {

		//sets variable "grounded" to check if the player is currently on the ground (not in the air jumping);
		grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, isGround);

		//sets the player speed running
		myBody.velocity = new Vector2 (moveSpeed, myBody.velocity.y);

		//When the space bar is pushed, it allows the player to jump
		if (Input.GetKeyDown (KeyCode.Space)) 
		{
			if (grounded) 
			{
				myBody.velocity = new Vector2 (myBody.velocity.x, jumpForce);
				stoppedJumping = false;
				jumpSound.Play();
			}
		}

		/*
		While the space bar is held down, the player will jump higher 
		until the highest point the player's allowed to jump.
		*/
		if (Input.GetKey (KeyCode.Space) && !stoppedJumping) 
		{
			if (jumpTimeCounter > 0) 
			{
				myBody.velocity = new Vector2 (myBody.velocity.x, jumpForce);
				jumpTimeCounter -= Time.deltaTime;
			}
		}

		/*
		Once the space bar is let go, the player will begin to fall again,
		also the player will not be able to jump again until after landing on the ground.
		*/
		if (Input.GetKeyUp (KeyCode.Space)) 
		{
			jumpTimeCounter = 0;
			stoppedJumping = true;
		}

		/*
		While the player is on or after landing on the ground, 
		the ability to do a higher jump is reset and will be able to do it again.
		*/
		if (grounded) 
		{
			jumpTimeCounter = jumpTime;
		}
	}

	/*
	When the player falls, they die and the game will restart.
	More specifically go to the DeathMenu to have the option to restart or quit.
	*/
	void OnCollisionEnter2D (Collision2D other) {
		
		//Checks when the player touces the object which will kill it.
		if (other.gameObject.tag == "killbox") 
		{
			theGameManager.RestartGame ();
			deathSound.Play();
		}
	}
}
