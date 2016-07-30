using UnityEngine;
using System.Collections;

public abstract class AbstractBehaviour : MonoBehaviour
{
  public Mind mind;
  public int priority;

  public abstract void Act();
  public abstract bool Think();

  public void Initialize(Mind owner)
  {
    mind = owner;
  }
}
