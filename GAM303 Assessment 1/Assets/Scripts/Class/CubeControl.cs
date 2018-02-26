using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeControl : MonoBehaviour {
	public float moveSpeed;

	// Use this for initialization
	void Start () 
	{
		moveSpeed	= 1f;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKey (KeyCode.LeftArrow)) 
		{
			transform.Translate (Vector3.left * Time.deltaTime * moveSpeed);
		}

		if (Input.GetKey (KeyCode.RightArrow)) 
		{
			transform.Translate (Vector3.right * Time.deltaTime * moveSpeed);
		}

		if (Input.GetKey (KeyCode.UpArrow)) 
		{
			transform.Translate (Vector3.up * Time.deltaTime * moveSpeed);
		}

		if (Input.GetKey (KeyCode.DownArrow)) 
		{
			transform.Translate (Vector3.down * Time.deltaTime * moveSpeed);
		}
	}
}
