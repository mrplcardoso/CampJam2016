using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
  public NodeObject[,] grid;
  public NodeObject tilePrefab;
  public AgentCharacter[] horses;
  public NodeObject[] targetNodes;
  public Vector3 startPosition, endPosition;
  public MicrophoneListener mic;
  public float tileSize;
  public float gridSize;

  // Use this for initialization
  void Start()
  {
    grid = GetComponent<CreateGrid>().GenerateGrid();
    GetComponent<FindPath>().grid = grid;
    MatchTargetNodes();
    horses[Player.numberPlayer].tag = "Player";
    horses[Player.numberPlayer].audioMotivation = 0;
  }

  // Update is called once per frame
  void Update()
  {
    StartCoroutine("DrawGrid");
    if(Input.GetKeyDown(KeyCode.Space))
    {
      foreach (AgentCharacter a in horses)
        a.canMove = true;
    }
    StartCoroutine("CheckMotivation");
  }

  IEnumerator CheckMotivation()
  {
    /*Em loop diminui a motivação do bixo
    enquanto for maior que zero, ele ira atacar o inimigo
    Sempre que houver input, ele aumenta a motivação
    */

    foreach(AgentCharacter a in horses)
    {
      if (a.gameObject.CompareTag("Player"))
      {
        if (mic != null)
        {
          if (a.audioMotivation >= 0)
          {
            a.ChangeAudioMotivation();
          }
          if (AbstractCharacter.ApproximationPrecision(mic.MicInput * 100, 1, 0.1f))
          {
            a.ChangeAudioMotivation(1f);
          }
        }
      }
    }


    /*if (gameObject.CompareTag("IA"))
    {
      if (mBody.temperMotivation >= 0)
      {
        mBody.ChangeTemperMotivation();
      }
      if (Input.GetKeyDown(KeyCode.Space))
      {
        mBody.ChangeTemperMotivation(5);
      }
    }
    */
    yield return null;
  }

  void MatchTargetNodes()
  {
    for(int i = 0; i < targetNodes.Length; ++i)
    {
      horses[i].StartAgent();
      horses[i].Path(TileObject.MatchNode(targetNodes[i], grid));
      targetNodes[i].transform.position = new Vector3(
        horses[i].targetNode.transform.position.x,
        targetNodes[i].transform.position.y,
        horses[i].targetNode.transform.position.z);
      targetNodes[i].gridPosition = horses[i].targetNode.gridPosition;
    }
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
