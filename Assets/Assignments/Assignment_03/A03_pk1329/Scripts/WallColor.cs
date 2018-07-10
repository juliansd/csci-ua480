using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace pk1329A03
{
    /***
    * CubeDistance
    * Implements basic timer selection of object.
    * ***/
    public class WallColor : MonoBehaviour
    {
        int counter = 0; // Counter to select which color to display
        MeshRenderer meshRenderer;

        private float nextActionTime = 0.0f; // variable to limit update to every second.
        public float period = 1f; // variable to limit update to every second.

        void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();

        }

        public void Update()
        {

            // Run every second
            if (Time.time > nextActionTime)
            {
                nextActionTime += period;

                // Based on counter value, display a corresponding color
                switch(counter)
                {
                    case 0:
                        meshRenderer.material.color = Color.green;
                        counter++;
                        break;
                    case 1:
                        meshRenderer.material.color = Color.gray;
                        counter++;
                        break;
                    case 2:
                        meshRenderer.material.color = Color.black;
                        counter++;
                        break;
                    case 3:
                        meshRenderer.material.color = Color.blue;
                        counter++;
                        break;
                    case 4:
                        meshRenderer.material.color = Color.white;
                        counter++;
                        break;
                    case 5:
                        meshRenderer.material.color = Color.yellow;
                        counter++;
                        break;
                }
            }

            // Reset counter
            if (counter == 6)
            {
                counter = 0;
            }
        }
	}
}
