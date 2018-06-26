using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
namespace A03_cew385
{
    public class ModeController : MonoBehaviour
    {
        [HideInInspector]
        public Transform ControllingTransform;

        [Tooltip("The scale will change between 1 - range and 1 + range")]
        [Range(0.1f, 0.9f)]
        public float ScaleChangeRange = 0.5f;

        private Slider slider;
        private Vector3 initialRot;
        float yRot;
        bool ready = false;
        Vector3 oldPos;
        Vector3 newPos;
        //GameObject grabButton;

        public PickUp set;


        public bool grabbed = false;  // have i been picked up, or not?
        Rigidbody myRb;

        PickUp move;

        public void Update()
        {
            yRot = Camera.main.transform.rotation.y;
            if(ready == true && ControllingTransform != null){
                Debug.Log("Inside update loop");
                ChangeMode();
            }
            //Debugging
            if(ready == false){Debug.Log("false");}
            if(ControllingTransform == null){Debug.Log("it is null");}

        }

        public void ChangeMode()
        {
            Debug.Log("ChangeMode called");
            if (ControllingTransform != null)
            {
                Debug.Log("Slider val: " + slider.value);
                //if slider is to one side, carry on with translation
                if(slider.value < 0.4){
                    
                    //ControllingTransform.Rotate(0,initialRot.y + (Camera.main.transform.rotation.y * 5),0);
                    ControllingTransform.eulerAngles = new Vector3(0, -520 * yRot, 0);//Mathf.LerpAngle(,,);
                    Debug.Log("Inside slider < 0.5");
                    Debug.Log("euler angles: " + ControllingTransform.eulerAngles);
                    oldPos = newPos;
                    //grabButton.SetActive(false);
                    //move.transform.gameObject.SetActive(false);
                //if slider is to the other side, carry on with rotation
  
                }else{
                //if(slider.value > 0.7){
                    //reveal hidden button
                    Debug.Log("in right part");
                    //grabButton.SetActive(true);
                    set.masterlock = true;
                    Debug.Log("master lock " + set.masterlock);
                }
            }
        }

        private void Start()
        {
            slider = GetComponent<Slider>();
            //grabButton = GameObject.FindWithTag("GrabButton");

        }

        private void OnEnable()
        {
            //slider = GetComponent<Slider>();
            if (MenuController.Instance != null && MenuController.Instance.ControllingObject != null)
            {
                ready = true;
                ControllingTransform = MenuController.Instance.ControllingObject.transform;
                initialRot = ControllingTransform.localEulerAngles;
                Debug.Log("initial cube rotation: " + initialRot);
                //ControllingTransform = MenuController.Instance.ControllingObject.transform;
                //_initialLocalScale = ControllingTransform.localScale;
                slider.value = 0.5f;
            }
        }
  
        //private void OnDisable()
        //{
        //    ControllingTransform = null;
        //    ready = false;
        //    //_initialLocalScale = Vector3.one;
        //}
    }
}