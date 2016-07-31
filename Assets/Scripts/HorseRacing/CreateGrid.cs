using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreateGrid : MonoBehaviour
{
  public NodeObject[,] GenerateGrid()
  {
    Vector3 start = GetComponent<GameManager>().startPosition;
    Vector3 end = GetComponent<GameManager>().endPosition;
    float tileSize = GetComponent<GameManager>().tileSize;

    //coluna
    int width = (int)((end - start).x / tileSize);
    //linha
    int depth = (int)((end - start).z / tileSize);
    NodeObject[,] grid = new NodeObject[depth, width];

    float row, column;
    float maxY;

    RaycastHit[] hit;
    for (int i = 0; i < depth; ++i)
    {
      for (int j = 0; j < width; ++j)
      {
        column = start.x + (j * tileSize) + (tileSize / 2);
        row = start.z + (i * tileSize) + (tileSize / 2);

        grid[i, j] = (NodeObject)Instantiate(GetComponent<GameManager>().tilePrefab,
                                                      new Vector3(column, 0, row), Quaternion.identity);
        grid[i, j].Construct(new Vector2(i, j), gameObject.transform,
                                    "no [" + i + ", " + j + "]");

        /*hit = Physics.SphereCastAll(new Vector3(column, 15, row)
                      ,  tileSize / 16, Vector3.down, 30);*/
        hit = Physics.RaycastAll(new Vector3(column, 15, row), Vector3.down, 30);
        maxY = -Mathf.Infinity;

        foreach (RaycastHit h in hit)
        {
          if (h.point.y > maxY)
          {
            if(h.transform.CompareTag("Wall"))
            {
              grid[i, j].transform.position = new Vector3
                (grid[i, j].transform.position.x,
                 h.point.y,
                 grid[i, j].transform.position.z);
              grid[i, j].walkable = false;
            }

            if (h.transform.CompareTag("Floor"))
            {
              grid[i, j].transform.position = new Vector3
                (grid[i, j].transform.position.x,
                 h.point.y,
                 grid[i, j].transform.position.z);
              grid[i, j].walkable = true;
            }
            maxY = h.point.y;
          }
        }
      }
    }

    return grid;
  }
}
