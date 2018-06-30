using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace lga238
{
    [RequireComponent(typeof(Slider))]
    public class CustomScaleSliderController : MonoBehaviour
    {
        [HideInInspector]
        public Transform ControllingTransform;

        [Tooltip("The scale will change between 1 - range and 1 + range")]
        [Range(0.1f, 0.9f)]
        public float ScaleChangeRange = 0.5f;

        private Slider _slider;
        private Vector3 _initialLocalScale;
        private Vector3 initialPosition;

        private Quaternion initialRotation;


        public void ChangeObject () {
            if (ControllingTransform != null)
                if(InputControllerScript.Instance.cubeMode == InputMode.Scale)
                {
                    ControllingTransform.localScale = _initialLocalScale * Mathf.Lerp(1.0f - ScaleChangeRange, 1.0f + ScaleChangeRange, _slider.value);
                }

                if(InputControllerScript.Instance.cubeMode == InputMode.Translate){
                    ControllingTransform.localPosition = initialPosition * Mathf.Lerp(1.0f - ScaleChangeRange, 1.0f + ScaleChangeRange, _slider.value);


                }

                if(InputControllerScript.Instance.cubeMode == InputMode.Rotate){
                   // ControllingTransform.localRotation = initialRotation * Quaternion.Slerp(1.0f-ScaleChangeRange, 1.0f + ScaleChangeRange, _slider.value);
                    ControllingTransform.localRotation = Quaternion.Euler(0,_slider.value*360, 0);
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
                initialPosition = ControllingTransform.localPosition;
                initialRotation = ControllingTransform.localRotation;
                _slider.value = 0.5f;
            }
        }

        private void OnDisable()
        {
            ControllingTransform = null;
            _initialLocalScale = Vector3.one;
        }

    }
}
