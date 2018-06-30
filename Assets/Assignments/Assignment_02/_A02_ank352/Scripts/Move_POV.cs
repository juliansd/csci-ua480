using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01ank352
{
    public class Move_POV : MonoBehaviour
    {
			public float speedH = 5.0f;
	    public float speedV = 5.0f;

	    private float yaw = 0.0f;
	    private float pitch = 0.0f;

	    // Use this for initialization
	    void Start()
	    {
				//Starting position of camera
				transform.Translate(-60, -15, 145);
	    }

	    void Update()
	    {
					//Allows you to move the camera
					//Credit: https://github.com/dagoch/csci-ua480/blob/master/Assets/Assignments/Assignment_02/_A02_Master/Scripts/FirstPersonMove.cs
					float moveX = Input.GetAxis("Horizontal");
					float moveZ = Input.GetAxis("Vertical");
					transform.Translate(moveX, 0, moveZ);

					//Allows you to rotate the camcera
					//Credit: https://gamedev.stackexchange.com/questions/104693/how-to-use-input-getaxismouse-x-y-to-rotate-the-camera
					yaw += speedH * Input.GetAxis("Mouse X");
					pitch -= speedV * Input.GetAxis("Mouse Y");
					transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);
	    }
		}
	}
