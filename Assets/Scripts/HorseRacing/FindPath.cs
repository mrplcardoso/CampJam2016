using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class FindPath : MonoBehaviour
{
  public NodeObject[,] grid;
  List<NodeObject> openList;
  List<NodeObject> closedList;

  public List<NodeObject> Search(NodeObject startNode, NodeObject endNode)
  {
    openList = new List<NodeObject>();
    closedList = new List<NodeObject>();
    NodeObject currentNode = null;
    float mCost;

    startNode.hCost = MoveCost(startNode, endNode);
    openList.Add(startNode);

    while (openList.Count > 0)
    {
      currentNode = openList[0];
      foreach (NodeObject n in openList)
      {
        if (n == currentNode)
          continue;

        if (n.FCost() < currentNode.FCost() ||
        n.FCost() == currentNode.FCost() &&
          n.hCost < currentNode.hCost)
        {
          currentNode = n;
        }
      }

      openList.Remove(currentNode);
      closedList.Add(currentNode);

      if (currentNode == endNode)
        return RetrievePath(startNode, endNode);

      foreach (NodeObject n in GetNeighbours(currentNode))
      {
        mCost = currentNode.gCost + MoveCost(currentNode, n);
        if (mCost < n.gCost || !openList.Contains(n))
        {
          n.gCost = mCost;
          n.hCost = MoveCost(n, endNode);
          n.parent = currentNode;
          if (!openList.Contains(n))
            openList.Add(n);
        }
      }
    }

    return null;
  }

  public static float MoveCost(NodeObject a, NodeObject b)
  {
    float x = Mathf.Abs(a.gridPosition.x - b.gridPosition.x);
    float y = Mathf.Abs(a.gridPosition.y - b.gridPosition.y);
    if (x > y)
      return 14 * y + 10 * (x - y);
    return 14 * x + 10 * (y - x);
  }

  public List<NodeObject> GetNeighbours(NodeObject node)
  {
    List<NodeObject> neighbours = new List<NodeObject>();
    int checkX, checkY;

    for (int i = -1; i <= 1; ++i)
    {
      for (int j = -1; j <= 1; ++j)
      {
        if (i == 0 && j == 0)
          continue;

        checkX = (int)(i + node.gridPosition.x);
        checkY = (int)(j + node.gridPosition.y);

        if (checkX >= 0 && checkX < grid.GetLength(0)
          && checkY >= 0 && checkY < grid.GetLength(1))
        {
          if (grid[checkX, checkY].walkable && !closedList.Contains(grid[checkX, checkY]))
          {
            neighbours.Add(grid[checkX, checkY]);
          }
        }
      }
    }
    return neighbours;
  }

  public List<NodeObject> RetrievePath(NodeObject start, NodeObject end)
  {
    List<NodeObject> path = new List<NodeObject>();
    NodeObject current = end;

    while (current != start)
    {
      path.Add(current);
      current = current.parent;
    }

    path.Reverse();
    return path;
  }
}
