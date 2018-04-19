using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class MathGenerator : MonoBehaviour {

	enum Difficulty 
	{
		EASY, 
		MEDIUM, 
		HARD
	};

	public Text[] equation;	//0 = first number, 1 = operator, 2 = second number, 3 = =, 4 = answer
	public Text[] answerButtons;
	public Text difficultyHolder;
	public Text correctOrNot;

	int firstNumber;
	int secondNumber;
	int correctAnswer;
	int dummyAnswer;

	public int dummyCount;
	public List<int> answers;
	public List <GameObject> foodPrefabList;

	Difficulty difficulty;

	//the Food prefab
	public GameObject foodPrefab;

	//the Borders
	public Transform borderTop;
	public Transform borderBottom;
	public Transform borderLeft;
	public Transform borderRight;

	public bool gameOver = false;
	public GameObject gameOverText;

	void Start()
	{
		difficulty = Difficulty.EASY;
		Generate ();
//		correctOrNot.text = "";
	}


	//spawn one piece of food
	void Spawn(GameObject spawnedObject)
	{
		// x position between left & right border
		int x = (int)Random.Range(borderLeft.position.x,
			borderRight.position.x);

		// y position between top & bottom border
		int y = (int)Random.Range(borderBottom.position.y, borderTop.position.y);

		spawnedObject.transform.position = new Vector3 (x, y, 0);
		Debug.Log(x + "" +y);
		// Instantiate the food at (x, y) point
		//Instantiate(foodPrefab, new Vector2(x, y), Quaternion.identity); //the default rotation
	}


	int AdditionProblem(int numberOne, int numberTwo)
	{
		firstNumber = numberOne;
		secondNumber = numberTwo;
		int correct = firstNumber + secondNumber;	//Our correct answer

		return firstNumber + secondNumber;
	}


	int DummyAddition(int correctAnswer)
	{
		int dummy = GetRandom ();
		if (dummy != correctAnswer)
			return dummy;
		else
			return (DummyAddition(correctAnswer));
	}

	void Update()
	{
		if (Input.GetKeyDown (KeyCode.Space))
			Generate ();
		if (Input.GetKeyDown(KeyCode.Alpha1))
			difficulty = Difficulty.EASY;
		if (Input.GetKeyDown(KeyCode.Alpha2))
			difficulty = Difficulty.MEDIUM;
		if (Input.GetKeyDown(KeyCode.Alpha3))
			difficulty = Difficulty.HARD;

//		difficultyHolder.text = difficulty.ToString();

		if (gameOver == true && Input.GetKeyDown (KeyCode.Space)) 
		{
			SceneManager.LoadScene (SceneManager.GetActiveScene ().buildIndex);
		}

	//	Cursor.visible = false;
	}

	public void Generate()
	{
		correctAnswer = AdditionProblem (GetRandom(), GetRandom());

		equation [0].text = firstNumber.ToString ();

		equation [2].text = secondNumber.ToString ();

		equation [4].text = "???";

		dummyAnswer = DummyAddition (correctAnswer);	//For a single

		//for a longer size
		answers.Clear();
		for (int i = 0; i < dummyCount; i++)
			answers.Add (DummyAddition (correctAnswer));

		//answers.Add (correctAnswer);	//Add the correct answer to the list

		PutNumbersOnButtons ();
	}

	void PutNumbersOnButtons()
	{
		//Shuffles a list ( randomizes the positions)
		for (int i = 0; i < answers.Count; i++) 
		{
			int temp = answers[i];
			int randomIndex = Random.Range (0, answers.Count);
			answers [i] = answers [randomIndex];
			answers [randomIndex] = temp;
		}

		foodPrefabList[0].GetComponentInChildren<TextMesh>().text = answers[0].ToString();

		foodPrefabList[1].GetComponentInChildren<TextMesh>().text = answers[1].ToString();

		foodPrefabList[2].GetComponentInChildren<TextMesh>().text = answers[2].ToString();

		foodPrefabList[3].GetComponentInChildren<TextMesh>().text = answers[3].ToString();

		foodPrefabList[4].GetComponentInChildren<TextMesh>().text = correctAnswer.ToString();

		for (int i = 0; i < foodPrefabList.Count; i++) 
		{
			Spawn (foodPrefabList [i]);
		}
	//	answerButtons [0].text = answers[0].ToString();
	//	answerButtons [1].text = answers[1].ToString();
	//	answerButtons [2].text = answers[2].ToString();
	//	answerButtons [3].text = answers[3].ToString();
	}

	int GetRandom()
	{
		if (difficulty == Difficulty.EASY)
			return Random.Range (1, 10);
		else if (difficulty == Difficulty.MEDIUM)
			return Random.Range (1, 100);
		else 
			return Random.Range (1, 1000);
	}

	public void CheckButton(Text t)
	{
		if (t.text != correctAnswer.ToString ())
			correctOrNot.text = "WRONG";
		else {
			correctOrNot.text = "CORRECT";
			equation [4].text = correctAnswer.ToString ();
		}
			
	}

	public void PlayerDied ()
	{
		gameOver = true;

		gameOverText.SetActive (true);

		if (gameOver = true)
		{
			Cursor.visible = true;
		}
	}

}
