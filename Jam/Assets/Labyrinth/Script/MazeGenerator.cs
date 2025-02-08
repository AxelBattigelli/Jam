using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

public class MazeGenerator : MonoBehaviour
{
    [SerializeField]
    private MazeCell _mazeCellPrefab;

    [SerializeField]
    private int _mazeWidth;

    [SerializeField]
    private int _mazeDepth;

    private MazeCell[,] _mazeGrid;

    void Start()
    {
        _mazeGrid = new MazeCell[_mazeWidth, _mazeDepth];

        for (int x = 0; x < _mazeWidth; x += 4)
        {
            for (int z = 0; z < _mazeDepth; z += 4)
            {
                _mazeGrid[x, z] = Instantiate(_mazeCellPrefab, new Vector3(x, 0, z), Quaternion.identity);
            }
        }

        GenerateMaze(null, _mazeGrid[0, 0]);
        CreateEntranceAndExit();
    }

    private void GenerateMaze(MazeCell previousCell, MazeCell currentCell)
    {
        currentCell.Visit();
        ClearWalls(previousCell, currentCell);

        int x = (int)currentCell.transform.position.x;
        int z = (int)currentCell.transform.position.z;

        bool isInnerCell = x > 0 && x < _mazeWidth - 4 && z > 0 && z < _mazeDepth - 4;

        if (isInnerCell && Random.Range(0, 10) > 7)
        {
            GameObject[] walls = currentCell.GetWalls();
            if (walls.Length > 0)
            {
                GameObject wallToMove = walls[Random.Range(0, walls.Length)];
                if (!wallToMove.GetComponent<MovingWalls>())
                {
                    wallToMove.AddComponent<MovingWalls>();
                }
            }
        }

        MazeCell nextCell;
        do
        {
            nextCell = GetNextUnvisitedCell(currentCell);
            if (nextCell != null)
            {
                GenerateMaze(currentCell, nextCell);
            }
        } while (nextCell != null);
    }


    private MazeCell GetNextUnvisitedCell(MazeCell currentCell)
    {
        var unvisitedCells = GetUnvisitedCells(currentCell);

        return unvisitedCells.OrderBy(_ => Random.Range(4, 40)).FirstOrDefault();
    }

    private IEnumerable<MazeCell> GetUnvisitedCells(MazeCell currentCell)
    {
        int x = (int)currentCell.transform.position.x;
        int z = (int)currentCell.transform.position.z;

        if (x + 4 < _mazeWidth)
        {
            var cellToRight = _mazeGrid[x + 4, z];

            if (cellToRight.IsVisited == false)
            {
                yield return cellToRight;
            }
        }

        if (x - 4 >= 0)
        {
            var cellToLeft = _mazeGrid[x - 4, z];

            if (cellToLeft.IsVisited == false)
            {
                yield return cellToLeft;
            }
        }

        if (z + 4 < _mazeDepth)
        {
            var cellToFront = _mazeGrid[x, z + 4];

            if (cellToFront.IsVisited == false)
            {
                yield return cellToFront;
            }
        }

        if (z - 4 >= 0)
        {
            var cellToBack = _mazeGrid[x, z - 4];

            if (cellToBack.IsVisited == false)
            {
                yield return cellToBack;
            }
        }
    }

    private void ClearWalls(MazeCell previousCell, MazeCell currentCell)
    {
        if (previousCell == null)
        {
            return;
        }

        if (previousCell.transform.position.x < currentCell.transform.position.x)
        {
            previousCell.ClearRightWall();
            currentCell.ClearLeftWall();
            return;
        }

        if (previousCell.transform.position.x > currentCell.transform.position.x)
        {
            previousCell.ClearLeftWall();
            currentCell.ClearRightWall();
            return;
        }

        if (previousCell.transform.position.z < currentCell.transform.position.z)
        {
            previousCell.ClearFrontWall();
            currentCell.ClearBackWall();
            return;
        }

        if (previousCell.transform.position.z > currentCell.transform.position.z)
        {
            previousCell.ClearBackWall();
            currentCell.ClearFrontWall();
            return;
        }
    }

    private void CreateEntranceAndExit()
    {
        int entryZ = Random.Range(0, _mazeDepth / 4) * 4;
        _mazeGrid[0, entryZ].ClearLeftWall();

        int exitZ = Random.Range(0, _mazeDepth / 4) * 4;
        int lastX = _mazeWidth - 4;

        if (_mazeGrid[lastX, exitZ] != null)
        {
            _mazeGrid[lastX, exitZ].ClearRightWall();
        }
        else
        {
            Debug.LogError($"La cellule de sortie ({lastX}, {exitZ}) est invalide !");
        }
    }

}
