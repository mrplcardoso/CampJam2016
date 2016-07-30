using UnityEngine;
using System.Collections;

public class Wander : AbstractBehaviour
{
  public float i = 0;
  public override void Act()
  {
    if (CoolDown())
    {
      mind.mBody.moveDirection = RandVector();
    }

    mind.mBody.Moviment(mind.mBody.moveDirection);
    //Debug.Log("rodando");
  }

  public override bool Think()
  {
    return true;
  }

  public bool CoolDown()
  {
    if (i <= 0)
    {
      i = 2;
      return true;
    }
    i -= Time.deltaTime;
    return false;
  }

  public Vector3 RandVector()
  {
    float ang = Random.Range(Mathf.PI / 6, Mathf.PI * 11 / 6);
    Vector3 t_direction = new Vector3(Mathf.Cos(ang), 0.0f, Mathf.Sin(ang));
    return t_direction;
  }
}
