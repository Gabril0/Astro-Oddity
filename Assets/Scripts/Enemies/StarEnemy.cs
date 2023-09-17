using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEnemy : BaseEntityScript
{
    [SerializeField] private float amplitude = 5f;
    [SerializeField] private float frequency = 0.01f;
    [SerializeField] private Vector2 orbitCenter; 
    [SerializeField] private Vector2 movingOrbit;
    private float angle = 0f;

    public void Start()
    {

    }
    protected override void variation()
    {
        // shoot(true);
    }
    private void FixedUpdate()
    {
        Orbit();
        Invoke("ChangeOrbitCenter", 10f);
    }

    private void Orbit()
    {
        float moveX = orbitCenter.x + (Mathf.Sin(angle * frequency) * amplitude);
        float moveY = orbitCenter.y +(Mathf.Cos(angle * frequency) * amplitude);

        Vector3 movement = new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime;

        transform.position = movement;

        angle += 10f;
    }
    private void ChangeOrbitCenter()
    {
        orbitCenter = new Vector2(orbitCenter.x + movingOrbit.x, orbitCenter.y + movingOrbit.y);
    }
}
