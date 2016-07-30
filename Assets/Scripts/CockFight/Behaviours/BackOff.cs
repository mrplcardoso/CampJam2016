using UnityEngine;
using System.Collections;

public class BackOff : AbstractBehaviour
{
  public override void Act()
  {
    /*Enquanto distancia não for maior que a distancia minima
    para ação, o objeto ira se afastar*/
    if (Vector3.Distance(mind.enemy.transform.position,
        mind.transform.position) < (mind.mBody.minActionRay + 5))
    {
      mind.mBody.Moviment((mind.transform.position - mind.enemy.transform.position).normalized);
    }
    else
      mind.mBody.afterAttack = false;
    Debug.Log("BackOff");
  }

  public override bool Think()
  {
    if (mind.enemy != null)
    {
      if (mind.mBody.afterAttack)
        return true;
    }
    return false;
  }
}
