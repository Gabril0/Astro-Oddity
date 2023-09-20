using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireEnemy : Dummy
{
    [SerializeField] private float shootCoolDown = 2;
    [SerializeField] private float numberOfSpirals = 1;
    private float bulletAngle = 0;
    // Update is called once per frame
    override protected void variation()
    {
        shoot(bulletAngle < 360 * numberOfSpirals);
        if (timeSinceLastShot > shootCoolDown)
            bulletAngle = 0;
    }

    override
    protected void shoot(bool conditionToShoot)
    {
        
        if (conditionToShoot && timeSinceLastShot > bulletCoolDown)
        {
            
            Bullet bullet = bulletPoolManager.GetBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, bulletAngle);
            bullet.gameObject.SetActive(true);
            timeSinceLastShot = 0;

            bulletAngle += 10;
        }
        else
        {
            timeSinceLastShot += Time.deltaTime;
        }
    }
}
