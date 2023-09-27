using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class MirrorEnemy : BaseEntityScript
{
    override protected void variation()
    {
        rotateToPosition(player.transform.position, transform.position);
    }
    protected void shoot()
    {
        audioSource.clip = shootSound;
        audioSource.Play();
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
