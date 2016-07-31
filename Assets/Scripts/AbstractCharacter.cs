using UnityEngine;
using System.Collections;

public class AbstractCharacter : MonoBehaviour
{
  public Vector3 moveDirection;
  public Transform minLimit, maxLimit;
  public float maxActionRay, minActionRay;
  public float mVelocity;
  public float audioMotivation = 0, temperMotivation = 0, lightMotivation = 0;
  public float life = 100;
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

  public void ChangeAudioMotivation(float incValue = -0.25f)
  {
    audioMotivation += incValue;
  }

  public void ChangeTemperMotivation(float incValue = -0.01f)
  {
    temperMotivation += incValue;
  }

  public static bool ApproximationPrecision(float a, float b, float tolerance)
  {
    return (Mathf.Abs(a - b) < tolerance);
  }
}
