using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wmc286
{
    public class PickupMe : MonoBehaviour
    {
        Rigidbody rb;
        StrobeSelected strobe;

        public bool grabbed = false;
        public bool rotate = false;
        public DrawDownPointer downPointer;
        private Vector3 cubeLastPosition;
        private float stopY = 0.54f;

        void Start()
        {
            rb = GetComponent<Rigidbody>();
            strobe = GetComponent<StrobeSelected>();
            cubeLastPosition = transform.position;
        }

        void Update()
        {
            if (grabbed)
                if (transform.parent.position.y < 1.58f)
                    transform.position = new Vector3(transform.position.x, stopY, transform.position.z);

            if (rotate)
            {
                float offset = transform.position.x - cubeLastPosition.x;
                cubeLastPosition = transform.position;
                transform.Rotate(0, offset * 30, 0);
            }

        }

        public void PickupOrDrop()
        {
            if (grabbed)
            {
                transform.parent = null;
                grabbed = false;
                rb.isKinematic = false;
                strobe.trigger = false;
                if (downPointer != null)
                    downPointer.DontDraw();
                rotate = false;
            }
            else
            {
                transform.parent = Camera.main.transform;
                grabbed = true;
                strobe.trigger = true;
                rb.isKinematic = true;
            }
        }

        public void RotateCube()
        {
            rotate = true;
        }
    }
}
