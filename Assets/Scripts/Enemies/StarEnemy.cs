using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEnemy : BaseEntityScript
{
    [SerializeField] private float amplitude = 5f;
    [SerializeField] private float frequency = 0.01f;
    [SerializeField] private Vector2 orbitCenter; 
    [SerializeField] private Vector2 movingOrbit;
    private float angle = 0f;
    private Bullet[] bullets = new Bullet[5];
    private float bulletAngle = 90;

    public void Start()
    {
        bulletPoolManager = GetComponent<BulletPoolManager>();
    }
    private void FixedUpdate()
    {
        Orbit();
        starShoot(true);
    }

    protected void starShoot(bool conditionToShoot)
    {
        if (conditionToShoot && timeSinceLastShot > bulletCoolDown)
        {
            for (int i = 0; i < 5; i++)
                bullets[i] = bulletPoolManager.GetBullet();
            foreach (Bullet bullet in bullets)
            {
                bullet.transform.position = transform.position;
                bullet.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, bulletAngle);
                bullet.gameObject.SetActive(true);
                timeSinceLastShot = 0;

                bulletAngle += 360 / 5;
            }
        }
            else
            timeSinceLastShot += Time.deltaTime;
    }
    private void Orbit()
    {
        float moveX = orbitCenter.x + (Mathf.Sin(angle * frequency) * amplitude);
        float moveY = orbitCenter.y +(Mathf.Cos(angle * frequency) * amplitude);

        Vector3 movement = new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime;

        transform.position = movement;

        angle += 10f;
    }
    // Uncomment if want to use the function
    // private void ChangeOrbitCenter()
    // {
    //     orbitCenter = new Vector2(orbitCenter.x + movingOrbit.x, orbitCenter.y + movingOrbit.y);
    // }
}