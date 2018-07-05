﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Maze : MonoBehaviour {

    public int sizeX, sizeZ;
    public MazeCell cellPrefab;
    private MazeCell[,] cells;
    public IntVector2 size;

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

    public void Generate () {
        cells = new MazeCell[size.x, size.z];
        IntVector2 coordinates = RandomCoordinates;
        while (ContainsCoordinates(coordinates)) {
            CreateCell(coordinates);
            coordinates.z += 1;
        }
        // for (int x = 0; x < size.x; x++) {
        //     for (int z = 0; z < size.z; z++) {
        //         CreateCell(new IntVector(x, z));
        //     }
        // }
    }

    private void CreateCell (IntVector2 coordinates) {
        MazeCell newCell = Instantiate(cellPrefab) as MazeCell;
        cells[coordinates.x, coordinates.z] = newCell;
        newCell.coordinates = coordinates;
        newCell.name = "Maze Cell " + coordinates.x + ", " + coordinates.z;
        newCell.transform.parent = transform;
        newCell.transform.localPosition = new Vector3(coordinates.x - size.x * 0.5f + 0.5f, 0f, coordinates.z - size.z * 0.5f + 0.5f);
    }

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
