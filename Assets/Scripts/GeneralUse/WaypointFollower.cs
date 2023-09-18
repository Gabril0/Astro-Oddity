using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointFollower : MonoBehaviour
{
    [SerializeField] private GameObject[] waypoints;
    [SerializeField] private float followerSpeed = 2f;
    private int currentIndex = 0;

    // Update is called once per frame
    void Update()
    {
        if (Vector2.Distance(waypoints[currentIndex].transform.position, transform.position) < .1f)
        {
            currentIndex++;
            if (currentIndex >= waypoints.Length)
                currentIndex = 0;
        }
        transform.position = Vector2.MoveTowards(transform.position, waypoints[currentIndex].transform.position, Time.deltaTime * followerSpeed);
    }
}
