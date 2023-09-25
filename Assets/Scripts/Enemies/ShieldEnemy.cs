using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldEnemy : Dummy
{
    override protected void variation()
    {
        rotateToPosition(player.transform.position, transform.position);
    }
}
