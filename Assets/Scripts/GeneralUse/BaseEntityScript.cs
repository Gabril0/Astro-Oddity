using System;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UI;
using static Unity.Burst.Intrinsics.X86.Sse4_2;

public class BaseEntityScript : MonoBehaviour
{
    [SerializeField] protected float speed = 10;
    [SerializeField] protected float health = 680;
    [SerializeField] protected float damage = 100;
    [SerializeField] protected float bulletCoolDown = 0.2f;

    //healthBar related
    private RectTransform healthBarPosition;
    [SerializeField] Image healthBarImage;
    [SerializeField] protected GameObject healthBarBG;
    private float healthBarDistance = 0.75f;

    //base interactions
    private bool isAlive = true;
    protected float originalSpeed;
    protected float originalHealth; 
    protected float lastDamageValue;
    private bool isSlowedDownShooting = false;
    private Collider2D collider2d;
    protected PlayerMovement player;

    //bullet related
    protected float timeSinceLastShot = 0;
    protected BulletPoolManager bulletPoolManager;

    //sprite flash effect
    protected SpriteRenderer spriteRenderer;
    [SerializeField] protected float flashHitEffectDuration = 0.2f;
    private Color flashColor = Color.red;
    protected Color originalColor;
    protected bool isFlashing = false;
    protected bool isHit = false;

    //explosion effect related
    [SerializeField] protected Animator animator;
    private float explosionTime = 0;

    //Wave admin related
    WaveManager waveManager;

    //Evolution trigger
    private GameManager gameManager;

    //Multiple bullet
    [SerializeField] protected float multipleShotCooldown = 1;

    //Random move
    [SerializeField] float movementCooldown = 1;
    [SerializeField] float movementDuration = 1;
    private Vector2 moveDirection = Vector2.zero;
    private float timeSinceMultipleShot = 0;
    private bool isMoving = false;
    private float currentTime = 0f;

    //Sound Effects
    protected AudioSource audioSource;
    void Start()
    {
        originalSpeed = speed;
        originalHealth = health;
        lastDamageValue = damage;
        bulletPoolManager = GetComponent<BulletPoolManager>();
        bulletPoolManager.Damage = damage;

        gameManager = GameObject.Find("GameManager").GetComponent<GameManager>();


        spriteRenderer = GetComponent<SpriteRenderer>();
        originalColor = spriteRenderer.color;

        healthBarPosition = healthBarBG.GetComponent<RectTransform>();

        collider2d = GetComponent<Collider2D>();
        collider2d.enabled = false;

        waveManager = GameObject.Find("WaveManager").GetComponent<WaveManager>();

        player = GameObject.Find("Player").GetComponent<PlayerMovement>();

        animator.SetBool("Explosion", false);

        audioSource = GetComponent<AudioSource>();

        startVariation();

        StartCoroutine(EnableColliderAfterDelay(1.0f)); //this works for the Player not get hit while the enemies are spawning
    }

