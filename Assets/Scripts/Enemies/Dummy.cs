using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dummy : BaseEntityScript
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("PlayerBullet"))
        {
            float damage = collision.gameObject.GetComponent<Bullet>().Damage;
            health -= damage;
            isHit = true;
        }
    }
}
