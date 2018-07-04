using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jsd410 {

    public class Movement : MonoBehaviour {

        private float timeButtonIsPressed = 0;
        public float topSpeed;

        void Update() {
            if (Input.GetMouseButtonDown(0)) {

                // Does Teleport
                if (timeButtonIsPressed < 0.1) {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray.origin, ray.direction, out hit, float.PositiveInfinity)) {
                        GameObject plane = hit.collider.gameObject;
                        if(plane.tag == "Plane") {
                            transform.position = hit.point;
                        }
                        if (transform.position.y < 0.5) {
                            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
                        }
                    }
                } else {
                    RaycastHit hit;
                    Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
                    if (Physics.Raycast(ray.origin, ray.direction, out hit, float.PositiveInfinity)) {
                        GameObject plane = hit.collider.gameObject;
                        if(plane.tag == "Plane") {
                            transform.position = hit.point;
                        }
                        if (transform.position.y < 0.5) {
                            transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z);
                        }
                    }
                }
            }
            timeButtonIsPressed = 0;
        }
        
    }
}
