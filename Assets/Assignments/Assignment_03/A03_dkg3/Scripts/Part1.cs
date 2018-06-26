using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A03dkg3
{
    public class Part1 : MonoBehaviour
    {
        // keeps track of if the cube is picked up
        public bool grabbed = false;
        // create rigidbody and strobe effects
        Rigidbody myRb;
        StrobeSelected strobe;

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
    }
}