using System.Collections;
using System.Collections.Generic;
using UnityEngine;


namespace pk1329A01
{
    public class Roll : MonoBehaviour
    {
        public float speed;
        public float speed1;
        public Vector3 direction;
        // Use this for initialization
        void Start()
        {

        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(direction * (speed * Time.deltaTime));
            transform.position += new Vector3(speed1, 0, 0);
        }
    }
}
