using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jsd410 {

    public class AccelerationDeceleration : MonoBehaviour {

        private float currentSpeed = 0f;
        public float maxSpeed;
        bool mouseDown;
    	// Use this for initialization
    	void Start () {
    		
    	}
    	
    	// Update is called once per frame
    	void Update () {
            if (Input.GetMouseButton(0)) {
                if (currentSpeed < maxSpeed) {
        		  transform.position = (new Vector3(0, 1.5f, currentSpeed * Time.deltaTime));
                  currentSpeed += 0.1f;
                } else {
                    transform.position = (new Vector3(0, 1.5f, maxSpeed * Time.deltaTime));
                }
            }
    	}
    }
}
