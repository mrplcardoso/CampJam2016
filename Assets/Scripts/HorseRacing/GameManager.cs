using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
  public NodeObject[,] grid;
  public NodeObject tilePrefab;
  public Vector3 startPosition, endPosition;
  public float tileSize;
  public float gridSize;

  // Use this for initialization
  void Start()
  {
    grid = GetComponent<CreateGrid>().GenerateGrid();
    GetComponent<FindPath>().grid = grid;
  }

  // Update is called once per frame
  void Update()
  {
    StartCoroutine("DrawGrid");
  }

  IEnumerator DrawGrid()
  {
    if (grid != null)
    {
      for (int i = 0; i < grid.GetLength(0); ++i)
      {
        for (int j = 0; j < grid.GetLength(1); ++j)
        {
          for (int x = i - 1; x < i + 2; x++)
          {
            for (int y = j - 1; y < j + 2; y++)
            {
              if (y < 0 || x < 0 ||
                y >= grid.GetLength(1) ||
                x >= grid.GetLength(0))
                continue;
              if (!grid[i, j].walkable || !grid[x, y].walkable)
                continue;

              Vector3 start = new Vector3(grid[i, j].transform.position.x, grid[i, j].transform.position.y, grid[i, j].transform.position.z);
              Vector3 end = new Vector3(grid[x, y].transform.position.x, grid[x, y].transform.position.y, grid[x, y].transform.position.z);

              UnityEngine.Debug.DrawLine(start, end, Color.blue);
            }
          }
        }
      }
    }
    yield return new WaitForSeconds(10);
  }
}
