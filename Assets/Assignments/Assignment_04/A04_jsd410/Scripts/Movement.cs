using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jsd410 {

    public class Movement : MonoBehaviour {

        public float topSpeed;
        private float speed = 0;

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
                GameObject mazeCell = hit.collider.gameObject;
                print(mazeCell.name);
                if(mazeCell.tag == "MazeCell") {
                    if (hit.distance >= 5) {
                        transform.position = hit.point;
                    }
                    else {
                        EasingMovement();
                        if (speed < topSpeed) {
                            speed += 0.1f;
                        }
                    }
                }
                if (mazeCell.tag == "MazeWall") {
                    transform.position = hit.point;
                }
                if (transform.position.y < 2.25f) {
                    transform.position = new Vector3(transform.position.x, 2.25f, transform.position.z);
                }
            }
        }

        void EasingMovement() {
            if (Camera.main.transform.position.y < 2.25f) {
                transform.position = new Vector3(transform.position.x, 2.25f, transform.position.z);
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
            if (transform.position.y < 2.25f)
                transform.position = new Vector3(transform.position.x, 2.25f, transform.position.z);
        }
    }
}
