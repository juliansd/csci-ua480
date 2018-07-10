using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/*
 *  
 */
namespace kmb826_assignment3 {
    public class MenuPopup : MonoBehaviour {

        // Begin by setting all menu buttons off
        void Start() {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        private void Update()
        {
            if (PickUpObject.second_click == true) //Accesses second_click property from PickUpObject.cs if clicked, will render buttons on canvas
                Activate();
            else
                Deactivate();
        }

        // Sets move, transform, and drop buttons to off
        public void Activate()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
               transform.GetChild(i).gameObject.SetActive(true);
            }
            PickUpObject.move = false; // Stop object from moving while menu is up
            PickUpObject.rotate = false; // Stop object from rotating while menu is up

        }

        // Deactivates the menu render
        public void Deactivate ()
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
            PickUpObject.second_click = false;
            
        }
    }
}
