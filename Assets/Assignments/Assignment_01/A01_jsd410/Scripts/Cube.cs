using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01jsd410 {

	public class Cube : MonoBehaviour {

		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			transform.Rotate(Vector3.right);
	        transform.Rotate(Vector3.up);
		}
	}
}
