using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigBang : Evolution
{
    private PlayerMovement player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    public void makeChanges()
    {
        player.BulletCoolDown = player.BulletCoolDown * 0.5f;
        player.Speed = player.Speed * 1.5f;
        player.Health = player.Health * 1.5f; //this is a lie, it isn`t really 2x because it would  be really hard to maneuver
        player.Damage = player.Damage * 2;

    }
}
