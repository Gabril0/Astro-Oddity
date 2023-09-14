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
        player.Damage = player.Damage * 2f;
        player.Speed = player.Speed * 0.5f;
    }
    public SpriteRenderer getImage()
    {
        return spriteRenderer;
    }
}
