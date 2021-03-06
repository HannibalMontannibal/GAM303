using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
	//determines player health
	public int currentHealth;
	public int maxHealth;


	//determines the player's movement speed
	public float moveSpeed;

	private Rigidbody2D myRigidbody;

	private Animator anim;

	public LevelGenerator levelGen;



	// Use this for initialization
	void Start()
	{
		myRigidbody = GetComponent<Rigidbody2D>();
	}


	// Update is called once per frame
	void Update () 
	{
		//checks if our input on the x axis is moving the player right OR (||) left (if the player is moving the character to the right)
		if (Input.GetAxisRaw ("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < 0.5f) 
		{
			//transform.Translate (new Vector3 (Input.GetAxisRaw ("Horizontal") * moveSpeed * Time.deltaTime, 0f, 0f));
			myRigidbody.velocity = new Vector2 (Input.GetAxisRaw("Horizontal") * moveSpeed, myRigidbody.velocity.y);
		}

		//checks if the input on the y axis is mov ing the player up or down

		if (Input.GetAxisRaw ("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < 0.5f) 
		{
			//transform.Translate (new Vector3 (0f, Input.GetAxisRaw ("Vertical") * moveSpeed * Time.deltaTime, 0f));
			myRigidbody.velocity = new Vector2 (myRigidbody.velocity.x, Input.GetAxisRaw("Vertical")  * moveSpeed);
		}

		//if the player is going left, the sprite is flipped to show them going left.
		if (Input.GetAxis ("Horizontal") < -0.1f) 
		{
			transform.localScale = new Vector3 (-1, 1, 1);
		}

		//if the player is going right, the sprite is facing right
		if (Input.GetAxis ("Horizontal") > 0.1f) 
		{
			transform.localScale = new Vector3 (1, 1, 1);
		}
			


	}




}
