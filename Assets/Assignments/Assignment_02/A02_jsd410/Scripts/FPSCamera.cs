using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace jsd410 {

    public class FPSCamera : MonoBehaviour {

        public float movementSpeed = 5f;

        public float speedH = 2f;
        public float speedV = 2f;

        public float yaw = 0f;
        public float pitch = 0f;

        // Use this for initialization
        void Start () {
            
        }
        
        // Update is called once per frame
        void Update() {
            if(Input.GetKey(KeyCode.RightArrow))
            {
                transform.Translate(new Vector3(movementSpeed * Time.deltaTime,0,0));
            }
            if(Input.GetKey(KeyCode.LeftArrow))
            {
                transform.Translate(new Vector3(-movementSpeed * Time.deltaTime,0,0));
            }
            if(Input.GetKey(KeyCode.DownArrow))
            {
                transform.Translate(new Vector3(0,0,-movementSpeed * Time.deltaTime));
            }
            if(Input.GetKey(KeyCode.UpArrow))
            {
                transform.Translate(new Vector3(0,0,movementSpeed * Time.deltaTime));
            }

            yaw += speedH * Input.GetAxis("Mouse X");
            pitch -= speedV * Input.GetAxis("Mouse Y");
            transform.eulerAngles = new Vector3(pitch, yaw, 0f);
        }
    }
}
