using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace A03_ank352
{
    [RequireComponent(typeof(Slider))]
    public class ScaleSliderController : MonoBehaviour
    {
      // [HideInInspector]
      public Transform ControllingTransform;


      [Tooltip("The scale will change between 1 - range and 1 + range")]
      [Range(0.1f, 0.9f)]
      public float ScaleChangeRange = 0.5f;

      private Slider _slider;
      private Vector3 _initialLocalScale;
      public Vector3 _initialPosition;

      //Part 3: Change distance of object relative to camera
      public void ChangeObjectDistancea() {
        ControllingTransform.position = _initialPosition + Mathf.Lerp(-5, 5, _slider.value) * Camera.main.transform.forward;
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
                  _initialPosition = ControllingTransform.position; //Set initial position of cube
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
