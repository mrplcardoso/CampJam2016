using UnityEngine;
using System.Collections;

public class AbstractCharacter : MonoBehaviour
{
  public Vector3 moveDirection;
  public float maxActionRay, minActionRay;
  public float mVelocity;
  public float motivation = 0;
  public bool afterAttack = false;

  public void Moviment(Vector3 direction)
  {
    transform.position = new Vector3(
      transform.position.x + mVelocity 
                                    * direction.x * Time.deltaTime,
      transform.position.y,
      transform.position.z + mVelocity 
                                    * direction.z * Time.deltaTime);
  }

  public void ChangeMotivation(float incValue = -0.1f)
  {
    motivation += incValue;
  }
}
