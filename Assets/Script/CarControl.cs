using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{
    private Transform[] waypoints;
    public float speed = 10f;  
    public float rotationSpeed = 5f; 
    public float destroyDistance = 1f; 
    private int currentWaypointIndex = 0;
    private Quaternion initialRotation;

    public void SetWaypoints(Transform[] newWaypoints)
    {
        waypoints = newWaypoints;
        initialRotation = Quaternion.Euler(-90f, transform.rotation.eulerAngles.y, transform.rotation.eulerAngles.z);
        transform.rotation = initialRotation;
    }

    void Update()
    {
        if (waypoints != null && waypoints.Length > 0)
        {
            MoveAlongWaypoints();
        }
    }

    void MoveAlongWaypoints()
    {
        float distance = Vector3.Distance(transform.position, waypoints[currentWaypointIndex].position);

        if (distance <= destroyDistance)
        {
            currentWaypointIndex++;
            if (currentWaypointIndex >= waypoints.Length)
            {
                Destroy(gameObject);
                return;
            }
        }

        Vector3 targetDirection = waypoints[currentWaypointIndex].position - transform.position;
        targetDirection.Normalize();

        Quaternion targetRotation = Quaternion.LookRotation(targetDirection);
        targetRotation = Quaternion.Euler(transform.rotation.eulerAngles.x, targetRotation.eulerAngles.y, transform.rotation.eulerAngles.z); // X√‡ ∞Ì¡§

        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, rotationSpeed * Time.deltaTime);

        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].position, speed * Time.deltaTime);
    }
}
