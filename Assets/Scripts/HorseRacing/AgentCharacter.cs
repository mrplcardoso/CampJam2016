using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class AgentCharacter : TileObject
{
  public FindPath finder;
  public List<GameObject> path;
  public GameObject pathHolder;
  public GameObject actualNode, targetNode;
  public int cont;
  public bool canMove;

  // Use this for initialization
  public void StartAgent()
  {
    path = new List<GameObject>();
    foreach(Transform t in pathHolder.transform)
    {
      path.Add(t.gameObject);
      t.GetComponent<MeshRenderer>().enabled = false;
    }

    mVelocity = 2;
    audioMotivation = Random.Range(3f, 5f);
    //tag = "IA";
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
            if (actualNode)
                transform.LookAt(actualNode.transform);
      if (transform.position == path[cont].transform.position)
      {
        actualNode = path[cont];
        cont++;
        if (cont >= path.Count)
          canMove = false;
      }
    }
    yield return new WaitForSeconds(10);
  }
}
