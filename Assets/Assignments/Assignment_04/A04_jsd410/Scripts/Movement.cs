using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jsd410 {

    public class Movement : MonoBehaviour {

        public float topSpeed;
        private float speed = 0;
        // private bool isMoving;

        void Update() {
            if (Input.GetMouseButton(0)) {
                Teleport();
            }
            if (speed > 0) {
                Decelerate();
            }
        }

        void Teleport() {
            RaycastHit hit;
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray.origin, ray.direction, out hit, float.PositiveInfinity)) {
                GameObject plane = hit.collider.gameObject;
                if(plane.tag == "Plane") {
                    if (hit.distance >= 5) {
                        print("ok");
                        transform.position = hit.point;
                    }
                    else {
                        EasingMovement();
                        if (speed < topSpeed) {
                            speed += 0.1f;
                        }
                    }
                }
                if (transform.position.y < 0.5) {
                    transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
                }
            }
        }

        void EasingMovement() {
            if (Camera.main.transform.position.y < 0.5f) {
                transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
            }
            if (speed < topSpeed) {
                transform.Translate(Camera.main.transform.forward * speed * Time.deltaTime);
                speed += 0.1f;
            } else {
                transform.Translate(Camera.main.transform.forward * topSpeed * Time.deltaTime);
            }
        }

        void Decelerate() {
            transform.Translate(Camera.main.transform.forward * speed * Time.deltaTime);
            speed -= 0.1f;
            if (transform.position.y < 1f)
                transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        }
    }
}
