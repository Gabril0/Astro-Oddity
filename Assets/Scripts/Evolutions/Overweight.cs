using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overweight : MonoBehaviour, Evolution
{
    private PlayerMovement player;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    public void makeChanges()
    {
        if (player.IsTransformed)
        {
            player.speedBeforeTransformation = player.speedBeforeTransformation * 0.75f;

            player.damageBeforeTransformation = player.damageBeforeTransformation * 4f;
        }
        player.Damage = player.Damage * 4f;
        player.Speed = player.Speed * 0.75f;
    }
    public SpriteRenderer getImage()
    {
        return spriteRenderer;
    }
}
