using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/* Script to keep track of head tilt. Move will be executed by head tilt. MoveObject.cs and CameraTilt.cs were both modeled after the
 * demonstration given by Siyuan Qiu in CameraTiltingDetection.cs and PlayerController.cs
 */

namespace kmb826_assignment3
{
    public class CameraTilt : MonoBehaviour
    {
        private static readonly float tiltMax = 10f; // maximum desired angle of head tilt
        private static readonly float threshold_magnitude = Mathf.Sin(tiltMax * Mathf.Deg2Rad); // create a threshold to compare the new position magnitude to


        void LateUpdate()
        {

            Vector3 pos = transform.up; // position of head tilt
            pos.y = 0f; // keep a constant y
            if (pos.magnitude > threshold_magnitude && PickUpObject.move)
            {
                MoveObject.Singleton.Move(pos * 10f); //move the object
            }
            else if (pos.magnitude > threshold_magnitude && PickUpObject.rotate)
                RotateObject.Singleton.Rotate(pos); // rotate the object
        }
    }
}
