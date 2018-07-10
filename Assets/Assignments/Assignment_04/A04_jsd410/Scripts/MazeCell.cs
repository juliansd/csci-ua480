using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* This code was developed from the help of a tutorial on creating randomly generated mazes
* from scratch in unity.
* https://catlikecoding.com/unity/tutorials/maze/
**/

namespace jsd410 {

    // This class is used to represent each cell in the maze.

    public class MazeCell : MonoBehaviour {

        public IntVector2 coordinates;
        private int initializedEdgeCount;

    	private MazeCellEdge[] edges = new MazeCellEdge[MazeDirections.Count];

        public MazeCellEdge GetEdge (MazeDirection direction) {
            return edges[(int)direction];
        }

        public bool IsFullyInitialized {
            get {
                return initializedEdgeCount == MazeDirections.Count;
            }
        }
        
        public void SetEdge (MazeDirection direction, MazeCellEdge edge) {
            edges[(int)direction] = edge;
            initializedEdgeCount += 1;
        }

        public MazeDirection RandomUninitializedDirection {
            get {
                int skips = Random.Range(0, MazeDirections.Count - initializedEdgeCount);
                for (int i = 0; i < MazeDirections.Count; i++) {
                    if (edges[i] == null) {
                        if (skips == 0) {
                            return (MazeDirection)i;
                        }
                        skips -= 1;
                    }
                }
                throw new System.InvalidOperationException("MazeCell has no uninitialized directions left.");
            }
        }
    }
}
