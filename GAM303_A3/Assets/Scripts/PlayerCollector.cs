using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCollector : MonoBehaviour {

	void OnTriggerEnter (Collider col)
	{
		//notifies that the player has collected the object
		print (name + "has been collected!");
		Destroy (gameObject);
	}
}
