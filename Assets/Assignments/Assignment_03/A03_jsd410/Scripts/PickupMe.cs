using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jsd410
{
    /***
     * PickupMe component allows user to select this object and 
     * move it with their gaze
     ******/
    public class PickupMe : MonoBehaviour
    {
        public bool grabbed = false;  // have i been picked up, or not?
        Rigidbody myRb;
        StrobeSelected strobe;
        public DrawDownPointer downPointer;

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

            Vector3 c = GameObject.Find("Cube").transform.position;
            float playerCamX = GameObject.Find("Main Camera").transform.rotation.x;
            if (c.y < 0.5) {
                transform.position = new Vector3(c.x, 0.5f, c.z);
            }
            if (playerCamX > 0.1) {
                grabbed = true;
                PickupOrDrop();
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
