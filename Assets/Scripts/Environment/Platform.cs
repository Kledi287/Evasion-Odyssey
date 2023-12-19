using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.AI;

public class Platform : MonoBehaviour
{
    [SerializeField] private float speed = 2f;
    private List<Transform> waypoints;
    private int targetWaypointIndex = 0;
    private Transform targetWaypoint;
    private bool isForward = true;

    void Start()
    {
        waypoints = GameObject.FindGameObjectsWithTag("PlatformWP")
                                .Select(go => go.transform)
                                .ToList();
        Debug.Log("Collected waypoints: " + waypoints.Count);

        if (waypoints.Count > 0)
        {
            targetWaypoint = waypoints[targetWaypointIndex];
        }
    }

    void Update()
    {
        if (targetWaypoint == null) return;

        transform.position = Vector3.MoveTowards(transform.position, targetWaypoint.position, speed * Time.deltaTime);

        // Check if the platform has reached the target waypoint
        if (Vector3.Distance(transform.position, targetWaypoint.position) < 0.1f)
        {
            // Switch to the next waypoint
            if (isForward)
            {
                targetWaypointIndex++;
                if (targetWaypointIndex >= waypoints.Count)
                {
                    targetWaypointIndex -= 2;
                    isForward = false;
                }
            }
            else
            {
                targetWaypointIndex--;
                if (targetWaypointIndex < 0)
                {
                    targetWaypointIndex = 1;
                    isForward = true;
                }
            }
            targetWaypoint = waypoints[targetWaypointIndex];
        }
    }
}


