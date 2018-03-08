using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerUp : MonoBehaviour 
{
	public GameObject playerModel;
	//when the player hits the powerup, their scale increases to x3 their size for two seconds, and then sets back to normal once the three seconds is up.

	void OnTriggerEnter(Collider other)
	{
		if (other.gameObject.CompareTag ("Projectile"))
		{
			other.gameObject.transform.localScale = new Vector3 (3, 3, 3);
			other.gameObject.GetComponent<Rigidbody> ().mass = 3;
			StartCoroutine(WaitTime(other));
			//Destroy (gameObject);
		}
	}

	IEnumerator WaitTime(Collider other)
	{
		yield return new WaitForSeconds (2);
	
		//transform.localScale += new Vector3(1, 1, 1);
		other.gameObject.transform.localScale = new Vector3 (1, 1, 1);

	}
}
