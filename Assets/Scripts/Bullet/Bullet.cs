using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] float speed;

    private void Start()
    {
    }
    void Update()
    {
        if (gameObject.activeSelf) { 
            transform.Translate(Vector2.right * Time.deltaTime * speed); //right because the bullet images are in a different direction from the player sprite

            CheckBounds();
        }
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
}
