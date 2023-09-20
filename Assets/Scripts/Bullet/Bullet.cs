using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;
    private float damage = 100;

    public float Damage { get => damage; set => damage = value; }

    void Update()
    {
        if (gameObject.activeSelf) {
            transform.Translate(Vector2.right * Time.deltaTime * speed); //right because the bullet images are in a different direction from the shooter sprite
            changeSize();
            CheckBounds();
        }
    }

    private void changeSize() {
        // Change bullet scale based on shooter damage
        float scale = Mathf.Clamp(damage / 100f, 0.5f, 20f); // Adjust the range as needed
        transform.localScale = new Vector3(scale, scale, 1f);
    }
    private void CheckBounds()
    {
        //gets the "size" of the screen
        float minX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x - transform.localScale.x;
        float minY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y - transform.localScale.y;
        float maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x + transform.localScale.x;
        float maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y + transform.localScale.y;

        //check if the bullet is outside the screen bounds
        if (transform.position.x < minX || transform.position.x > maxX || transform.position.y < minY || transform.position.y > maxY)
        {
            gameObject.SetActive(false);
        }
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Player") && this.CompareTag("EnemyBullet")) {
            this.gameObject.SetActive(false);
        }
        if (collision.CompareTag("Enemy") && this.CompareTag("PlayerBullet"))
        {
            this.gameObject.SetActive(false);
        }
    }
}
