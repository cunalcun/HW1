using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BaseMoving : MonoBehaviour
{
    public Transform[] waypoints;
    public float moveSpeed = 2f;
    private int currentWaypointIndex = 0;

    void Start()
    {
        if (waypoints.Length > 0)
        {
            transform.position = waypoints[0].position;
        }
    }

    void Update()
    {
        if (waypoints.Length == 0) return;

        MoveTowardsWaypoint();

        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position) < 0.1f)
        {
            GetNextWaypoint();
        }
    }

    private void MoveTowardsWaypoint()
    {
        Vector3 direction = (waypoints[currentWaypointIndex].position - transform.position).normalized;
        transform.position += direction * moveSpeed * Time.deltaTime;

        Quaternion lookRotation = Quaternion.LookRotation(direction);
        transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
    }

    private void GetNextWaypoint()
    {
        currentWaypointIndex = (currentWaypointIndex + 1) % waypoints.Length;
    }
}