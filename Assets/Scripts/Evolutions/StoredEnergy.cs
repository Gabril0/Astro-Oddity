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
        player.BulletCoolDown = player.BulletCoolDown * 0.5f;
        player.Damage = player.Damage * 0.3f;
    }

    public SpriteRenderer getImage()
    {
        return spriteRenderer;
    }
}
