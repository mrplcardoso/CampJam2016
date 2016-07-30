using UnityEngine;
using System.Collections;

public class Attack : AbstractBehaviour
{
  public float i = 0;

  public override void Act()
  {
    mind.mBody.afterAttack = true;
    Debug.Log("Attack");
  }

  public override bool Think()
  {
    if (mind.enemy != null)
    {
      if (Vector3.Distance(mind.enemy.transform.position,
        mind.transform.position) <= mind.mBody.maxActionRay)
      {
        if (i <= 0)
        {
          i = 1;
          return true;
        }
      }
    }
    i -= Time.deltaTime;
    return false;
  }
}