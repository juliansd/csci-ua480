using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace lga238 {
	public class revolve : MonoBehaviour {

		public float Rev = 100.0f;
		// Use this for initialization
		void Start () {
			
		}
		
		// Update is called once per frame
		void Update () {
			transform.Rotate(Vector3.up, Time.deltaTime * Rev);
			
		}
	}
}
