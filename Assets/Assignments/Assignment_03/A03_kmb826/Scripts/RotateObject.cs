using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script to rotate object. Rotate will be executed by head tilt. MoveObject.cs and CameraTilt.cs were both modeled after the
 * demonstration given by Siyuan Qiu in CameraTiltingDetection.cs and PlayerController.cs
 */

namespace kmb826_assignment3
{
    public class RotateObject : MonoBehaviour
    {

        public static RotateObject Singleton; // create Singleton Instance to call in outside classes
        private readonly float speed = 10f; // Speed to rotate cube

        //Ensure that instance is Singleton as demonstrated by Siyuan Qiu
        private void Awake()
        {
            if (Singleton == null)
                Singleton = this;
            else if (Singleton != this)
                Destroy(this);
        }

        //Set rotate boolean to true in PickUpOnject.cs when "Transform" button is selected
        public void Activate()
        {
            PickUpObject.rotate = true;
        }

        //Set rotate boolean to false in PickUpOnject.cs when "Transform" button is selected
        public void Deactivate()
        {
            PickUpObject.rotate = false;
        }

        // Function that will execute rotation based on camera tilt directon information gathered in CameraTilt.cs
        public void Rotate(Vector3 eulers)
        {
            transform.Rotate(eulers * speed);
        }
    }
}
