﻿/*
 * 
 * Authors: Spencer Wilson, Keiran Glynn
 * Date Created: 3/5/2018 @ 3:15 pm
 * Date Modified: 3/5/2018 @ 5:13 pm
 * Project: CompSciClubSpring2018
 * File: FerroxMovement.cs
 * Description: This class houses the code for the movement of the ferrox.
 * 
 */

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public float speed;
private Rigidbody2D playerRB;
 

public class FerroxMovement : MonoBehaviour {

	// Use this for initialization
	void Start () {

        playerRb = GetComponent<Rigidbody2D>();

	}
	
	// Update is called once per frame
	void FixedUpdate () {

        if (Input.GetKey("d"))
        {
            transform.Translate(Vector2.right * Time.deltaTime * speed);
        }

        if (Input.GetKey("a"))
        {
            transform.Translate(Vector2.left * Time.deltaTime * speed);
        }


	}
}
