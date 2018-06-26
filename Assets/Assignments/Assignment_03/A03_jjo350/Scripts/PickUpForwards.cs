using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace A03_jjo350
{
	public class PickUpForwards : MonoBehaviour
	{
		bool grabbed = false;
		public Slider slider;
		public Canvas canvas;
		public float range = 10.0f;
		Vector3 dir;
		Vector3 nearPos;
		Vector3 farPos;

		private void Start()
		{
			dir = Camera.main.transform.position - transform.position;
			dir /= dir.magnitude;

			nearPos = transform.position - dir * (range / 2);
			farPos = transform.position + dir * (range / 2);
		}

		// Update is called once per frame
		void Update()
		{
			if (grabbed) {
				float percent = slider.value;
				transform.position = nearPos + dir * percent * range;
			}


		}

		public void moveForwards() {
			if (grabbed) {
				grabbed = false;
				slider.gameObject.SetActive(false);
				canvas.gameObject.SetActive(false);
			} else {
				grabbed = true;
				slider.value = 0.50f;
				slider.gameObject.SetActive(true);
				canvas.gameObject.SetActive(true);
				dir = Camera.main.transform.position - transform.position;
                dir /=  - dir.magnitude;

                nearPos = transform.position - dir * (range / 2);
                farPos = transform.position + dir * (range / 2);
			}
		}

	}

}