using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicStrength : MonoBehaviour, Evolution
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
            player.damageBeforeTransformation = player.damageBeforeTransformation * 2f;
        }
        player.Damage = player.Damage * 2f;


    }
    public SpriteRenderer getImage()
    {
        return spriteRenderer;
    }
}
