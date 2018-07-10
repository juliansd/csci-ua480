using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace lga238{
	public class roll : MonoBehaviour {

		public Rigidbody rb;
		public bool d = true;
		// Use this for initialization
		void Start () {
			Debug.Log(transform.position.z);
		}
		
		// Update is called once per frame
		void Update () {
			//if(transform.position)
			if(d){
				rb.AddForce(0, 0, 500 * Time.deltaTime);
			}
			if(!d){
				rb.AddForce(0, 0, -500 * Time.deltaTime);
			}

			if(transform.position.z < -30){
				d = true;
			}

			if(transform.position.z > 150){
				d = false;
			}



			Debug.Log(transform.position);



		}
	}
}