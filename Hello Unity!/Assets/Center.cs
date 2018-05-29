using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Center : MonoBehaviour {
    
    // Use this for initialization
    void Start () {
    }
    
    // Update is called once per frame
    void Update () {
        float x = Random.Range(-10, -1);
        float z = Random.Range(0, 0);
        Vector3 sphere = GameObject.Find("Sphere1").transform.position;
        if (sphere.x > 5 || sphere.x < -5) {
            SetTransformX(5f);
        }
        // } else if (sphere.z > 12 || sphere.z < 2) {
        //     SetTransformZ(2f);
        // } else if ((sphere.x > 5 || sphere.x < -5) && (sphere.z > 12 || sphere.z < 2)) {
        //     SetTransformX(5f);
        //     SetTransformZ(2f);
        // }
        else {
            transform.Translate(x*Time.deltaTime, 0f, z*Time.deltaTime);
        }
    }
    void SetTransformZ(float n){
         transform.position = new Vector3(transform.position.x, transform.position.y, n);
    }
    void SetTransformX(float n){
         transform.position = new Vector3(n, transform.position.y, transform.position.z);
    }
}
