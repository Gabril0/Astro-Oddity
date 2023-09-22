using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
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
