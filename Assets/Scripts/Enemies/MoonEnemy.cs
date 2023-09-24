using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoonEnemy : Dummy
{
    // Use rotation.z to rotate the enemy and its shoots towards a given point
    [SerializeField] float timeBeforeShoot;
    private Bullet[] bullets = new Bullet[3];
    private WaypointFollower follower;
    private bool state;
    private float timer = 0;

    private void Awake()
    {
        follower = GetComponent<WaypointFollower>();
    }

    override protected void variation()
    {
        if (state)
        {
            shoot();
        }
        else if (timeBeforeShoot > timer)
        {
            follower.Follow();
            timer += Time.deltaTime;
        }
        else
        {
            state = true;
            timer = 0;
        }
    }

    protected void shoot()
    {
        if (timeSinceLastShot > bulletCoolDown)
        {
            float bulletAngle = 270 - 45;
            for (int i = 0; i < 3; i++)
                bullets[i] = bulletPoolManager.GetBullet();
            foreach (Bullet bullet in bullets)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, bulletAngle);
                bullet.gameObject.SetActive(true);
                timeSinceLastShot = 0;

                bulletAngle += 45;
            }
            state = false;
        }
        else
        {
            timeSinceLastShot += Time.deltaTime;
        }
    }
}
