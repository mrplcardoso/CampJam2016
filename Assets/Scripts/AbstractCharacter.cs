using UnityEngine;
using System.Collections;

public class AbstractCharacter : MonoBehaviour
{
  public Vector3 moveDirection;
  public Transform minLimit, maxLimit;
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

    transform.position = new Vector3(
      Mathf.Clamp(transform.position.x, minLimit.position.x + 0.1f, maxLimit.position.x - 0.1f),
      transform.position.y,
      Mathf.Clamp(transform.position.z, minLimit.position.z + 0.1f, maxLimit.position.z - 0.1f));
  }

  public void ChangeMotivation(float incValue = -0.1f)
  {
    motivation += incValue;
  }

  public static bool ApproximationPrecision(float a, float b, float tolerance)
  {
    return (Mathf.Abs(a - b) < tolerance);
  }
}
