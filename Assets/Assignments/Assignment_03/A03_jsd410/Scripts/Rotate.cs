using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jsd410 {

    public class Rotate : MonoBehaviour {

        Rigidbody rb;
        public bool grabbed = false;
        StrobeSelected strobe;
        public DrawDownPointer downPointer;
        float playerCamX;
        float playerCamY;
        float playerCamZ;
        // float x = 1;

    	// Use this for initialization
    	void Start () {
    		rb = GetComponent<Rigidbody>();
            strobe = GetComponent<StrobeSelected>();
    	}
    	
    	// Update is called once per frame
    	void Update () {
    		if (grabbed && (downPointer != null)) {
                downPointer.DrawLine(transform.position);
            }
            if (grabbed) {
                playerCamX = GameObject.Find("Main Camera").transform.rotation.x;
                playerCamY = GameObject.Find("Main Camera").transform.rotation.y;
                playerCamZ = GameObject.Find("Main Camera").transform.rotation.z;
                Vector3 rotate = new Vector3(playerCamX, playerCamY, playerCamZ);
                transform.Rotate(rotate * (Time.deltaTime*1000));
            }
            if (playerCamX > 0.1) {
                grabbed = true;
                RotateCube();
            }
                
    	}

        public void RotateCube() 
        {
            if (grabbed)
            {
                transform.parent = null;
                grabbed = false;
                rb.isKinematic = false;
                strobe.trigger = false;
                if (downPointer != null)
                downPointer.DontDraw();
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
