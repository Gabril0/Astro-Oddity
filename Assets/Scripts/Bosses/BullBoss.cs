using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class BullBoss : BaseBossBehaviour
{
    private bool isExhausted = true;
    private float rotationTimer = 0.0f;
    [SerializeField] float rotationInterval = 2.0f;
    private float currentRotation = 0f;

    override
    protected void startVariation(){
        speed = player.Speed * 0.75f;
        originalSpeed = speed;
        speed *= 2;
    }
    override
    protected void variation()
    {
        if (!isExhausted)
        {
            rotationTimer += Time.deltaTime;
            if (rotationTimer >= rotationInterval)
            {
                transform.Rotate(0, 0, currentRotation);
                currentRotation += 4;
                if (currentRotation > 360) {
                    rotationTimer = 0f;
                    currentRotation = 0;
                }
            }
            else
            {
                rotateToPosition(transform.position, player.transform.position);
                speed += Time.deltaTime * 4f; // this makes it follow for more time
                if (speed > originalSpeed * 2.0f)
                {
                    speed = originalSpeed * 2.0f;
                    isExhausted = true;
                }
            }
        }
        else
        {
            speed -= Time.deltaTime * 2f; //this makes it recover faster
            if (speed < originalSpeed)
            {
                speed = originalSpeed;
                isExhausted = false;
            }
        }
        animator.SetBool("Exausted", isExhausted);

        if (!isExhausted)
        {
            chase();
        }
    }

    private void chase()
    {
        transform.Translate(speed * Time.deltaTime * Vector2.up);
    }
}
