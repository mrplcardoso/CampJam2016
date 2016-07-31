using UnityEngine;
using System.Collections;

public class Attack : AbstractBehaviour
{
  public float i = 0;

  public override void Act()
  {
    mind.mBody.afterAttack = true;
  }

  public override bool Think()
  {
    if (mind.enemy != null)
    {
      if (AbstractCharacter.ApproximationPrecision(
        Vector3.Distance(mind.enemy.transform.position,
        mind.transform.position), mind.mBody.maxActionRay, 0.1f))
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