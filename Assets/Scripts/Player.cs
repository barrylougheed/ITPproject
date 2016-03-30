﻿using UnityEngine;
using System.Collections;

[RequireComponent (typeof (Controller2D))]
public class Player : MonoBehaviour {
	

	public float jumpheight = 4;
	public float timeToJumpApex = .4f;
	float accelerationTimeAirborne = .2f;
	float accelerationTimeGrounded = .1f;

	float moveSpeed = 6;
	float gravity;
	float jumpVelocity;
	Vector3 velocity;
	float velocityXSmoothing;

	Controller2D controller;

	void Start() {
		controller = GetComponent<Controller2D> ();

		gravity = -(2 * jumpheight) / Mathf.Pow (timeToJumpApex, 2);
		jumpVelocity = Mathf.Abs (gravity) * timeToJumpApex;
		print ("Gravity: " + gravity + " Jump Velocity: " + jumpVelocity);
	}

	void Update() {

		if (controller.collisions.above || controller.collisions.below) {
			velocity.y = 0;
		}

		Vector2 input = new Vector2 (Input.GetAxisRaw ("Horizontal"), Input.GetAxisRaw ("Vertical"));

		if (Input.GetKeyDown (KeyCode.Space) && controller.collisions.below) {
			velocity.y = jumpVelocity;
		}

		float targetVelocityX = input.x * moveSpeed;
		velocity.x = input.x * moveSpeed;
		velocity.y += gravity * Time.deltaTime;
		controller.Move (velocity * Time.deltaTime);
	}
}








































