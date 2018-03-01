using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour 
{
	public void ToGame()
	{
	//plays the game when you press the Start Button
		SceneManager.LoadScene("MissionDemolition");
	}
}
