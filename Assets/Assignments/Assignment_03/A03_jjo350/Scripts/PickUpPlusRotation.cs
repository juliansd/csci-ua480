using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A03_jjo350 {
	public class PickUpPlusRotation : MonoBehaviour
    {
		bool grabbed = false;
		Vector3 prevAngle;
		Rigidbody myRb;

		private void Start()
		{
			myRb = this.GetComponent<Rigidbody>();
		}

		private void Update()
		{
			if (grabbed) {
				Vector3 curAngles = Camera.main.transform.rotation.eulerAngles;
				transform.Rotate((curAngles - prevAngle) * (float)2.5f);
				prevAngle = curAngles;
				if (Input.GetMouseButtonDown(0) || (Input.GetTouch(0).phase == TouchPhase.Began))
                {
                    PickToRotate();
                }
			}

		}
        
		public  void PickToRotate() {
			if (grabbed) {
				grabbed = false;
				myRb.isKinematic = false;
                
			} else {
				grabbed = true;
				prevAngle = Camera.main.transform.rotation.eulerAngles;
				myRb.isKinematic = true;
			}
		}
    }
}

