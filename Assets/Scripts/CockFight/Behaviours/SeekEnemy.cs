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
        if (mind.mBody.motivation > 0)
        {
          Debug.Log("Seek");
          return true;
        }
      }

      if (mind.CompareTag("IA"))
      {
        if (Vector3.Distance(mind.enemy.transform.position, mind.transform.position)
          < mind.mBody.minActionRay)
        {
          /*if (Vector3.Distance(mind.enemy.transform.position, mind.transform.position)
          > mind.mBody.maxActionRay)*/
          {
            return true;
          }
        }
      }
    }
    return false;
  }
}
