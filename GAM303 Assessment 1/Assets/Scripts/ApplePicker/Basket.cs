using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Basket : MonoBehaviour {

	public TextMesh scoreGT;

	// Use this for initialization
	void Start () 
	{
		// Find a reference to the ScoreCounter GameObject
		GameObject scoreGO = GameObject.Find("ScoreCounter");

		// Get the GUIText Component of that GameObject
		scoreGT = scoreGO.GetComponent<TextMesh>(); 

		// Set the starting number of points to 0
		scoreGT.text = "0";
	}
	
	// Update is called once per frame
	void Update () 
	{
		//get current screen position of the mouse from Input
		Vector3 mousePos2D = Input.mousePosition;

		//the camera's z position sets how far to push the mouse into 3D
		mousePos2D.z= -Camera.main.transform.position.z;

		//convert the point from 2D screen space into 3D game world space
		Vector3 mousePos3D = Camera.main.ScreenToWorldPoint (mousePos2D);

		//move the x position of this Basket to the x position of the Mouse
		Vector3 pos =  this.transform.position;
		pos.x = mousePos3D.x;
		this.transform.position = pos;
			
	}

	void OnCollisionEnter (Collision coll)
	{
		//find out what hit the basket
		GameObject collidedWith = coll.gameObject;
		if (collidedWith.tag == "Apple") 
		{
			//if what came into contact with the basket had the "apple" tag attached to it, the apple gets destroyed
			Destroy (collidedWith);
		}

		// Parse the text of the scoreGT into an int
		int score = int.Parse( scoreGT.text ); 

		// Add points for catching the apple
		score += 100;

		// Convert the score back to a string and display it
		scoreGT.text = score.ToString();
	}
}
