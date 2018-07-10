using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 * In order to make sure that the buttons are exactly where they need to be no matter the transform of the cube, this
 * script will maintain a constant up and down orientation of the menu buttons. Also they will always appear right 
 * above the cube when needed
 */ 
namespace kmb826_assignment3
{
    public class LookAt : MonoBehaviour
    {
        public Transform front; //cube

        private void Start()
        {
            transform.position = new Vector3(front.position.x, front.position.y + 1f, front.position.z); // Set beginning position of canvas to be at nearly the same location as the cube
            transform.LookAt(Camera.main.transform); // Keep the buttons facing the camera
        }

        // Update will ensure that buttons are always facing the camera, and that the convas remains oriented to the cube
        void Update()
        {
            transform.position = new Vector3(front.position.x, front.position.y + 1f, front.position.z);
            transform.LookAt(Camera.main.transform);
        }
    }
}
