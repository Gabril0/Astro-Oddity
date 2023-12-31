using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullEnemy : Dummy
{
    private GameObject player;
    private Vector2 playerPosition;
    private bool locked = true;
    private bool lockOnPlayer = false;

    void Awake()
    {
        player = GameObject.Find("Player");
    }

    override protected void variation()
    {
        if(lockOnPlayer)
        {
            // playerPosition = player.transform.position;
            rotateToPosition(player.transform.position, transform.position);
            lockOnPlayer = false;
        }
        if (!locked)
        {
            transform.Translate(Vector2.down * speed * Time.deltaTime);
        }
        else
        {
            rotateToPosition(player.transform.position, transform.position);
        }
        if (timeSinceLastShot > bulletCoolDown)
        {
            locked = !locked;
            lockOnPlayer = !lockOnPlayer;
            timeSinceLastShot = 0;
        }
        else
            timeSinceLastShot += Time.deltaTime;
    }

    private bool IsOnBounds()
    {
        float minX = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).x + transform.localScale.x;
        float minY = Camera.main.ScreenToWorldPoint(new Vector3(0, 0, 0)).y + transform.localScale.y;
        float maxX = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, 0, 0)).x - transform.localScale.x;
        float maxY = Camera.main.ScreenToWorldPoint(new Vector3(0, Screen.height, 0)).y - transform.localScale.y;

        if (transform.position.x <= maxX && transform.position.x >= minX
            && transform.position.y <= maxY && transform.position.y >= minY)
            return true;
        
        return false;
    }
}
