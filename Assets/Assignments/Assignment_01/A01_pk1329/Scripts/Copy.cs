using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace pk1329A01
{
    public class Copy: MonoBehaviour
    {
        public float speed;
        public GameObject target;

        List<Vector3> PreviousPositions;
        List<GameObject> cylinders;

        public int amount;
        public GameObject cylinder;
        public Transform parent;
        // Use this for initialization
        void Start()
        {
            for (int i = 0; i < amount; i++) {
                Instantiate(cylinder, new Vector3((i * 2.0F) + 2, 5, 0), Quaternion.identity, parent);
            }
        }

        // Update is called once per frame
        void Update()
        {
            transform.Rotate(Vector3.back * (speed * Time.deltaTime));
        }
    }
}
