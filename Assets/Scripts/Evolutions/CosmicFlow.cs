using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicFlow : MonoBehaviour
{
    private PlayerMovement player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    public void makeChanges()
    {
        player.BulletCoolDown = player.BulletCoolDown * 0.5f;


    }
}
