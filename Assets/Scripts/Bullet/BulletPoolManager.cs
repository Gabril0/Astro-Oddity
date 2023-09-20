using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    public static BulletPoolManager Instance;

    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int initialPoolSize = 10;

    private BaseEntityScript shooter;
    private float damage;
    private List<Bullet> bulletPool = new List<Bullet>();

    private void Awake()
    {
        shooter = GetComponentInParent<BaseEntityScript>();
        damage = shooter.Damage;

        InitializePool();
    }

    private void InitializePool()
    {
        for (int i = 0; i < initialPoolSize; i++)
        {
            Bullet bullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
            bullet.gameObject.SetActive(false);
            bulletPool.Add(bullet);
        }
    }

    public Bullet GetBullet()
    {
        foreach (Bullet bullet in bulletPool)
        {
            if (!bullet.gameObject.activeInHierarchy)
            {
                bullet.gameObject.SetActive(true);
                bullet.Damage = damage ;
                return bullet;
            }
        }

        //if there isn't inactive bullets found, create a new one.
        Bullet newBullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
        newBullet.Damage = damage;
        bulletPool.Add(newBullet);
        return newBullet;
    }

    public void ReturnBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }

    public void SetBulletType(Bullet newBullet)
    {
        // Change the active bullet type
        foreach (Bullet bullet in bulletPool)
        {
            Destroy(bullet.gameObject);
        }

        bulletPool.Clear();
        bulletPrefab = newBullet;

        // Reinitialize the pool with the new bullet type
        InitializePool();
    }
    public float Damage { get => damage; set => damage = value; }
}
