using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerControllerAlt : MonoBehaviour 
{
	//determines player health
	public int currentHealth;
	public int maxHealth;

	Rigidbody2D rb2d;
	public float moveSpeed; //speed var
	public int dodgeCount;
	public float dodgeSpeed;
	private Vector2 dodgeVect;

	public LevelGenerator levelGen;

	private Animator animator;

	public Text healthText;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();
		animator = GetComponent<Animator> ();

		//at spawn, the enemy's current health is whatever it's maximum health is.
		currentHealth = maxHealth;

		healthText.text = "Health Remaining: " + currentHealth.ToString ();

	}


	void FixedUpdate ()
	{
		MovePlayer ();
	}

	void Update()
	{

		//if the player's health is equal to OR less than zero, it will get destroyed- ie die
		if (currentHealth <= 0) 
		{
			Destroy (gameObject);
		}

	}

	void MovePlayer ()
	{
		//get H and V vars
		float hMove = Input.GetAxisRaw ("Horizontal");
		float vMove = Input.GetAxisRaw ("Vertical");

		//move player
		Vector2 movement = new Vector2 (hMove, vMove);
		rb2d.velocity = movement.normalized * moveSpeed;

		//if the player is going left, the sprite is flipped to show them going left.
		if (Input.GetAxis ("Horizontal") < -0.1f) 
		{
			transform.localScale = new Vector3 (1, 1, 1);
		}

		//if the player is going right, the sprite is facing right
		if (Input.GetAxis ("Horizontal") > 0.1f) 
		{
			transform.localScale = new Vector3 (-1, 1, 1);
		}


		if (Input.GetKeyDown(KeyCode.Mouse1) && movement != Vector2.zero && dodgeCount == 0) //vector2.zero should be  (0,0) which movement will be if you're not moving.
		{
			dodgeCount = 40; //[frames for how long dodging lasts]
			dodgeVect = movement.normalized;
			animator.SetTrigger("Roll");

		}
		//What all this does is set a timer for the dodge and record what direction you're dodging in, if you're moving, trying to dodge, and not standing perfectly still.


		if (dodgeCount != 0) 
		{
			dodgeCount -= 1; //Does this work in c#? reduce dodgecount by one somehow else if it doesn't.
			rb2d.velocity = dodgeVect.normalized * dodgeSpeed; //Yes, it's already supposed to have a magnitude of one, but it's not a bad idea to be safe.
		}
		//If you're still dodging (counter isn't zero yet), move in the dodge direction at the dodge speed.

	}

	public void TakeDamage(int damage)
	{
//		gameObject.GetComponent<Animator> ().SetTrigger ("Hurt");

		//removes health by however much damage the enemies dealt
		currentHealth -= damage;
		healthText.text = "Health Remaining: " + currentHealth.ToString ();

	
		//if the player health is zero or less, the player dies
		if (currentHealth <= 0) 
		{
			Debug.Log ("Dead");
			Destroy (gameObject);
			if (levelGen != null) {
				levelGen.PlayerDied ();
			}

		}
	}

}
