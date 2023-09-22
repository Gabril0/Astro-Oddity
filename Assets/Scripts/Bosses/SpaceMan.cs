using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpaceMan : BaseBossBehaviour
{
    override
    protected void variation()
    {
        randomMovement();
        rotateToPosition(player.transform.position, transform.position);
        shoot(true);
    }
}
