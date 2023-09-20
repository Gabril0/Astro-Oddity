using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BaseEntityScript
{

    private bool isShooting = false;

    //transformation
    [SerializeField] Bullet playerBullet;
    [SerializeField] Bullet transformationBullet;
    [SerializeField] float transformationDurantion = 10;
    [SerializeField] float transformationCooldown = 10;
    private bool isTransformed = false;
    private float timeTransformed = 0;
    private float lastTimeSinceTransformation = 12;

    private bool usingNormalBullet = true, usingTransformationBulllet = false;
    protected override void variation()
    {
        animationStuff();
        rotateToPosition((Camera.main.ScreenToWorldPoint(Input.mousePosition)), transform.position);
        move();
        shoot(isShooting);
        healthBarHide();
    }
    private void animationStuff() {
        animator.SetBool("isShooting", isShooting);
        animator.SetBool("isTransformed", isTransformed);
    }
    private void move() {
        float verticalMovement = Input.GetAxisRaw("Vertical");
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        isShooting = Input.GetMouseButton(0);

        changeBullet();
        transformation();
        
        Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0).normalized * speed * Time.deltaTime;
        transform.Translate(movement, Space.World); //this is for it not to move weirdly with the cursor as an orbit
    }

    private void transformation() {
        if (timeTransformed < transformationDurantion && isTransformed)
        {
            timeTransformed += Time.deltaTime;
        }
        else if(isTransformed)
        {
            timeTransformed = 0;
            lastTimeSinceTransformation = 0;
            isTransformed = false;
            damage *= 0.5f;
            bulletCoolDown *= 2f;
            speed *= 0.75f;
        }
        if (Input.GetKeyDown(KeyCode.F) && (timeTransformed < transformationDurantion) && (lastTimeSinceTransformation > transformationCooldown) && !isTransformed)
        {
            float shootRotation = 0;
            isTransformed = true;
            damage *= 2;
            bulletCoolDown *= 0.5f;
            speed *= 1.25f;
            for (int i = 0; i < 20; i++) {
                Bullet bullet = bulletPoolManager.GetBullet();
                bullet.gameObject.SetActive(true);
                Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, shootRotation));
                shootRotation += 18;
            }

        }
        if (timeTransformed < 1.3f && isTransformed) {
            isShooting = false;
        }
        lastTimeSinceTransformation += Time.deltaTime;
    }

    private void changeBullet() {
        if (usingNormalBullet && isTransformed) {
            bulletPoolManager.SetBulletType(transformationBullet);
            usingNormalBullet = false;
            usingTransformationBulllet = true;
        }
        if (!isTransformed && usingTransformationBulllet) {
            bulletPoolManager.SetBulletType(playerBullet);
            usingTransformationBulllet = false;
            usingNormalBullet = true;
        }
    }

    private void healthBarHide() {
        healthBarBG.SetActive(isFlashing);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {

        if (collision.collider.CompareTag("Enemy"))
        {
            float damage = collision.gameObject.GetComponent<BaseEntityScript>().Damage;
            health -= damage;
            isHit = true;
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("EnemyBullet"))
        {
            float damage = collision.gameObject.GetComponent<Bullet>().Damage;
            health -= damage;
            isHit = true;
        }
    }
}
