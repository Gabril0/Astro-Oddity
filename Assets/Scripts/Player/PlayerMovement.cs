using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : BaseEntityScript
{
    [SerializeField] Animator animator;

    //transformation
    [SerializeField] float transformationDurantion = 10;
    [SerializeField] float transformationCooldown = 10;
    private bool isTransformed = false;
    private float timeTransformed = 0;
    private float lastTimeSinceTransformation = 12;
    protected override void variation()
    {
        animationStuff();
        rotateToPosition((Camera.main.ScreenToWorldPoint(Input.mousePosition)), transform.position);
        shoot(Input.GetMouseButton(0));
        move();
    }
    private void animationStuff() {
        if (Input.GetMouseButton(0)) animator.SetBool("isShooting", true);
        else animator.SetBool("isShooting", false);
        animator.SetBool("isTransformed", isTransformed);
    }
    private void move() {
        float verticalMovement = Input.GetAxisRaw("Vertical");
        float horizontalMovement = Input.GetAxisRaw("Horizontal");

        transformation();

        Vector3 movement = new Vector3(horizontalMovement, verticalMovement, 0).normalized * speed * Time.deltaTime;
        transform.Translate(movement, Space.World); //this is for it not to move weirdly with the cursor as an orbit
    }

    private void transformation() {
        if (timeTransformed < transformationDurantion && isTransformed)
        {
            timeTransformed += Time.deltaTime;
        }
        else if(isTransformed)
        {
            timeTransformed = 0;
            lastTimeSinceTransformation = 0;
            isTransformed = false;
            damage *= 0.5f;
            bulletCoolDown *= 2f;
            speed *= 0.75f;
        }
        if (Input.GetKeyDown(KeyCode.F) && (timeTransformed < transformationDurantion) && (lastTimeSinceTransformation > transformationCooldown) && !isTransformed)
        {
            isTransformed = true;
            damage *= 2;
            bulletCoolDown *= 0.5f;
            speed *= 1.25f;

        }
        Debug.Log(timeTransformed);
        lastTimeSinceTransformation += Time.deltaTime;
    }
}
