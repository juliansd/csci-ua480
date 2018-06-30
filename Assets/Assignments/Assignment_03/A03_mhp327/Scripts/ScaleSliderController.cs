using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace mhp327_Assignment03
{
    [RequireComponent(typeof(Slider))]
    public class ScaleSliderController : MonoBehaviour
    {
        [HideInInspector]
        public Transform ControllingTransform;

        [Tooltip("The scale will change between 1 - range and 1 + range")]
        [Range(0.0f, 10.0f)]
        public float ScaleChangeRange = 100.0f;

        private Slider _slider;
        private Vector3 _initialLocalScale;

        public void ChangeObjectSize () {
            if (ControllingTransform != null)
            {
                //
                ControllingTransform.rotation = Quaternion.Euler (0f, _slider.value * 500.0f, 0f);


            }
        }

		private void Start()
		{
            _slider = GetComponent<Slider>();
		}

		private void OnEnable()
        {
            if (MenuCanvasController.Instance != null && MenuCanvasController.Instance.ControllingObject != null)
            {
                ControllingTransform = MenuCanvasController.Instance.ControllingObject.transform;
                _initialLocalScale = ControllingTransform.localScale;
                _slider.value = 50.0f;
            }
        }

        private void OnDisable()
        {
            ControllingTransform = null;
            _initialLocalScale = Vector3.one;
        }

    }
}
