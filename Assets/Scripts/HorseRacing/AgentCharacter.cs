using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AgentCharacter : TileObject
{
  public FindPath finder;
  public List<NodeObject> path;
  public NodeObject actualNode, targetNode;
  public int cont;
  public bool canMove;

  // Use this for initialization
  public void StartAgent()
  {
    mVelocity = 2;
    audioMotivation = 1;
    tag = "IA";
    actualNode = MatchNode(this, finder.grid);
    gridPosition = actualNode.gridPosition;
    transform.position = new Vector3(actualNode.transform.position.x,
      1, actualNode.transform.position.z);
  }

  public void Path(NodeObject target = null)
  {
    if(target != null)
      targetNode = target;
    path = finder.Search(actualNode, targetNode);
  }

  // Update is called once per frame
  void Update()
  {
    if (canMove)
      StartCoroutine("MoveToNode");
  }

  IEnumerator MoveToNode()
  {
    if (actualNode != targetNode)
    {
      transform.position =
        Vector3.MoveTowards(transform.position,
        path[cont].transform.position, (audioMotivation * mVelocity) * Time.deltaTime);
      if (transform.position == path[cont].transform.position)
      {
        actualNode = path[cont];
        gridPosition = path[cont].gridPosition;
        cont++;
        if (cont >= path.Count)
          canMove = false;
      }
    }
    yield return new WaitForSeconds(10);
  }
}
