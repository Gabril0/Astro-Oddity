using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FactoryEnemy : Dummy
{
    [SerializeField] private GameObject enemy;
    override protected void variation()
    {
        createEnemy();
    }

    protected void createEnemy()
    {
        if (timeSinceLastShot > bulletCoolDown)
        {
            Instantiate(enemy, transform.position, transform.rotation);
            timeSinceLastShot = 0;
        }
        else
        {
            timeSinceLastShot += Time.deltaTime;
        }
    }
}
