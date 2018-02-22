using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Waypoints : MonoBehaviour {

	public float score;


	void OnTriggerEnter(Collider col)
	{
		if (col.name == "ColliderBottom")
			WaypointHolder.score += 100f;
	}


	void OnTriggerExit(Collider col)
	{

	}

	void OnTriggerStay(Collider col)
	{
		
	}
}
