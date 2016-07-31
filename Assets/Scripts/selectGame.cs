using UnityEngine;
using System.Collections;

public class selectGame : MonoBehaviour
{
    public SpriteRenderer sprite;
    public Sprite[] sprites;
    public string[] levels;
    public string level;
    int count;

    void OnMouseUpAsButton()
    {
        if (count >= sprites.Length - 1)
            count = 0;
        else
            count++;

        sprite.sprite = sprites[count];
        level = levels[count];
    }
}
