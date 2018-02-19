using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Apple : MonoBehaviour 
{
	public static float bottomY = -20f;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () 
	{
		//removes apples that hit -20f units
		if (transform.position.y < bottomY)
		{
			Destroy (this.gameObject);
		}	
	}
}
