using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

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

	Difficulty difficulty;

	void Start()
	{
		difficulty = Difficulty.EASY;
		correctOrNot.text = "";
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

		difficultyHolder.text = difficulty.ToString();
	}

	void Generate()
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

		answers.Add (correctAnswer);	//Add the correct answer to the list

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

		answerButtons [0].text = answers[0].ToString();
		answerButtons [1].text = answers[1].ToString();
		answerButtons [2].text = answers[2].ToString();
		answerButtons [3].text = answers[3].ToString();
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

}
