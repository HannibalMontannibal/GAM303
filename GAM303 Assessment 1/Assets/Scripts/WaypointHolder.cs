using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaypointHolder : MonoBehaviour 
{
	public Text scoreText;

	public  float score;
	public  float timer;

	public void UpdateScore()
	{
		score += 100;
		scoreText.text = score.ToString ();
	}
}
