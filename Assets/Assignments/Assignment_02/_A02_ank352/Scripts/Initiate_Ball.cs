using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01ank352 {
	public class Initiate_Ball : MonoBehaviour {

		//Button that will spawn player object
		public KeyCode spawn = KeyCode.Space;

		//Speed of initial force
		public float speed = 1000.0f;

		//Prefab that is used as a model for the clone
		public Rigidbody ballPrefab;

		void Start () {
		}

		void Update () {
			//If player presses spawn button, instantiate a ball from the position of the camera
			if (Input.GetKeyDown(spawn)) {
				Rigidbody ball;
				ball = Instantiate(ballPrefab, transform.position, Quaternion.identity);

				//Add an initial force to the ball
				ball.AddForce(transform.forward * speed);
			}
		}
	}

}
