using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AlienBoss : BaseBossBehaviour
{
    private int choice = 0;
    private float stateTransitionTime = 4;
    private float stateTimeElapsed = 0;

    private float teleportCooldown = 2;
    private float teleportTimeElapsed = 0;

    override
    protected void variation(){
        rotateToPosition(player.transform.position, transform.position);
        stateTimeElapsed += Time.deltaTime;

        if (stateTimeElapsed > stateTransitionTime)
        {
            choice = Random.Range(0, 10);
            stateTimeElapsed = 0; 
        }

        if (choice % 2 == 0)
        {
            state1();
        }
        else
        {
            state2();
        }
    }

    private void state1()//goes around quickly and shoots normally
    {
        shoot(true);
        randomMovement();
    }

    private void state2()//teleports to the sides of the screen and shoots multiple shots
    {
        shoot(false);
        
        teleportTimeElapsed += Time.deltaTime; 

        if (teleportTimeElapsed > teleportCooldown)
        {
            teleport(1);
            teleportTimeElapsed = 0; 
            multipleShot(15);
        }
        else
        {
            teleport(2);
            multipleShot(15);
            teleportTimeElapsed = 0;
        }
    }

    private void teleport(int signal){
        if (signal == 1)
        {
            transform.Translate(new Vector2(7, 0) * Time.deltaTime * speed);
        }
        if (signal == 2)
        {
            transform.Translate(new Vector2(-7, 0) * Time.deltaTime * speed);
        }
    }
}
