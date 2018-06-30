using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace pk1329A03
{
    /***
     * PickupMe component allows user to select this object and 
     * move it with their gaze and/or rotate the object
     ******/
    public class PickupMeAndRotate : MonoBehaviour
    {
        public bool grabbed = false;  // have i been picked up, or not?
        Rigidbody myRb;
        StrobeSelected strobe;
        public DrawDownPointer downPointer;
        public Dropdown dropdown; // This is to get the value from the dropdown menu
        public bool should_rotate = false; // Should the cube rotate or not?
        Vector3 Angle;

        // Use this for initialization
        void Start()
        {
            myRb = GetComponent<Rigidbody>();
            strobe = GetComponent<StrobeSelected>();
        }

        // Update is called once per frame
        void Update()
        {
            if (grabbed && (downPointer != null)) {
                downPointer.DrawLine(transform.position);
            }

            // If the cube should rotate, rotate when the camera moves
            if (should_rotate)
            {


                float difference = Angle.y - Camera.main.transform.rotation.eulerAngles.y;

                // Rotate the cube based off the distance calculated above.
                transform.Rotate(Vector3.up, difference * 5);

                Angle = Camera.main.transform.rotation.eulerAngles;
            }

            // If the cube falls below the plane, reset it to above the plane, and drop the cube.
            if (transform.position.y < 0.45 && grabbed)
            {
                transform.position = new Vector3(transform.position.x, 0.5f, transform.position.z); // Reset the cubes position to right on top of the plane
                transform.parent = null;  // release the object
                grabbed = false;
                myRb.isKinematic = false;  //    .useGravity = true;
                strobe.trigger = false;
                if (downPointer != null)
                    downPointer.DontDraw();
                should_rotate = false; // Set rotate state to false for when the cube was rotating
            }
        }

        /*
         * PickupOrDrop
         * Handle the event when the user clicks the button while 
         * gaze is on this object.  Toggle grabbed state. Toggle rotate state
         * This function also handles whether the cube should be rotated or not.
         */
        public void PickupOrDrop()
        {
            if (dropdown.value == 0 && !grabbed)
            { // Grab the object and make it move with camera
                // make it move with gaze, keeping same distance from camera
                transform.parent = Camera.main.transform;  // attach object to camera
                grabbed = true;
                strobe.trigger = true;   // turn on color strobe so we know we have it
                myRb.isKinematic = true; //  .useGravity = false;

            }
            else if (dropdown.value == 0 && grabbed)
            { // Drop the object
                transform.parent = null;  // release the object
                grabbed = false;
                myRb.isKinematic = false;  //    .useGravity = true;
                strobe.trigger = false;
                if (downPointer != null)
                    downPointer.DontDraw();
            }
            else if (dropdown.value == 1 && !grabbed)
            {  // Grab the object as well as make it rotate.
                transform.parent = Camera.main.transform;  // attach object to camera
                grabbed = true;
                strobe.trigger = true;   // turn on color strobe so we know we have it
                myRb.isKinematic = true; //  .useGravity = false;
                should_rotate = true; // Change rotate state to true
            }
            else
            { // Drop the object and change the rotate state to false.
                transform.parent = null;  // release the object
                grabbed = false;
                myRb.isKinematic = false;  //    .useGravity = true;
                strobe.trigger = false;
                if (downPointer != null)
                    downPointer.DontDraw();
                should_rotate = false; // Change rotate state to false
            }
        }
    }
}
