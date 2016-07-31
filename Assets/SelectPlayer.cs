using UnityEngine;
using System.Collections;

public class SelectPlayer : MonoBehaviour {

    public int playerNumber;
    public Transform ringPosition;
    public GameObject ring;
    public float delay = 1f;
    public Animator anim;
    public string level;
    
    void OnMouseUpAsButton()
    {
        
        Player.numberPlayer = playerNumber;
        Instantiate(ring,ringPosition.position, ringPosition.rotation, transform);
        anim.SetTrigger("roda");
        Invoke("loadScene", delay);
        Debug.Log("Click : "+Player.numberPlayer);
    }

    void loadScene()
    {
        
        Application.LoadLevel(level);
    }
}
