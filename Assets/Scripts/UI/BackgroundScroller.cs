using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundScroller : MonoBehaviour
{
    [SerializeField] float scrollSpeed;
    [SerializeField] float minXPosition;

    private void Update()
    {
        scroll();
    }
    private void scroll()
    {
        // Calculate the new position based on scroll speed
        Vector3 newPosition = transform.position + Vector3.left * scrollSpeed * Time.deltaTime;

        // Check if the new position is beyond the minimum X position (out of bounds)
        if (newPosition.x < minXPosition)
        {
            // Stop scrolling by clamping the X position to the minimum value
            newPosition.x = minXPosition;
        }

        // Update the position of the background
        transform.position = newPosition;
    }
}
