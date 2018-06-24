using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jsd410 {

    public class PushPull : MonoBehaviour {
        float playerCamX;
        bool grabbed = false;
        Rigidbody rb;
        StrobeSelected strobe;
    	// Use this for initialization
    	void Start () {
    		rb = GameObject.Find("Cube").GetComponent<Rigidbody>();
            strobe = GameObject.Find("Cube").GetComponent<StrobeSelected>();
    	}
    	
    	// Update is called once per frame
    	void Update () {
            if (grabbed) {
                playerCamX = GameObject.Find("Main Camera").transform.rotation.x;
                if (playerCamX < 0)
                    transform.Translate(Vector3.forward * Time.deltaTime * 5);
                else
                    transform.Translate(Vector3.back * Time.deltaTime * 5);
            }
    	}

        public void PushPullCube(float playerCamX) 
        {
            if (grabbed)
            {
                transform.parent = null;
                grabbed = false;
                rb.isKinematic = false;
                strobe.trigger = false;
            }
            else
            {
                // transform.Rotate(Vector3.right * Time.deltaTime);
                grabbed = true;
                strobe.trigger = true;   // turn on color strobe so we know we have it
                rb.isKinematic = true; //  .useGravity = false;
            }
        }
    }
}
