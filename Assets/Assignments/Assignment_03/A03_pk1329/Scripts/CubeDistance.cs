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
    public class CubeDistance : MonoBehaviour
    {
        Rigidbody myRb;
        public Color selectColor = Color.red; // will fade to this color as time elapses
        public float popTime = 1.0f;  // timer duration

        Color initialColor;
        float counter = 0;
        MeshRenderer meshRenderer;
        IEnumerator coroutine;
        public Dropdown dropdown;

        void Start()
        {
            meshRenderer = GetComponent<MeshRenderer>();
            initialColor = meshRenderer.material.color;
            myRb = GetComponent<Rigidbody>();

        }

        /***
         * ChangeDistance
         * triggered when gaze intersects with collider
         * **/
        public void ChangeDistance()
        {
            // Only run this when the dropdown menu is at Distance option.
            if (dropdown.value == 2)
            {
                coroutine = Gaze();
                StartCoroutine(coroutine);
            }
        }

		/***
		 * Gaze
		 * Coroutine, fades color towards selectColor until popTime has elapsed
		 * Then changes cube distance.
		 * **/
		IEnumerator Gaze(){
            counter = 0;
            while (counter < popTime)
            {
                Debug.Log("hi");
                counter += Time.deltaTime;
                meshRenderer.material.color = Color.Lerp(initialColor, selectColor, counter / popTime);
                yield return null;
            }

            // Do different things when cube gets past a certain distance
            if (transform.position.z >= 3)
            {
                // If cube gets too far, reset the distance to its initial depth
                transform.position = new Vector3(transform.position.x, transform.position.y, 0);
            }
            else 
            {
                // Push back the cube to a further distance
                transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + 1);
            }
            Reset();
        }

        /***
         * Reset
         * Called when gaze stops intersecting collider
         * Resets color and stops timer coroutine
         * **/
		public void Reset()
		{
            StopCoroutine(coroutine);
            meshRenderer.material.color = initialColor;
            counter = 0;
		}
	}
}
