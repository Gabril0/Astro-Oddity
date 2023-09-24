using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MirrorEnemy : BaseEntityScript
{
    private GameObject player;

    private void Awake()
    {
        player = GameObject.Find("Player");
    }

    override protected void variation()
    {
        rotateToPosition(player.transform.position, transform.position);
    }
    protected void shoot()
    {
        Bullet bullet = bulletPoolManager.GetBullet();
        bullet.transform.position = transform.position;
        bullet.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, -90);
        bullet.gameObject.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            float damage = collision.gameObject.GetComponent<Bullet>().Damage;
            health -= damage;
            isHit = true;

            shoot();
        }
    }
}
