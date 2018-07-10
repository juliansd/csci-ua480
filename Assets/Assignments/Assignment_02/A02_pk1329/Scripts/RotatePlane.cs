using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace pk1329A02
{
    public class RotatePlane : MonoBehaviour
    {
        public float speed;
        void Start()
        {

        }

        void Update()
        {
            /* Rotate the plane. Part of my game */
            transform.Rotate(Vector3.up * Time.deltaTime * speed, Space.World);
        }
    }
}