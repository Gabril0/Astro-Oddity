using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : Dummy
{
    [SerializeField] float multipleShotCooldown = 1;
    private float timeSinceMultipleShot = 0;

    override
    protected void variationDead() {
        enableEvolution();
    }

    override
    protected void variation(){
        rotateToPosition( player.transform.position, transform.position);
        multipleShot(10);
        shoot(true);
    }

    protected void multipleShot(int numbersOfBullets) {//function that shoots the number of bullet specified in an equal angle
        float angle = 360 / numbersOfBullets;
        if (timeSinceMultipleShot > multipleShotCooldown)
        {
            for (int i = 0; i <= numbersOfBullets; i++)
            {
                Bullet bullet = bulletPoolManager.GetBullet();
                bullet.gameObject.SetActive(true);
                Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle));
                angle += 360 / numbersOfBullets;
            }
            timeSinceMultipleShot = 0;
        }
        timeSinceMultipleShot += Time.deltaTime;
    }
}
