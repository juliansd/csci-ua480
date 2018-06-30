using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace lga238 {
	public class throwBall : MonoBehaviour {

		public float force = 150.0f;
		Rigidbody ball;
		Rigidbody clone;

		// Use this for initialization
		void Start () {
			ball = GetComponent<Rigidbody>();
		}
		
		// Update is called once per frame
		void FixedUpdate () {
			if(Input.GetButtonDown("Fire1")){
				ball.AddForce(-Vector3.forward * force);
				ball.AddForce(Vector3.up * 100.0f);
			}
			if(Input.GetButtonDown("Fire2")){
				clone = Instantiate(ball, transform.position, transform.rotation);
			}

		}
	}
}
