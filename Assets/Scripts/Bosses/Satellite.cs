using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Satellite : Dummy
{
    override
    protected void variationDead() {
        enableEvolution();
    }
}
