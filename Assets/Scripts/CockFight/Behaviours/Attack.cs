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
          mind.mBody.anim.SetBool("attack", true);
          return true;
        }
      }
    }
    i -= Time.deltaTime;
    mind.mBody.anim.SetBool("attack", false);
    return false;
  }
}