using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* This code was developed from the help of a tutorial on creating randomly generated mazes
* from scratch in unity.
* https://catlikecoding.com/unity/tutorials/maze/
**/
namespace jsd410 {
    public class GameManager : MonoBehaviour {

        public Maze mazePrefab;
        private Maze mazeInstance;

    	// Use this for initialization
    	void Start () {
    		BeginGame();
    	}

        private void BeginGame () {
            mazeInstance = Instantiate(mazePrefab) as Maze;
            StartCoroutine(mazeInstance.Generate());
        }
    }
}