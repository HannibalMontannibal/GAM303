using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerAlt : MonoBehaviour 
{
	Rigidbody2D rb2d;
	public float moveSpeed; //speed var
	public int dodgeCount;
	public float dodgeSpeed;
	private Vector2 dodgeVect;

	public LevelGenerator levelGen;

	void Start ()
	{
		rb2d = GetComponent<Rigidbody2D> ();

	}


	void FixedUpdate ()
	{
		MovePlayer ();
	}


	void MovePlayer ()
	{
		//get H and V vars
		float hMove = Input.GetAxisRaw ("Horizontal");
		float vMove = Input.GetAxisRaw ("Vertical");

		//move player
		Vector2 movement = new Vector2 (hMove, vMove);
		rb2d.velocity = movement.normalized * moveSpeed;

		if (Input.GetKeyDown(KeyCode.Mouse1) && movement != Vector2.zero && dodgeCount == 0) //vector2.zero should be  (0,0) which movement will be if you're not moving.
		{
			dodgeCount = 60; //[frames for how long dodging lasts]
			dodgeVect = movement.normalized;
		}
		//What all this does is set a timer for the dodge and record what direction you're dodging in, if you're moving, trying to dodge, and not standing perfectly still.


		if (dodgeCount != 0) {
			dodgeCount -= 1; //Does this work in c#? reduce dodgecount by one somehow else if it doesn't.
			rb2d.velocity = dodgeVect.normalized * dodgeSpeed; //Yes, it's already supposed to have a magnitude of one, but it's not a bad idea to be safe.
		}
		//If you're still dodging (counter isn't zero yet), move in the dodge direction at the dodge speed.

	}

}
