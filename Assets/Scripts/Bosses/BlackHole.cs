using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BlackHole : BaseBossBehaviour
{
    [SerializeField]float gravityForce = 1f;
    private bool shotVariation = true;
    private float stateTransitionTime = 2;
    private float stateTime = 0;
    override
    protected void variation(){
        pullPlayer();
        if (shotVariation) { 
            multipleShotCooldown = 0.5f;
            multipleShot(10); 
        } 
        else{
            multipleShotCooldown = 1f;
            multipleShot(25);
        }

        if (stateTime > stateTransitionTime) { 
            shotVariation = !shotVariation;
            stateTime = 0;
        }
        stateTime += Time.deltaTime;
    }

    private void pullPlayer()
    {
        player.goToPosition(transform.position.x, transform.position.y, gravityForce);
    }
}
