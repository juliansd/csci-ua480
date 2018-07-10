using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pk1329A02
{
    public class PlayerController : MonoBehaviour
    {

        public float speed;
        public Rigidbody rb;

        // Use this for initialization
        void Start()
        {
            rb = GetComponent<Rigidbody>();
        }

        // Update is called once per frame
        void Update()
        {

        }

        private void FixedUpdate()
        {
            float moveHorizontal = Input.GetAxis("Horizontal");
            float moveVertical = Input.GetAxis("Vertical");

            Vector3 movement = new Vector3(moveHorizontal, 0, moveVertical);

            rb.AddForce(movement * speed);
        }
    }
}
