using UnityEngine;
using System.Collections;

public class SeekEnemy : AbstractBehaviour
{
  public override void Act()
  {
    mind.mBody.Moviment((mind.enemy.transform.position - mind.transform.position).normalized);
  }

  public override bool Think()
  {
    if (mind.enemy != null)
    {

      if (mind.CompareTag("Player"))
      {
        if (mind.mBody.audioMotivation > 0)
        {
          return true;
        }
      }

      if (mind.CompareTag("IA"))
      {
        if ((Vector3.Distance(mind.enemy.transform.position, mind.transform.position)
          < mind.mBody.minActionRay) || mind.mBody.temperMotivation > 0)
        {
          return true;
        }
      }
    }
    return false;
  }
}
