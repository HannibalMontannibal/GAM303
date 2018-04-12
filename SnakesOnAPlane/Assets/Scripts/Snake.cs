using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

public class Snake : MonoBehaviour
{

	// The current Movement Direction
	// (as a default it moves to the right)
	Vector2 dir = Vector2.right;

	// Keeps track of the Tail
	List<Transform> tail = new List<Transform>();

	// Did the snake eat something?
	bool snakeAte = false;

	// Tail Prefab
	public GameObject tailPrefab;

	// Use this for initialization
	void Start () 
	{
		// Moves the Snake every one hundred miliseconds
		InvokeRepeating("Move", 0.1f, 0.1f);
	}
	
	// Update is called once per frame
	void Update () 
	{
		// For moving in a new Direction
		if (Input.GetKey(KeyCode.D))
			dir = Vector2.right;
		else if (Input.GetKey(KeyCode.S))
			dir = -Vector2.up;    // '-up' being 'down'
		else if (Input.GetKey(KeyCode.A))
			dir = -Vector2.right; // '-right' being 'left'
		else if (Input.GetKey(KeyCode.W))
			dir = Vector2.up;
		
	}

	//handles the snake movement
	void Move()
	{
		// Saves the current position 
		Vector2 v = transform.position;
		
		// Moves the head in a new direction
		transform.Translate(dir);

		// Ate something? Then insert new Element into gap
		if (snakeAte) {
			// Load Prefab into the world
			GameObject g =(GameObject)Instantiate(tailPrefab,
				v,
				Quaternion.identity);

			// Keeps track of it in our tail list
			tail.Insert(0, g.transform);

			// Resets the flag
			snakeAte = false;
		}

		// Checks whether the snake has a tail or not
		if (tail.Count > 0)
		{
			// Move last Tail Element to where the Head was
			tail.Last().position = v;

			// Add to front of list, remove from the back
			tail.Insert(0, tail.Last());
			tail.RemoveAt(tail.Count-1);
		}
	}

	void OnTriggerEnter2D(Collider2D coll) {
		// Is it Food?
		if (coll.name.StartsWith ("FoodPrefab")) {
			// Get longer in next Move call
			snakeAte = true;

			// Destroy the Food from the scene
			Destroy (coll.gameObject);
		}

		// If the snake collided with either it's own Tail or Border
		else {
			// 'Game Over' screen
		}

	}
}
