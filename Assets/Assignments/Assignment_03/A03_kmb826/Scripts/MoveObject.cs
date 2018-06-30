using System.Collections;
using System.Collections.Generic;
using UnityEngine;


/* Script to move object. Move will be executed by head tilt. MoveObject.cs and CameraTilt.cs were both modeled after the
 * demonstration given by Siyuan Qiu in CameraTiltingDetection.cs and PlayerController.cs
 */
namespace kmb826_assignment3
{
    public class MoveObject : MonoBehaviour
    {
        public float speed = 5.0f; // Speed property to move cube

        // Methods to be accessed as Singleton
        public static MoveObject Singleton;

        private void Awake()
        {
            if (Singleton == null)
            {
                Singleton = this;
            }
            else if(Singleton != this)
            {
                Destroy(this);
            }
        }

        //Called when move button is selected to set bool move to true in PickUpObject.cs
        //This will allow us to move the object when selected without any issue
        public void ActivateMove()
        {
            PickUpObject.move = true;
        }

        //Deactivate move property
        public void DeactivateMove()
        {
            PickUpObject.move = false;
        }
        
        //Called when ready to move object in CameraTilt.cs
        public void Move(Vector3 position)
        {
            // if "Move" button has been selected we will move object using head tilt
            if (PickUpObject.move)
                transform.Translate(transform.InverseTransformDirection(position*speed));

        }
    }
}
