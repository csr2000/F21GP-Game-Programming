using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Waypoint : MonoBehaviour
{
    //Making the platform move between two empty objects called waypoint1,2
    //Declaring an array of gameobjects
    [SerializeField] GameObject[] waypoints;
    int currentWaypointIndex = 0;

    //Speed at which to move between the waypoints
    [SerializeField] float speed = 1f;

    // Update is called once per frame
    void Update()
    {
        //Check towards which waypoint to move towards next. In order to do so check for distance between current waypoint and platform.
        if (Vector3.Distance(transform.position, waypoints[currentWaypointIndex].transform.position) < .1f)
        {
            //If platform reached waypoint 1 we need to switch to the next waypoint. 
            currentWaypointIndex++;
            //When the index reaches max limit we need to switch back to waypoint 1.
            if (currentWaypointIndex >= waypoints.Length)
            {
                currentWaypointIndex = 0;
            }
        }
        //to change platform position (transform.positon)
        //MoveTowards calculates the new position between two objects(current platform position, desitination, speed)
        transform.position = Vector3.MoveTowards(transform.position, waypoints[currentWaypointIndex].transform.position, speed * Time.deltaTime);
    }
}
