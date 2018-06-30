using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace lga238 {
	public class colChange : MonoBehaviour {

		public Renderer col;

		void Start () {
			Renderer col = GetComponent<Renderer>();
		}
		
		// Update is called once per frame
		void Update () {
			if(Time.frameCount % 60 == 0){
				col.material.color = new Color(Random.Range(0f,1f), Random.Range(0f,1f), Random.Range(0f,1f));
			}
		}
	}
}
