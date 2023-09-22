using System.Collections;
using System.Collections.Generic;
using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class BaseBossBehaviour : Dummy
{
    override
    protected void variationDead()
    {
        enableEvolution();
    }
}
