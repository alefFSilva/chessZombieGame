using System;
using System.Collections.Generic;
using UnityEngine;

public class BoardManager : MonoBehaviour
{
    public GameObject TilePrefab;

    public BoardManager()
    {
        _initialTileLocation = new Vector3(0, 0, 0);
        _distanceBetweenTiles = 1f;
    }

    void Start()
    {
        InitializeBoard();
    }

    void Update()
    {
        
    }

    public void InitializeBoard()
    {
        var boardMatrix = GetBoardMatrix(1,1);

        foreach(var coordinate in boardMatrix)
        {
            var newTileVector = new Vector3(coordinate.Line, 0, coordinate.Column);
            Instantiate(TilePrefab, newTileVector, Quaternion.identity);
        }
    }

    private List<TileCoordinateDTO> GetBoardMatrix(int lineLength, int columnLength)
    {
        var result = new List<TileCoordinateDTO>();

        for(int i = 0; i < lineLength; i++)
        {
            for(int j = 0; j < columnLength; j++)
            {
                var newTileCoordinates = new TileCoordinateDTO(i, j);
                result.Add(newTileCoordinates);
            }
        }
        return result;
    }

    public class TileCoordinateDTO : Tuple<int, int>
    {
        public TileCoordinateDTO(int item1, int item2) 
            : base(item1, item2)
        {}

        public int Line => Item1;
        public int Column => Item2;
    }
}
