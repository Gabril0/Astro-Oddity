using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BaseEntityScript
{
    protected override void variation()
    {
        rotateToPosition((Camera.main.ScreenToWorldPoint(Input.mousePosition)), transform.position);
        shoot(Input.GetMouseButton(0));
        move();
    }
    private void move() {
        float verticalMovement = Input.GetAxisRaw("Vertical");
        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0).normalized * speed * Time.deltaTime;
        transform.Translate(movement, Space.World); //this is for it not to move weirdly with the cursor as an orbit
    }
}
