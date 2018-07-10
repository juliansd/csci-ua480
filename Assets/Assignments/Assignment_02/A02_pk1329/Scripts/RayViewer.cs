using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pk1329A02
{
    public class RayViewer : MonoBehaviour
    {

        /* Initialize Variables */
        public float laserRange = 50f;

        private Camera fpsCam;


        void Start()
        {
            /* Get Components */
            fpsCam = GetComponentInParent<Camera>();

        }

        /* Credits: Got most of this code by going through 
         * Unity's Shooting a Laser Tutorial */
        void Update()
        {
            /* Draw the green laser in scene *only for debug* */
            Vector3 lineOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
            Debug.DrawRay(lineOrigin, fpsCam.transform.forward * laserRange, Color.green);
        }
    }    
}

