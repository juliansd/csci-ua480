using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* This code was developed from the help of a tutorial on creating randomly generated mazes
* from scratch in unity.
* https://catlikecoding.com/unity/tutorials/maze/
**/
namespace jsd410 {

    // This was made to be able to represent 2d coordinates as a single value for convenience.

    [System.Serializable]
    public struct IntVector2 {

        public int x, z;

        public IntVector2 (int x, int z) {
            this.x = x;
            this.z = z;
        }

        public static IntVector2 operator + (IntVector2 a, IntVector2 b) {
            a.x += b.x;
            a.z += b.z;
            return a;
        }

    	// Use this for initialization
    	void Start () {
    		
    	}
    	
    	// Update is called once per frame
    	void Update () {
    		
    	}
    }
}
