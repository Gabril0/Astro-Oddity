using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Overweight : MonoBehaviour
{
    private PlayerMovement player;
    void Start()
    {
        player = GameObject.Find("Player").GetComponent<PlayerMovement>();
    }
    public void makeChanges()
    {
        player.Damage = player.Damage * 2f;
        player.Speed = player.Speed * 0.5f;
    }
}
