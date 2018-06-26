using System.Collections;
using System.Collections.Generic;
using UnityEngine;
namespace A03_cew385
{
    public class PushPull : MonoBehaviour
    {
        public bool grabbed = false;  // have i been picked up, or not?
        Rigidbody myRb;
        private bool ready = false;
        private bool go = false;
        // Use this for initialization
        void Start()
        {
            myRb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {
            if (ready) { PushnPull(); }
        }

        /*
         * PickupOrDrop
         * Handle the event when the user clicks the button while 
         * gaze is on this object.  Toggle grabbed state.
         */
        public void PushnPull(){
            if (go)
            {  // now drop it
                transform.parent = null;  // release the object
                grabbed = false;
                myRb.isKinematic = true;  //    .useGravity = true;

            }
            else
            {   // pick it up:
                // make it move with gaze, keeping same distance from camera
                //transform.parent = Camera.main.transform;  // attach object to camera
                this.transform.Translate(0, 0, Camera.main.transform.rotation.x);
                //transform.position = new Vector3(Camera.main.transform.rotation.x * 10, 0, 0);
                //transform.position = transform.position * Mathf.Lerp(transform.position.x, Camera.main.transform.rotation.x * 10, Time.deltaTime );
                grabbed = true;
                myRb.isKinematic = true; //  .useGravity = false;

            }
        }

        public void PickupOrDrop()
        {
            if(!grabbed){
                go = false;
                grabbed = false;
            }else{
                go = true;
                grabbed = true;
            }
        }
        private void OnEnable()
        {
            ready = true;
        }
    }
}