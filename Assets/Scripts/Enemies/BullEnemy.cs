using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BullEnemy : BaseEntityScript
{
    private GameObject player;
    private Vector2 playerPosition;
    private bool locked = true;
    private bool lockOnPlayer = false;

    void Start()
    {
        player = GameObject.Find("Player");
    }

    override protected void variation()
    {
        if(lockOnPlayer)
        {
            playerPosition = player.transform.position;
            lockOnPlayer = false;
        }
        if (!locked)
        {
            transform.position = Vector2.MoveTowards(transform.position, playerPosition, Time.deltaTime * speed);
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
