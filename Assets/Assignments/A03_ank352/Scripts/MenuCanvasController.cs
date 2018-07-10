using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace A03_ank352
{
    [RequireComponent(typeof(Canvas))]
    public class MenuCanvasController : MonoBehaviour
    {
        public static MenuCanvasController Instance;

        public GameObject ControllingObject;
        public GameObject camera;

        private Canvas _canvas;
        private float _distanceToCamera;
        private bool _isShowing;

        public bool grabbed = false;  // have i been picked up, or not?
        public Rigidbody myRb;
        public DrawDownPointer downPointer;

        private void Awake()
        {
            if (Instance == null)
            {
                Instance = this;
            }
            else if (Instance != this)
            {
                Destroy(this);
            }
        }

        private void Start()
        {
            Hide();
            PickupMe.rotate = false;
            PickupMe.translate = false;

            //Get the initial distance between the canvas and the camera, and project it on the camera's forward direction
            //From AO3Examples
            Vector3 dis = Camera.main.transform.position - transform.position;
            _distanceToCamera = Vector3.Project(dis, Camera.main.transform.forward).magnitude;
        }

        //From AO3Examples
        private void SetChildrenActive(bool isActive)
        {
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(isActive);
            }
        }

        //From AO3Examples
        public void Show(GameObject sender)
        {
            if (_isShowing)
            {
                Hide();
            }
            ControllingObject = sender;
            transform.position = Camera.main.transform.position + Camera.main.transform.forward * _distanceToCamera;
            transform.forward = Camera.main.transform.forward;
            SetChildrenActive(true);
            _isShowing = true;
        }

        //From AO3Examples
        public void Hide()
        {
            ControllingObject = null;
            SetChildrenActive(false);
            _isShowing = false;
        }

        //Turn on rotate mode
        public void Rotate() {
          Debug.Log("Rotate on");
          PickupMe.rotate = true;
          PickupMe.translate = false;
        }

        //Turn on translate mode
        public void Translate() {
          Debug.Log("Translate on");
          PickupMe.translate = true;
          PickupMe.rotate = false;
        }

        public void Update() {
          //Part 2: Switch between translation and rotation using buttons
          ControllingObject = GameObject.Find("Cube");
          camera = GameObject.Find("Player");
          myRb = ControllingObject.GetComponent<Rigidbody>();

          //If set to rotate, rotate
          if (PickupMe.rotate) {
            ControllingObject.transform.parent = camera.transform;  // attach object to camera
            myRb.isKinematic = true;
            ControllingObject.transform.Rotate(Vector3.up, Camera.main.transform.rotation.eulerAngles.y, Space.World);
            ControllingObject.transform.Rotate(Vector3.right, Camera.main.transform.rotation.eulerAngles.x, Space.World);
          }
          //If set to translate, translate
          else if (PickupMe.translate) {
            myRb.isKinematic = true;
            PickupMe.grabbed = false;
            ControllingObject.GetComponent<PickupMe>().PickupOrDrop();
          }
          //Part 1: prevents cube from passing through plane
          if (PickupMe.grabbed && !PickupMe.rotate) {
            //For Unity Testing use this if condition
            // if (Camera.main.transform.rotation.x < 0)

            //For GoogleCardboard
            if (Camera.main.transform.rotation.y < -0.05)
                ControllingObject.transform.position = new Vector3(ControllingObject.transform.position.x, (float) 0.5, ControllingObject.transform.position.z);
              else
                ControllingObject.transform.position = new Vector3(ControllingObject.transform.position.x, ControllingObject.transform.position.y, ControllingObject.transform.position.z);
          }
        }
    }
}
