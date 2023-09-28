using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBang : MonoBehaviour, Evolution
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
        if (player.IsTransformed) {
            player.bulletCDBeforeTransformation = player.bulletCDBeforeTransformation * 0.75f;
            player.speedBeforeTransformation = player.speedBeforeTransformation * 1.5f;//this is a lie, it isn`t really 2x because it would  be really hard to maneuver
            player.Health = player.Health * 1.5f;
            player.damageBeforeTransformation = player.damageBeforeTransformation * 1.5f;
        }
        player.BulletCoolDown = player.BulletCoolDown * 0.75f;
        player.Speed = player.Speed * 1.5f;//this is a lie, it isn`t really 2x because it would  be really hard to maneuver
        player.Health = player.Health * 1.5f; 
        player.Damage = player.Damage * 1.5f;

    }
    public SpriteRenderer getImage()
    {
        return spriteRenderer;
    }
}
