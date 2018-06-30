using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace A01ank352
{
	public class MoveTargets: MonoBehaviour
	{
		public GameObject pocket;
		public GameObject cueball;

		void Start ()
		{
		}

		void Update ()
		{
			//If the cueball reaches the target balls...
			if (cueball.transform.position.z >= -0.75) {
				//Make the target balls move toward their respective corner pockets
				//The following two lines were repurposed from csci-ua480/Assets/Assignments/Assignment_01/_A01_Master/Scripts/LookAtMoveToward.cs
				transform.LookAt(pocket.transform.position);
				transform.position = Vector3.MoveTowards(transform.position, pocket.transform.position, 20 * Time.deltaTime);
			}
		}
	}
}
