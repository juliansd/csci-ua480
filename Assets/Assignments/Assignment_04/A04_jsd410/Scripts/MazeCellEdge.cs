using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* This code was developed from the help of a tutorial on creating randomly generated mazes
* from scratch in unity.
* https://catlikecoding.com/unity/tutorials/maze/
**/

namespace jsd410 {

    public abstract class MazeCellEdge : MonoBehaviour {

        public MazeCell cell, otherCell;
        public MazeDirection direction;

        public void Initialize (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
            this.cell = cell;
            this.otherCell = otherCell;
            this.direction = direction;
            cell.SetEdge(direction, this);
            transform.parent = cell.transform;
            transform.localPosition = Vector3.zero;
            transform.localRotation = direction.ToRotation();
        }
    	
    }
}
