using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01ank352 {
	public class Tilt : MonoBehaviour {

		//Controls for tilting maze (can be changed in Unity)
		public KeyCode tiltForward = KeyCode.I;
		public KeyCode tiltBackward = KeyCode.K;
		public KeyCode tiltLeft = KeyCode.J;
		public KeyCode tiltRight = KeyCode.L;

		//Use renderer component so that maze can only tilt when it is in view of camera
		Renderer m_Renderer;

		// Use this for initialization
		void Start () {
			m_Renderer = GetComponent<Renderer>();

		}

		void Update () {
			//If object is in view...
			if (m_Renderer.isVisible) {
				//If any of the rotate keys are pressed, rotate the maze in the corresponding rotation
				if (Input.GetKeyDown(tiltForward)) {
					transform.rotation *= Quaternion.Euler(1,0,0);
				}
				if (Input.GetKeyDown(tiltBackward)) {
					transform.rotation *= Quaternion.Euler(-1,0,0);
				}
				if (Input.GetKeyDown(tiltLeft)) {
					transform.rotation *= Quaternion.Euler(0,0,1);
				}
				if (Input.GetKeyDown(tiltRight)) {
					transform.rotation *= Quaternion.Euler(0,0,-1);
				}
			}
		}
	}

}
