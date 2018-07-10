using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace wmc286
{
    public class MoveToWhereClicked : MonoBehaviour
    {
        public void Move(GameObject pointTo)
        {
            pointTo.transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z);
        }
    }
}