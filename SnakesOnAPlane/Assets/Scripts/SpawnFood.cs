using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFood : MonoBehaviour {

	//the Food prefab
	public GameObject foodPrefab;

	//the Borders
	public Transform borderTop;
	public Transform borderBottom;
	public Transform borderLeft;
	public Transform borderRight;

	//spawn one piece of food
	void Spawn()
	{
		// x position between left & right border
		int x = (int)Random.Range(borderLeft.position.x,
			borderRight.position.x);

		// y position between top & bottom border
		int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);

		// Instantiate the food at (x, y) point
		Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity); //the default rotation
	}

	// Use this for initialization
	void Start () 
	{
		//spawns food every five seconds, starting in three
		//InvokeRepeating("Spawn", 3, 5);
	}

}
