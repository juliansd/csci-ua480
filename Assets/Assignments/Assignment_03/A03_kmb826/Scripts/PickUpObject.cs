using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace kmb826_assignment3 {
    public class PickUpObject : MonoBehaviour
    {
        Rigidbody rb; // cube that will be the focus of this program
        [HideInInspector]
        public static bool selected = false; // for purpose of picking up object
        [HideInInspector]
        public static bool move = false; // for purpose of moving object
        [HideInInspector]
        public static bool rotate = false; // for purpose of rotating object
        [HideInInspector]
        public static bool second_click = false; // first click selects object (bool selected), second click activates popup menu
        float last_x, last_z; // In case of issue where collision may not be deteced between cube and plane.
        Vector3 last_position; //Keeps track of last position of cube if cube goes below plane for any reason.

        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        void Update()
        {

            last_x = transform.position.x; // Keep track of x-position in case object goes "out of bounds"
            last_z = transform.position.z; // Keep track of z-position in case object goes "out of bounds"

            if (transform.position.y < 0)
            {
                rb.position = new Vector3(last_x, 0f, last_z);
            }

        }

        // Lift object
        public void LiftObject()
        {
            // if selected is false, pick up cube
            if (!selected)
            {
                transform.parent = Camera.main.transform; // cube position will change with respect to main camera
                rb.useGravity = false; // turn off gravity
                selected = true; // object is selected
            }
            else
            {
                // If the cube is selected, the next click will be to activate the menu to pop up for the user to decided what to do with the cube 
                if (!second_click)
                {
                    second_click = true;
                    transform.parent = null; // camera is no longer parent, cube will stay where it is while menu is up
                }
                else
                {
                    // turn off menu
                    second_click = false;
                    transform.parent = Camera.main.transform;
                }
            }
        }

        //Drop Object
        public void DropObject()
        {
            transform.parent = null;
            rb.useGravity = true;
            selected = false;
            second_click = false;
        }

        //Detects collision between cube and plane
        public void OnCollisionEnter(Collision collision)
        {

            if (collision.transform.tag == "Plane")
            {
                DropObject(); //Drop object if it collides with the plane
            }
        }
    }
}
