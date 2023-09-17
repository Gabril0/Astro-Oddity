using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEnemyBullet : Bullet
{
    private BaseEntityScript starEnemy;
    // Start is called before the first frame update
    void Start()
    {
        starEnemy = GameObject.Find("StarEnemy").GetComponent<BaseEntityScript>();
    }

}
