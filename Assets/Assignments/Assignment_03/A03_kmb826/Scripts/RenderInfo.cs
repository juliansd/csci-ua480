using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;

namespace kmb826_assignment3
{
    public class RenderInfo : MonoBehaviour
    {
        public GameObject cube;
        public GameObject player;

        public float distance;
        public Text move_info;

        // Set the text rendering on the canvas to not show
        void Start()
        {
            // This loop is intended to iterate through all of the children of the canvas and set the active property to false
            for (int i = 0; i < transform.childCount; i++)
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }

        // Update is called once per frame
        void Update()
        {
            distance = Vector3.Distance(cube.transform.position, player.transform.position); // Variable to keep track of distance between the cube and the player/camera
            
            // If "Move" button selected, show text to display the distance between cube and player/camera to prove that cube is in fact get nearer or further away
            if(PickUpObject.move)
            {
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(true);
                }
                if (move_info.text == null)
                {
                    Debug.Log("text is null");
                }
                else
                {
                    move_info.text = "D: " + distance.ToString();
                }
            }
            else
            {
                // Set text rendering to not appear
                for (int i = 0; i < transform.childCount; i++)
                {
                    transform.GetChild(i).gameObject.SetActive(false);
                }
                move_info.text = "";
            }

        }
    }
}
