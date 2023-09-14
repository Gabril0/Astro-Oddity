using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicHeal : MonoBehaviour, Evolution
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
        player.Health = player.Health * 2f;


    }
    public SpriteRenderer getImage()
    {
        return spriteRenderer;
    }
}
