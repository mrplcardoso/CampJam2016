using UnityEngine;
using System.Collections;

public class SelectPlayer : MonoBehaviour {

    public int playerNumber;
    public Transform ringPosition;
    public GameObject ring;

    void OnMouseUpAsButton()
    {
        Player.numberPlayer = playerNumber;
        Instantiate(ring, ringPosition);
    }
}
