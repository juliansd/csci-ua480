using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace mhp327_Assignment03
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
        private Vector3 savePos = Vector3.zero;

        // Use this for initialization
        void Start()
        {
            myRb = GetComponent<Rigidbody>();
            strobe = GetComponent<StrobeSelected>();
        }

        // Update is called once per frame
        void Update()
        {
            if (grabbed && (downPointer != null))
            {
                downPointer.DrawLine(transform.position);
            }

            if (grabbed)
            {
                //check to see if the position of the cube is below 0.5
                if (transform.position.y < 0.5f)
                {
                    //if so make a temp vector of the position of the transform
                    //and make the y of it 0.5
                    Vector3 temp = transform.position;
                    temp.y = 0.5f;
                    transform.position = temp;


                }
                //otherwise we save the position of the cube to use later
                else if (!Mathf.Approximately(transform.position.y, 0.5f))
                {
   
                    transform.localPosition = savePos;
                }
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
              //  myRb.useGravity = true;
                if (downPointer != null)
                    downPointer.DontDraw();
            }
            else
            {

                // pick it up:
                // make it move with gaze, keeping same distance from camera
                transform.parent = Camera.main.transform;  // attach object to camera
                grabbed = true;
                strobe.trigger = true;   // turn on color strobe so we know we have it
                myRb.useGravity = false;

                //now if the cube is picked up & savePos is the zero vector
                //we set is to be the transform of the cube
                if (savePos == Vector3.zero)
                {
                    savePos = transform.localPosition;
                }
            }
        }

    }
}
