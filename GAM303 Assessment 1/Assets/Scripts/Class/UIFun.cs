using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//using UnityEngine.UI;

public class UIFun : MonoBehaviour {

//	public Text countdownTimer;
//	public Text playerInput;

	public float timer = 20f;

	// Use this for initialization
	void Start () 
	{
//		countdownTimer.text = timer.ToString ();
//		countdownTimer.color = Color.blue;
	}
	
	// Update is called once per frame
	void Update () 
	{
		if (Input.GetKeyDown("up"))
			print ("Up arrow has been hit");	

		timer -= Time.deltaTime;
//		countdownTimer.text = timer.ToString ("##.#");
	}
}
