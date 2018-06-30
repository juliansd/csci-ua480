using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace pk1329A02
{
    public class ChangeFloorColor : MonoBehaviour
    {

        /* Initialize Variables */
        public Camera fpsCam;
        public GameObject targetPoint;
        Renderer rend;
        public int count = 0;

        void Start()
        {
            /* Create Renderer Component for TargetPoint = Ground */
            rend = targetPoint.GetComponent<Renderer>();
        }

        void Update()
        {


            /* IN ORDER TO CHANGE THE COLOR OF THE FLOOR, THE PLAYER MUST BE IN THE
             * MIDDLE OF THE PLANE, THEN PRESS X */

            /* Calculate the Vector3 Distance between the player and the ground */
            float dist = Vector3.Distance(fpsCam.transform.position, targetPoint.transform.position);

            /* If the target and player are close, allow the player to change the ground color with the key X */
            if (dist <= 2.5f)
            {
                if (Input.GetKeyDown(KeyCode.X))
                {
                    if (count % 2 == 0)
                    {
                        rend.material.SetColor("_Color", Color.black);
                        count = count + 1;
                    }
                    else
                    {
                        rend.material.SetColor("_Color", Color.white);
                        count = count + 1;
                    }
                }
            }
        }
    }
}
