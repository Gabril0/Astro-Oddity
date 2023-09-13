using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GalacticCannon : MonoBehaviour
{
    private PlayerMovement player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    public void makeChanges()
    {
        player.Damage = player.Damage * 5f;
        player.BulletCoolDown = player.BulletCoolDown * 0.25f;
        player.IsSlowedDownShooting = true;
    }
}