    void Update()
    {
        if (IsAlive)
        {
            variation();
            checkBounds();
            checkHealth();
            checkDamage(); 
            checkHit();
        }
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
    protected virtual void shoot(bool conditionToShoot)
    {
        if (isSlowedDownShooting && conditionToShoot) { slowDown(); }
        else if(isSlowedDownShooting && !conditionToShoot) { restoreSpeed(); }
        if (conditionToShoot && timeSinceLastShot > bulletCoolDown)
        {
            Bullet bullet = bulletPoolManager.GetBullet();
            bullet.transform.position = transform.position;
            bullet.transform.rotation = transform.rotation * Quaternion.Euler(0, 0, -90);
            bullet.gameObject.SetActive(true);
            timeSinceLastShot = 0;

        }
        else
        {
            timeSinceLastShot += Time.deltaTime;
        }
    }
    private void checkHealth()
    {
        Vector3 screenPos = Camera.main.WorldToViewportPoint(transform.position);

        float verticalOffset = (screenPos.y <= 0.5f) ? healthBarDistance : -healthBarDistance;

        Vector3 offset = new Vector3(0, verticalOffset, 0);
        healthBarPosition.position = transform.position + offset;
        healthBarPosition.rotation = Quaternion.Euler(0, 0, 0);

        healthBarImage.fillAmount = Mathf.Clamp01(health / originalHealth);
        if (health > 1000)
        {
            healthBarImage.color = Color.yellow;
            if (CompareTag("Enemy")) healthBarDistance = 1.5f;
        }

        if (health <= 0)
        {
            //Time.timeScale = 0.5f; //slowdown effect
            //if(explosionTime > 0.5f){
             //   Time.timeScale = 1;
            //}
            collider2d.enabled = false;
            playDeathAnimation();
            IsExplosionOver();
        }
    }

    private void playDeathAnimation() {
        animator.SetBool("Explosion", true);
    }

    private void IsExplosionOver()
    {
        AnimatorStateInfo currentState = animator.GetCurrentAnimatorStateInfo(0);
        float animationLength = currentState.length;
        if (explosionTime > animationLength) {
            explosionEnd();
        }
        explosionTime += Time.deltaTime;

    }
    private void explosionEnd() {
        IsAlive = false;
        variationDead();
        if (CompareTag("Enemy")) {
            waveManager.enemyDefeated();
        }
        Destroy(gameObject);
    }
    protected void rotateToPosition(Vector3 position1, Vector3 position2)
    { //use it to rotate to the cursor or to some other point
        Vector3 direction = position1 - position2;

        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        transform.rotation = Quaternion.AngleAxis(angle + 90, Vector3.forward);
    }
    protected void slowDown()
    {
        speed = originalSpeed * 0.5f;
    }
    protected void restoreSpeed()
    {
        speed = originalSpeed;
    }
    private void checkHit() {
        if (isHit)
        {
            StartCoroutine(FlashSprite());
            isHit = false;
        }
    }
    protected void checkDamage() {
        if (damage != lastDamageValue) {
            bulletPoolManager.Damage = damage;
            lastDamageValue = damage;
        }
    }
    private IEnumerator FlashSprite()
    {
        if (isFlashing) yield break; // If already flashing, exit the coroutine

        isFlashing = true; // Set the flashing flag to true

        spriteRenderer.color = flashColor;

        float flashStartTime = Time.time;

        while (Time.time < flashStartTime + flashHitEffectDuration)
        {
            yield return null;
        }

        spriteRenderer.color = originalColor;
        isFlashing = false;
    }

    private IEnumerator EnableColliderAfterDelay(float delay)
    {
        yield return new WaitForSeconds(delay);
        collider2d.enabled = true; // Enable the collider after the delay
    }

    protected void enableEvolution() {
        gameManager.PlayerCanEvolute = true;
    }

    protected void multipleShot(int numbersOfBullets)
    {//function that shoots the number of bullet specified in an equal angle
        float angle = 360 / numbersOfBullets;
        if (timeSinceMultipleShot > multipleShotCooldown)
        {
            for (int i = 0; i <= numbersOfBullets; i++)
            {
                Bullet bullet = bulletPoolManager.GetBullet();
                bullet.gameObject.SetActive(true);
                Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, angle));
                angle += 360 / numbersOfBullets;
            }
            timeSinceMultipleShot = 0;
        }
        timeSinceMultipleShot += Time.deltaTime;
    }

    protected void randomMovement()
    {
        if (!isMoving)
        {
            if (currentTime >= movementCooldown)
            {
                isMoving = true;
                currentTime = 0f;
                moveDirection = UnityEngine.Random.insideUnitCircle.normalized; 
            }
        }
        else
        {
            transform.Translate(moveDirection * speed * Time.deltaTime);        

            if (currentTime >= movementDuration)
            {
                isMoving = false;
                currentTime = 0f;
            }
        }
        currentTime += Time.deltaTime;
    }

    public void goToPosition(float x, float y, float speed) { //goes to the position comparing to the current object position
        Vector3 currentPosition = transform.position;
        Vector3 targetPosition = new Vector3(x, y, currentPosition.z);

        float distance = Vector3.Distance(currentPosition, targetPosition);
        float realSpeed = distance * speed;

        Vector3 direction = (targetPosition - currentPosition).normalized;
        transform.position += direction * realSpeed * Time.deltaTime;
    }

    public void SetIsHit()
    {
        isHit = true;
    }
    protected virtual void variation() {}
    protected virtual void variationDead() {    }
    protected virtual void startVariation() { }
    public float Speed { get => speed; set => speed = value; }
    public float Health { get => health; set => health = value;}
    public float Damage { get => damage; set => damage = value; }
    public float BulletCoolDown { get => bulletCoolDown; set => bulletCoolDown = value; }
    public bool IsSlowedDownShooting { get => isSlowedDownShooting; set => isSlowedDownShooting = value; }
    public bool IsAlive { get => isAlive; set => isAlive = value; }
}
