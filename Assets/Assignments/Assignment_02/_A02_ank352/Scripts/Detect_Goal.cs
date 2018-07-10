using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01ank352 {
	public class Detect_Goal : MonoBehaviour {

		//Set colors for when game starts and when goal is reached
		public Color no_goal = Color.red;
		public Color goal = Color.green;

		void Start () {
			//Initially make the color of the goal to no_goal color
			Renderer rend = GetComponent<Renderer>();
			rend.material.SetColor("_Color", no_goal);
		}

		//If ball collides with goal, set the color of the goal to green and destroy the ball object
		void OnCollisionEnter (Collision col) {
			if(col.gameObject.name == "PlayerBall(Clone)") {
				Renderer rend = GetComponent<Renderer>();
				rend.material.SetColor("_Color", goal);
				Destroy(col.gameObject);
			}
		}
	}
}
