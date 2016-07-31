using UnityEngine;
using System.Collections;

public class NodeObject : TileObject
{
  public NodeObject parent;
  public float hCost, gCost;
  public bool walkable;

  public void Construct(Vector2 mPos, Transform mParent, string mName)
  {
    gridPosition = mPos;
    transform.parent = mParent;
    gameObject.name = mName;

    walkable = false;
  }

  public float FCost(float heightCost = 0)
  {
    return hCost + gCost - heightCost;
  }
}
