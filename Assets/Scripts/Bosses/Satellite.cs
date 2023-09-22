using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : BaseBossBehaviour
{
    

    override
    protected void variation(){
        rotateToPosition( player.transform.position, transform.position);
        multipleShot(10);
        shoot(true);
    }

}
