using UnityEngine;
using System.Collections;

public class TileObject : AbstractCharacter
{
  public Vector2 gridPosition;
  public static NodeObject MatchNode(TileObject tile, NodeObject[,] grid)
  {
    NodeObject current = grid[0, 0];
    foreach (NodeObject n in grid)
    {
      if (Dist2D(tile.transform.position,
                    n.transform.position) <
        Dist2D(tile.transform.position,
                   current.transform.position))
      {
        current = n;
      }
    }
    return current;
  }

  public static float Dist2D(Vector3 p1, Vector3 p2)
  {
    return Vector2.Distance(new Vector2(p1.x, p1.z),
                            new Vector2(p2.x, p2.z));
  }
}
