using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


namespace pk1329A01
{
    public class MoveText: MonoBehaviour
    {

        public float speed;
        // Use this for initialization

        void Start()
        {
        }

        // Update is called once per frame
        void Update()
        {
            Vector3 pos = transform.position;
            //calculate what the new Y position will be
            float newY = 15 * Mathf.Sin(Time.time * speed);
            //set the object's Y to the new calculated Y
            transform.position = new Vector3(pos.x, newY, pos.z);
        }
    }
}
