using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StoredEnergy : MonoBehaviour, Evolution
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
            player.damageBeforeTransformation = player.damageBeforeTransformation * 0.6f;
        }
        player.BulletCoolDown = player.BulletCoolDown * 0.5f;
        player.Damage = player.Damage * 0.6f;
    }

    public SpriteRenderer getImage()
    {
        return spriteRenderer;
    }
}
