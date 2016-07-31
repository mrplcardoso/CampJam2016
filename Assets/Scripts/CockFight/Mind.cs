using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Mind : MonoBehaviour
{
  public MicrophoneListener mic;
  public List<AbstractBehaviour> bhvList;
  public GameObject enemy;

  public Body mBody;

  public AbstractBehaviour lastBehaviours;
  public GameObject bhvHolder;

  // Use this for initialization
  void Start()
  {
    SortBehavirous();
  }

  // Update is called once per frame
  void Update()
  {
    ExecuteBehaviour();
    StartCoroutine("CheckMotivation");
  }

  IEnumerator CheckMotivation()
  {
    /*Em loop diminui a motivação do bixo
    enquanto for maior que zero, ele ira atacar o inimigo
    Sempre que houver input, ele aumenta a motivação
    */
    if (gameObject.CompareTag("Player"))
    {
      if (mic != null)
      {
        if (mBody.audioMotivation >= 0)
        {
          mBody.ChangeAudioMotivation();
        }
        if (AbstractCharacter.ApproximationPrecision(mic.MicInput * 100, 1, 0.1f))
        {
          mBody.ChangeAudioMotivation(5);
        }
      }
    }

    if(gameObject.CompareTag("IA"))
    {
      if(mBody.temperMotivation >= 0)
      {
        mBody.ChangeTemperMotivation();
      }
      if(Input.GetKeyDown(KeyCode.Space))
      {
        mBody.ChangeTemperMotivation(5);
      }
    }

    yield return null;
  }

  void SortBehavirous()
  {
    bhvList = new List<AbstractBehaviour>();

    foreach (AbstractBehaviour ab in bhvHolder.GetComponents<AbstractBehaviour>())
    {
      ab.Initialize(this);
      bhvList.Add(ab);
    }

    bhvList.Sort((x, y) => x.priority.CompareTo(y.priority));
  }

  void ExecuteBehaviour()
  {
    for (int i = 0; i < bhvList.Count; i++)
    {
      if (bhvList[i].Think())
      {
        lastBehaviours = bhvList[i];
      }
    }
    lastBehaviours.Act();
  }
}
