using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseBossBehaviour : Dummy
{
    [SerializeField] bool triggerEvolution = false;
    override
    protected void variationDead()
    {
        if(triggerEvolution) enableEvolution();
    }
}
