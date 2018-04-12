﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
	private bool canAttack = true;
	private bool attacking = false;

	private float coolDownTimer = 0;
	private float coolDownLength = 1.0f;

	private float animationTimer = 0;
	public float animationLength = 0.3f;

	public Collider2D attackTrigger;

	private Animator anim;

	void Awake ()
	{
		anim = gameObject.GetComponent<Animator> ();
		attackTrigger.enabled = false;
	}

	// Use this for initialization
	void Start () 
	{
		coolDownTimer = coolDownLength;
		animationTimer = animationLength;
	}
	
	// Update is called once per frame
	void Update () 
	{
		coolDownTimer += Time.deltaTime;
		animationTimer += Time.deltaTime;

		canAttack = coolDownTimer > coolDownLength;

		if (Input.GetKeyDown (KeyCode.Mouse0) && canAttack)
			{
				coolDownTimer = 0;
				animationTimer = 0;
			}

		attacking = animationTimer < animationLength;
		attackTrigger.enabled = attacking;
		anim.SetBool ("Attacking", attacking);
		Debug.Log (attacking);
	}
}