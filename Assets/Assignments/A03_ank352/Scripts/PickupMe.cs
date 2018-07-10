using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A03_ank352
{
    /***
     * PickupMe component allows user to select this object and
     * move it with their gaze
     ******/
    public class PickupMe : MonoBehaviour
    {
        public static bool grabbed = false;  // have i been picked up, or not?
        Rigidbody myRb;
        StrobeSelected strobe;
        public DrawDownPointer downPointer;

        //Boolean values
        public static bool rotate = false;
        public static bool translate = false;

        public Vector3 _initialPosition1;

        // Use this for initialization
        void Start()
        {
            myRb = GetComponent<Rigidbody>();
            strobe = GetComponent<StrobeSelected>();
            _initialPosition1 = transform.position;
        }

        // Update is called once per frame
        void Update()
        {
            //Part 1: prevents cube from passing through plane (from above)
            if (grabbed && !rotate) {
                Debug.Log("x = " + Camera.main.transform.rotation.x);
                print("x = " + Camera.main.transform.rotation.x);
                print("y = " + Camera.main.transform.rotation.y);

                //For Unity Testing use this if condition
                // if (Camera.main.transform.rotation.x < 0)

                //For GoogleCardboard
                if (Camera.main.transform.rotation.y < -0.05)
                  transform.position = new Vector3(transform.position.x, (float) 0.5, transform.position.z);
                else
                  transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
            }
        }
        /*
         * PickupOrDrop
         * Handle the event when the user clicks the button while
         * gaze is on this object.  Toggle grabbed state.
         */
        public void PickupOrDrop()
        {
            if (grabbed)
            {  // now drop it
                transform.parent = null;  // release the object
                grabbed = false;
                myRb.isKinematic = false;  //    .useGravity = true;
                strobe.trigger = false;
                if (downPointer != null)
                    downPointer.DontDraw();
            }
            else
            {   // pick it up:
              // make it move with gaze, keeping same distance from camera
              transform.parent = Camera.main.transform;  // attach object to camera
              grabbed = true;
              strobe.trigger = true;   // turn on color strobe so we know we have it
              myRb.isKinematic = true; //  .useGravity = false;
            }
        }
    }
}
