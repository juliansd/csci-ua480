using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A03dkg3
{
    public class Part2 : MonoBehaviour
    {
        // keeps track of if the cube is picked up
        public bool grabbed = false;
        // create rigidbody and strobe effects
        Rigidbody myRb;
        StrobeSelected strobe;
        // mode to know if it is translation or rotation
        public bool mode = false;

        // Use this for initialization
        void Start()
        {
            // get the rigidbody and strobe selected components from the start
            myRb = GetComponent<Rigidbody>();
            strobe = GetComponent<StrobeSelected>();
        }

        // Update is called once per frame
        void Update()
        {
            // check if the cube is picked up
            if (grabbed)
            {
                // prevent the cube from falling through the plane (this value
                // is the camera's position at the plane)
                if (transform.parent.position.y < 1.594f)
                {
                    // allow it to continue to move along the x and z axis but keep
                    // the y position of the cube fixed on the plane
                    transform.position = new Vector3(transform.position.x, .5f, transform.position.z);
                }
                // otherwise the cube is above the plane and can move freely along all axes
                else
                {
                    transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
                }
                // rotate the cube if the rotation mode is selected instead of the translation mode
                // amplify the speed of the rotations so the user can spin the cube a full 360 degrees without
                // to much strain
                if (mode)
                {
                    transform.Rotate(0, Input.GetAxis("Mouse X") * 30, 0);
                }
            }
        }

        /*
         * PickupOrDrop
         * Handle the event when the user clicks the button while 
         * gaze is on this object. Toggle grabbed state.
         */
        public void PickupOrDrop()
        {
            if (grabbed)
            {
                // now drop it
                // release the object
                transform.parent = null;
                // state that it's no longer grabbed
                grabbed = false;
                // turn gravity back on
                myRb.isKinematic = false;
                // stop the stobe effects
                strobe.trigger = false;
            }
            else
            {
                // pick it up
                // make it move with gaze, keeping same distance from camera
                // attach the object to camera
                transform.parent = Camera.main.transform;
                // state that the object is grabbed
                grabbed = true;
                // turn on the strobe effects to know we have the cube
                strobe.trigger = true;
                // turn off gravity
                myRb.isKinematic = true;
            }
        }

        // sets the mode to translate when the translation button is pushed
        public void Translate()
        {
            mode = false;
        }

        // sets the mode to rotate when the rotation button is pushed
        public void Rotate()
        {
            mode = true;
        }
    }
}