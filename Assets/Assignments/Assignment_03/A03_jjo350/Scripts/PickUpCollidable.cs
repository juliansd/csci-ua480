using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A03_jjo350 {
	public class PickUpCollidable : MonoBehaviour
    {

        public bool grabbed = false;  // have i been picked up, or not?
        Rigidbody myRb;
        Transform target;
        bool seekTarget = false;
        float counter = 0;
        IEnumerator coroutine;

        // Use this for initialization
        void Start()
        {
            myRb = GetComponent<Rigidbody>();
            GameObject t = new GameObject();
            target = t.transform;
        }

        void Update()
        {
            if (grabbed)
            {
				//just a slight augmentation so that when you actually are not looking at it and click it 
                // lets go
				if (Input.GetMouseButtonDown(0) || (Input.GetTouch(0).phase == TouchPhase.Began))
                {
					coroutine = Seek();
					StartCoroutine(coroutine);
                }
            }
        }



        /// <summary>
        /// as a quality of life thing if you are not looking at an object 
        /// and click it will immediately lurp towards the gaze of the user to ease 
        /// that frustation.  
        /// </summary>
        /// <returns>The seek.</returns>
        IEnumerator Seek()
		{
			counter = 0;
			while (counter < 2f)
			{
				transform.position = Vector3.Lerp(transform.position, target.position, 0.5f);
				counter += Time.deltaTime;
				yield return null;
			}
			Reset();
		}

        private void Reset()
        {
          StopCoroutine(coroutine);
        }

        // this serves to get rid of the "bounce" effect when dragging an object on the floor
        private void OnCollisionEnter(Collision collision)
        {
            myRb.velocity = Vector3.zero;
        }



        public void PickupOrDrop()
        {
            if (grabbed)
            {  // now drop it
                transform.parent = null;  // release the object
                grabbed = false;
                //myRb.isKinematic = false;
                myRb.useGravity = true;
                myRb.freezeRotation = false;

            }
            else
            {   // pick it up:
				// make it move with gaze, keeping same distance from camera
			    Vector3 pos = transform.position - Camera.main.transform.position;
				target.position = Camera.main.transform.forward * pos.magnitude 
					+ Camera.main.transform.position;
                target.parent = Camera.main.transform;  // attach object to camera
                transform.parent = Camera.main.transform;
                grabbed = true;
                //myRb.isKinematic = true; 
                myRb.useGravity = false;
                myRb.freezeRotation = true;
            }
        }

		public void Drop() {
			if (grabbed) {
				transform.parent = null;  // release the object
                grabbed = false;
                //myRb.isKinematic = false;
                myRb.useGravity = true;
                myRb.freezeRotation = false;
			}         
		}

    }

}
