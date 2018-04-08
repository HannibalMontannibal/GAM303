using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AttackingTrigger : MonoBehaviour {

	//the damage dealt to the enemy
	public int damage =  20;

	void OnTriggerEnter2D (Collider2D col)
	{
		//calls a function with whatever it is being collided with
		//if whatever is hit has the tag "enemy", then the damage function will be call, causing the enemy to take damage
		if (col.isTrigger != true && col.CompareTag("Enemy"))
		{
			col.SendMessageUpwards ("Damage", damage);
		}
	}
}
