using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01ank352
{
	public class Celebrate : MonoBehaviour
	{
		public GameObject pocket;
		public GameObject target;
		public GameObject table;

		void Start ()
		{
		}

		void Update ()
		{
			//If the target balls reach the pocket...
			if (target.transform.position.z >= 9.6)
			{
				//Do a partial celebratory rotation (as is acceptable for such a small accomplishment)
				table.transform.Rotate(0, Time.deltaTime * 5, 0, Space.World);
			}
		}
	}

}
