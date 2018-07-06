using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* This code was developed from the help of a tutorial on creating randomly generated mazes
* from scratch in unity.
* https://catlikecoding.com/unity/tutorials/maze/
**/


namespace jsd410 {

    // This class is used for the main movement of the player.
    // If the player is looking at the floor, they will accelerate while
    // holding down button and decelerate if they let go.
    // If the player looks at a wall in the maze they will teleport.

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
            // Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hit, float.PositiveInfinity)) {
                GameObject mazeCell = hit.collider.gameObject;
                if(mazeCell.tag == "MazeCell" || mazeCell.tag == "MazeWall") {
                    if (hit.distance >= 2f) {
                        transform.position = hit.point;
                    }
                    else {
                        EasingMovement();
                        if (speed < topSpeed) {
                            speed += 0.1f;
                        }
                    }
                }
                // if (mazeCell.tag == "MazeWall") {
                //     transform.position = hit.point;
                // }
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
