using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A03_cew385
{
    public class PickUp : MonoBehaviour
    {
        [HideInInspector]
        public bool masterlock = false;
        public bool grabbed = false;  // have i been picked up, or not?
        Rigidbody myRb;
        //StrobeSelected strobe;
        //public DrawDownPointer downPointer;

        public float distanceFromCam;
        //public Camera cam = Camera.main;
        public Transform cube;
        public bool ready = false;

        //private void Start()
        //{
        //    distanceFromCam = Vector3.Distance(cube.position, Camera.main.transform.position);
        //    myRb = cube.GetComponent<Rigidbody>();
        //}

        //private void Update()
        //{
        //    if(grabbed){
        //        myRb.velocity = Vector3.zero;
        //        //grabbed = false;
        //    }else{
        //        Vector3 pos = Camera.main.transform.position;
        //        pos.z = distanceFromCam;
        //        pos = Camera.main.ScreenToViewportPoint(pos);
        //        myRb.velocity = (pos - cube.position) * 5;
        //        //grabbed = true;
        //    }
        //}
        //public void PickupOrDrop(){
        //    if(grabbed){
        //        grabbed = false;
        //    }else{
        //        grabbed = true;
        //    }
        //}

            // Use this for initialization
            void Start()
            {
                myRb = GetComponent<Rigidbody>();
                //strobe = GetComponent<StrobeSelected>();
            }

            // Update is called once per frame
            void Update()
            {
                //if (grabbed && (downPointer != null))
                //{
                //    downPointer.DrawLine(transform.position);
                //}
                if(masterlock == true){
                    Debug.Log("master lock changed in OG script");
                    PickupOrDrop();
                }

            }
  

            public void OnCollisionEnter(Collision collision)
            {
                Debug.Log("collision occured");
                //myRb.isKinematic = false;
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
                    masterlock = false;
                    //strobe.trigger = false;
                    //if (downPointer != null)
                        //downPointer.DontDraw();
                }
                else
                {   // pick it up:
                    // make it move with gaze, keeping same distance from camera
                    transform.parent = Camera.main.transform;  // attach object to camera
                    grabbed = true;
                    //strobe.trigger = true;   // turn on color strobe so we know we have it
                    myRb.isKinematic = false; //  .useGravity = false;

                }
            }
        }
    }