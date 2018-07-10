using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01ank352
{
	public class MoveCue : MonoBehaviour
	{
		public float speed = 20;

		void Start ()
		{
		}

		void Update ()
		{
			//Move the cueball
			transform.Translate(0, 0, 20 * Time.deltaTime);

			//If the cueball reaches the target balls...
			if (transform.localPosition.z >= -0.75)
			{
				//Keep the cueball in place
				transform.localPosition = new Vector3(0, 0.5f, -0.75f);
			}
		}
	}
}
