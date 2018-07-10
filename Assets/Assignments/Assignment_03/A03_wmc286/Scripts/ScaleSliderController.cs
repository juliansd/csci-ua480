using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace wmc286
{
    [RequireComponent(typeof(Slider))]
    public class ScaleSliderController : MonoBehaviour
    {
        [HideInInspector]
        public Transform ControllingTransform;

        [Tooltip("The scale will change between 1 - range and 1 + range")]
        [Range(0.1f, 0.9f)]

        private Slider slider;
        private Vector3 initialLocalScale;
        private int translateBy = 1;
        private float previousSliderValue = 0.5f;

        public void Move(float newSliderValue)
        {
            if (newSliderValue > previousSliderValue)
                ControllingTransform.Translate(0, 0, translateBy);

            if (newSliderValue < previousSliderValue)
                ControllingTransform.Translate(0, 0, -translateBy);

            previousSliderValue = newSliderValue;
        }

        private void Start()
        {
            slider = GetComponent<Slider>();
        }

        private void OnEnable()
        {
            if (MenuCanvasController.Instance != null && MenuCanvasController.Instance.ControllingObject != null)
            {
                ControllingTransform = MenuCanvasController.Instance.ControllingObject.transform;
                initialLocalScale = ControllingTransform.localScale;
                slider.value = 0.5f;
            }
        }

        private void OnDisable()
        {
            ControllingTransform = null;
            initialLocalScale = Vector3.one;
        }

    }
}
