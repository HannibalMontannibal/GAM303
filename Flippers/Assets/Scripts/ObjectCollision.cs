using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectCollision : MonoBehaviour 
{
	public Text scoreText;
	public Text highScore;

	private int score = 0;

	void Start()
	{
	//	int hs = GetHighScore ();
	//	highScore.text = "Highscore: " + hs.ToString ();
	//}

	//public void GetHighScore()
	//{
//		return PlayerPrefs.GetInt ("Highscore", 0);
	}

	public void PlayerScored()
	{
		score++;
		scoreText.text = "Score: " + score.ToString ();

	//	int hs = GetHighScore ();
	//	if (score > hs) 
	//	{
	//		PlayerPrefs.SetInt ("Highscore", score);
	//	}
	}


	void OnTriggerEnter(Collider col)
	{
		// if the ball hits
		if (col.CompareTag ("Ball")) 
		{
			PlayerScored ();
			Debug.Log ("Player Scored");
		}
	}
}
