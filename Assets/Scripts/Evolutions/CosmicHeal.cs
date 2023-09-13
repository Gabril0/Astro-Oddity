using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CosmicHeal : MonoBehaviour
{
    private PlayerMovement player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    public void makeChanges()
    {
        player.Health = player.Health * 2f;


    }
}
