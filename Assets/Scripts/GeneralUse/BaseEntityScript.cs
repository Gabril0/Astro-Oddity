using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseEntityScript : MonoBehaviour
{
    [SerializeField] protected float speed = 10;
    [SerializeField] protected float health = 680;
    [SerializeField] protected float damage = 100;
    [SerializeField] protected float bulletCoolDown = 0.2f;

    protected bool isAlive = true;
    protected float originalSpeed;

    private bool isSlowedDownShooting = false;

    //bullet related
    protected float timeSinceLastShot = 0;
    protected BulletPoolManager bulletPoolManager;

    void Start()
    {
        originalSpeed = speed;
        bulletPoolManager = GetComponent<BulletPoolManager>();
    }

    void Update()
    {
        if (isAlive)
        {
            checkBounds();
            checkHealth();
            variation(); //this is where you put all the class specific methods
        }
        else variationDead(); //just  an alternative in case the class needs it
    }
    private void checkBounds()
    {
        Vector3 newPosition = transform.position;

        //gets the "size" of the screen
        float minX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + transform.localScale.x;
        float minY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y + transform.localScale.y;
        float maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - transform.localScale.x;
        float maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - transform.localScale.y;

        //clamp the player's position within the screen bounds
        newPosition.x = Mathf.Clamp(newPosition.x, minX, maxX);
        newPosition.y = Mathf.Clamp(newPosition.y, minY, maxY);

        transform.position = newPosition;
    }
    protected void shoot(bool conditionToShoot)
    {
        if (conditionToShoot && timeSinceLastShot > bulletCoolDown)
        {
            if (isSlowedDownShooting) { slowDown(); }
            Bullet bullet = bulletPoolManager.GetBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, -90);
            bullet.gameObject.SetActive(true);
            timeSinceLastShot = 0;
        }
        else
        {
            restoreSpeed();
            timeSinceLastShot += Time.deltaTime;
        }
    }
    private void checkHealth()
    {
        if (health <= 0)
        {
            isAlive = false;
        }
    }
    protected void rotateToPosition(Vector3 position1, Vector3 position2)
    { //use it to rotate to the cursor or to some other point
        Vector3 direction = position1 - position2;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }
    protected void slowDown()
    {
        speed = speed * 0.5f; //the ideal use would be like player.slowDown(player.getSpeed/2)
    }
    protected void restoreSpeed()
    {
        speed = originalSpeed;
    }
    protected virtual void variation() {}
    protected virtual void variationDead() {}
    public float Speed { get => speed; set => speed = value; }
    public float Health { get => health; set => health = value; }
    public float Damage { get => damage; set => damage = value; }
    public float BulletCoolDown { get => bulletCoolDown; set => bulletCoolDown = value; }
    public bool IsSlowedDownShooting { get => isSlowedDownShooting; set => isSlowedDownShooting = value; }
}
