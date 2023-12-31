using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicFlow : MonoBehaviour, Evolution
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
            player.bulletCDBeforeTransformation = player.bulletCDBeforeTransformation * 0.5f;

        }
        player.BulletCoolDown = player.BulletCoolDown * 0.5f;


    }
    public SpriteRenderer getImage()
    {
        return spriteRenderer;
    }
}
