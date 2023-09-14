using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalacticCannon : MonoBehaviour, Evolution
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
        player.Damage = player.Damage * 5f;
        player.BulletCoolDown = player.BulletCoolDown * 0.25f;
        player.IsSlowedDownShooting = true;
    }
    public SpriteRenderer getImage()
    {
        return spriteRenderer;
    }
}
