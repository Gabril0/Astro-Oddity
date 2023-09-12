using System.Collections.Generic;
using UnityEngine;

public class BulletPoolManager : MonoBehaviour
{
    public static BulletPoolManager Instance;

    [SerializeField] private Bullet bulletPrefab;
    [SerializeField] private int initialPoolSize = 10;

    private List<Bullet> bulletPool = new List<Bullet>();

    private void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);

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
                return bullet;
            }
        }

        //if there isn't inactive bullets found, create a new one.
        Bullet newBullet = Instantiate(bulletPrefab, Vector3.zero, Quaternion.identity);
        bulletPool.Add(newBullet);
        return newBullet;
    }

    public void setBulletType(Bullet newBullet) {
        bulletPrefab = newBullet;
    }

    public void ReturnBullet(Bullet bullet)
    {
        bullet.gameObject.SetActive(false);
    }
}
