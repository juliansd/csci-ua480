using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace mhp327_Assignment03
{
    [RequireComponent(typeof(Slider))]
    public class ScaleSliderForward : MonoBehaviour
    {
        [HideInInspector]
        public Transform ControllingTransform;

        [Tooltip("The scale will change between 1 - range and 1 + range")]
        [Range(-2.0f, 2.0f)]
        public float ScaleChangeRange = 2.0f;

        private Slider _slider;
        private Vector3 _initialLocalScale;

        public Transform camera;

        public void ChangeObjectSize()
        {
            if (ControllingTransform != null)
            {

               //temp is the vector from the player to the cube
                Vector3 temp = ControllingTransform.position - camera.position;

                Vector3 newTemp;
                //new temp is the unit vector of the temp vector
                newTemp = temp / (temp.magnitude);

                // then add the newTemp direction vector to the transorm position of the cube
                ControllingTransform.position += newTemp * _slider.value * 0.25f;

                //keep the slider at 0 to act as a divider rather than an object to slide
                _slider.value = 0;

               
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
                _slider.value = 0.00f;
            }
        }

        private void OnDisable()
        {
            ControllingTransform = null;
            _initialLocalScale = Vector3.one;
        }

    }
}
