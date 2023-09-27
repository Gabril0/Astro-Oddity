using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaveCountDeleter : MonoBehaviour
{
    private BaseEntityScript entity;
    void Start()
    {
        entity = GetComponent<BaseEntityScript>();
        entity.IsCounted = false;
    }

}
