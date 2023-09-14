using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SuddenDeath : MonoBehaviour, Evolution
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
        player.Health = player.Health * 0.01f;
        player.Damage = player.Damage * 10f;

    }

    public SpriteRenderer getImage()
    {
        return spriteRenderer;
    }
}
