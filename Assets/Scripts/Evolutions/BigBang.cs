using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBang : MonoBehaviour, Evolution
{
    public GameObject playerGO;
    private PlayerMovement player;
    private SpriteRenderer spriteRenderer;
    void Start()
    {
        spriteRenderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        player = gameObject.GetComponent<PlayerMovement>();
    }
    public void makeChanges()
    {
        Debug.Log(0);
        player.BulletCoolDown = player.BulletCoolDown * 0.5f;
        player.Speed = player.Speed * 1.5f;
        player.Health = player.Health * 1.5f; //this is a lie, it isn`t really 2x because it would  be really hard to maneuver
        player.Damage = player.Damage * 2;

    }
    public SpriteRenderer getImage()
    {
        return spriteRenderer;
    }
}
