using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarEnemy : BaseEntityScript
{
    [SerializeField] float amplitude = 5f;
    [SerializeField] float frequency = 0.01f;
    private float angle = 0f;
    private Vector2 position;

    public void Start()
    {
        position.y = transform.position.y;
        position.x = transform.position.x;
    }

    protected override void variation()
    {
        shoot(true);
    }
    private void FixedUpdate()
    {
        float moveX = position.x + (Mathf.Sin(angle * frequency) * amplitude);
        float moveY = position.y +(Mathf.Cos(angle * frequency) * amplitude);

        Vector3 movement = new Vector3(moveX, moveY, 0f) * speed * Time.deltaTime;

        transform.position = movement;

        angle += 10f;
    }
}
