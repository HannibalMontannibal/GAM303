using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMovement : MonoBehaviour {

	public CharacterController myController;

	public float speed = 3f;
	public float gravityStrength =5f;
	public float jumpSpeed = 10f;
	public Transform cameraTransform;
	public bool canJump = false;
	float verticalVelocity;
	Vector3 velocity;
	Vector3 groundedVelocity;

	// Update is called once per frame
	void Update ()
	{
		Vector3 myVector = new Vector3 (0, 0, 0);

		//get imput from the player
		if (myController.isGrounded) {
			myVector.x = Input.GetAxis ("Horizontal");

			myVector.z = Input.GetAxis ("Vertical");

			myVector = Vector3.ClampMagnitude (myVector, 1f);
		
			myVector *= Time.deltaTime;
			//myVector = myVector * speed * Time.deltaTime;
			Quaternion inputRotation = Quaternion.LookRotation (Vector3.ProjectOnPlane (cameraTransform.forward, Vector3.up), Vector3.up);
			myVector = inputRotation * myVector;
		} 
		else 
		{
			myVector = groundedVelocity;
			myVector = myVector * speed * Time.deltaTime;
		}

	//	myVector = cameraTransform.rotation * myVector;//rotates input by direction of the camera


		//jumping
		verticalVelocity = verticalVelocity - gravityStrength * Time.deltaTime;

		if (Input.GetButtonDown ("Jump")) 
		{
		//add jump speed to vertical velocity
			if(canJump)
			verticalVelocity += jumpSpeed;
		}
		myVector.y = verticalVelocity * Time.deltaTime;//adds a new speed to the old speed, for acceleration

		//use input to move the player
		CollisionFlags flags = myController.Move (myVector);
		velocity = myVector / Time.deltaTime;
		print (velocity);

		//myController.Move (myVector);
	//use flags to determine whether the player can jump or not
		//if on ground, sets canJump to true
		if ((flags & CollisionFlags.Below) != 0)
		{
			groundedVelocity = velocity;
			canJump = true;
			verticalVelocity = -3f;
		} 
		else if ((flags & CollisionFlags.Sides) != 0) 
		{
			canJump = true;
		}

		else 
		{
			canJump = false;
		}
	}
}


//https://www.youtube.com/watch?v=zlNxQVflQvM