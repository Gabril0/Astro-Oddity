using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateObject : MonoBehaviour
{
    [SerializeField] float rotationSpeed = 10;
    void Update()
    {
        transform.Rotate(new Vector3(0,0,rotationSpeed) * Time.deltaTime);
    }
}
