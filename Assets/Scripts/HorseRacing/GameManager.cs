using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class GameManager : MonoBehaviour
{
  //public NodeObject[,] grid;
  [HideInInspector]
  public NodeObject tilePrefab;
  public AgentCharacter[] horses;
  //public NodeObject[] targetNodes;
  [HideInInspector]
  public Vector3 startPosition, endPosition;
  public MicrophoneListener mic;
  public float tileSize;
  //public float gridSize;

  // Use this for initialization
  void Start()
  {
    foreach (AgentCharacter a in horses)
      a.StartAgent();
    horses[Player.numberPlayer].tag = "Player";
    horses[Player.numberPlayer].audioMotivation = 0;
  }

  // Update is called once per frame
  void Update()
  {
    //StartCoroutine("DrawGrid");
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
          if ((mic.MicInput * 100) > 1.5)
          {
            Debug.Log(mic.MicInput * 100);
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
}
