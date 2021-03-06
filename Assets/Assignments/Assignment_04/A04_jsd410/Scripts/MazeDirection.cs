﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* This code was developed from the help of a tutorial on creating randomly generated mazes
* from scratch in unity.
* https://catlikecoding.com/unity/tutorials/maze/
**/

namespace jsd410 {

    // This static class was used to help decide and store the direction of each edge in the maze.

    public enum MazeDirection {
        North, East, South, West
    }

    public static class MazeDirections {

        public const int Count = 4;

        private static Quaternion[] rotations = {
            Quaternion.identity,
            Quaternion.Euler(0f, 90f, 0f),
            Quaternion.Euler(0f, 180f, 0f),
            Quaternion.Euler(0f, 270f, 0f)
        };
        
        public static Quaternion ToRotation (this MazeDirection direction) {
            return rotations[(int)direction];
        }

        public static MazeDirection RandomValue {
            get {
                return (MazeDirection)Random.Range(0, Count);
            }
        }

        private static IntVector2[] vectors = {
            new IntVector2(0, 1),
            new IntVector2(1, 0),
            new IntVector2(0, -1),
            new IntVector2(-1, 0)
        };

        public static IntVector2 ToIntVector2 (this MazeDirection direction) {
            return vectors[(int)direction];
        }

        private static MazeDirection[] opposites = {
            MazeDirection.South,
            MazeDirection.West,
            MazeDirection.North,
            MazeDirection.East
        };

        public static MazeDirection GetOpposite (this MazeDirection direction) {
            return opposites[(int)direction];
        }

    }
}