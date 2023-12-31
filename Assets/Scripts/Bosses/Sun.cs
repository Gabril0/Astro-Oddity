using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sun : BaseBossBehaviour
{
    private float stateTime = 0;
    private float stateCooldown = 5;
    private float elapsedTimeState2 = 0;
    private int currentState = 0;

    private float elapsedTimeState1 = 0;
    [SerializeField] BaseEntityScript enemyToSpawn;

    override
    protected void variation()
    {
        stateTime += Time.deltaTime;

        if (stateTime > stateCooldown)
        {
            currentState = Random.Range(1, 5);
            stateTime = 0;
        }
        if (health < 5000) {
            state1();
            state2();
            state3();
        }

        switch (currentState)
        {
            case 1:
                state1();
                break;
            case 2:
                state2();
                break;
            case 3:
                state3();
                break;
            case 4:
                state4();
                break;
            default:
                break;
        }
    }

    private void state1() { //shoot 3 circles of shots that rotate
        multipleShotCooldown = 0.1f;
        elapsedTimeState1 += Time.deltaTime;
        if (elapsedTimeState1 < 0.2f)
        {
            multipleShot(15);
        }
        if (elapsedTimeState1 < 0.3f) {

            multipleShot(10);
            elapsedTimeState1 = 0;
        }

    }

    private void state2(){ //focus the player with fast bullets
        rotateToPosition(player.transform.position, transform.position);
        shoot(true);
        transform.rotation = Quaternion.Euler(0,0,0);
    }

    private void state3(){ //shoots circles of fire while spawning stars
        multipleShotCooldown = 0.3f;
        elapsedTimeState2 += Time.deltaTime;
        multipleShot(15);
        if (elapsedTimeState2 > 2f)
        {
            Instantiate(enemyToSpawn, new Vector3(-0.5f,transform.position.y,transform.position.z),transform.rotation);
            elapsedTimeState2 = 0;
        }
    }

    private void state4() {// combination of 1 and 2
        state1();
        state2();
    }
}
