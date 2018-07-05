using System.Collections;
using System.Collections.Generic;
using UnityEngine;

/**
* This code was developed from the help of a tutorial on creating randomly generated mazes
* from scratch in unity.
* https://catlikecoding.com/unity/tutorials/maze/
**/

namespace jsd410 {

    // This class does the main work for randomly generating the maze

    public class Maze : MonoBehaviour {

        public MazeCell cellPrefab;
        private MazeCell[,] cells;
        public IntVector2 size;
        public float generationStepDelay;
        public MazePassage passagePrefab;
        public MazeWall wallPrefab;

        private void CreatePassage (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
            MazePassage passage = Instantiate(passagePrefab) as MazePassage;
            passage.Initialize(cell, otherCell, direction);
            passage = Instantiate(passagePrefab) as MazePassage;
            passage.Initialize(otherCell, cell, direction.GetOpposite());
        }

        private void CreateWall (MazeCell cell, MazeCell otherCell, MazeDirection direction) {
            MazeWall wall = Instantiate(wallPrefab) as MazeWall;
            wall.Initialize(cell, otherCell, direction);
            if (otherCell != null) {
                wall = Instantiate(wallPrefab) as MazeWall;
                wall.Initialize(otherCell, cell, direction.GetOpposite());
            }
        }

        // Adds 'cells' of maze to an array for later use.
        private void DoFirstGenerationStep (List<MazeCell> activeCells) {
            activeCells.Add(CreateCell(RandomCoordinates));
        }

        // Makes choice about where next 'cell' will be based on active 'cells'
        private void DoNextGenerationStep (List<MazeCell> activeCells) {
            int currentIndex = activeCells.Count - 1;
            MazeCell currentCell = activeCells[currentIndex];
            if (currentCell.IsFullyInitialized) {
                activeCells.RemoveAt(currentIndex);
                return;
            }
            MazeDirection direction = currentCell.RandomUninitializedDirection;
            IntVector2 coordinates = currentCell.coordinates + direction.ToIntVector2();
            if (ContainsCoordinates(coordinates)) {
                MazeCell neighbor = GetCell(coordinates);
                if (neighbor == null) {
                    neighbor = CreateCell(coordinates);
                    CreatePassage(currentCell, neighbor, direction);
                    activeCells.Add(neighbor);
                }
                else {
                    CreateWall(currentCell, neighbor, direction);
                }
            }
            else {
                CreateWall(currentCell, null, direction);
            }
        }

        public IntVector2 RandomCoordinates {
            get {
                return new IntVector2(Random.Range(0, size.x), Random.Range(0, size.z));
            }
        }

        public bool ContainsCoordinates (IntVector2 coordinate) {
            return coordinate.x >= 0 && coordinate.x < size.x && coordinate.z >= 0 && coordinate.z < size.z;
        }

        public MazeCell GetCell (IntVector2 coordinates) {
            return cells[coordinates.x, coordinates.z];
        }

        public IEnumerator Generate () {
            WaitForSeconds delay = new WaitForSeconds(generationStepDelay);
            cells = new MazeCell[size.x, size.z];
            List<MazeCell> activeCells = new List<MazeCell>();
            DoFirstGenerationStep(activeCells);
            // IntVector2 coordinates = RandomCoordinates;
            while (activeCells.Count > 0) {
                yield return delay;
                DoNextGenerationStep(activeCells);
                // CreateCell(coordinates);
                // coordinates += MazeDirections.RandomValue.ToIntVector2();
            }
        }

        private MazeCell CreateCell (IntVector2 coordinates) {
            MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
            cells[coordinates.x, coordinates.z] = newCell;
            newCell.coordinates = coordinates;
            newCell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
            newCell.transform.parent = transform;
            newCell.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f);
            return newCell;
        }
    }
}
