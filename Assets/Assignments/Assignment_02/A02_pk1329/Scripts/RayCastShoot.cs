using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace pk1329A02
{
    public class RayCastShoot : MonoBehaviour
    {

        /* Initialize Variables */
        public float laserRange = 50f;
        public Transform cubeEnd;

        private Camera fpsCam;
        private LineRenderer laserLine;


        void Start()
        {
            /* Get Components */
            laserLine = GetComponent<LineRenderer>();
            fpsCam = GetComponentInParent<Camera>();

        }

        /* Credits: Got most of this code by going through 
         * Unity's Shooting a Laser Tutorial */

        void Update()
        {
            /* When Mouse Button is Clicked */
            if (Input.GetButtonDown("Fire1"))
            {

                StartCoroutine(ShotEffect());

                Vector3 laserOrigin = fpsCam.ViewportToWorldPoint(new Vector3(0.5f, 0.5f, 0));
                RaycastHit hit;

                laserLine.SetPosition(0, cubeEnd.position);

                /* Handle when a Pole is hit */
                if (Physics.Raycast(laserOrigin, fpsCam.transform.forward, out hit, laserRange))
                {
                    laserLine.SetPosition(1, hit.point);

                    ShootablePole lives = hit.collider.GetComponent<ShootablePole>();

                    if (lives != null)
                    {
                        lives.Damage();
                    }
                }
                else
                {
                    laserLine.SetPosition(1, laserOrigin + (fpsCam.transform.forward * laserRange));
                }
            }
        }

        private IEnumerator ShotEffect()
        {
            /* Show then hide the laser */
            laserLine.enabled = true;
            yield return 1.0f;
            laserLine.enabled = false;
        }
    }
}