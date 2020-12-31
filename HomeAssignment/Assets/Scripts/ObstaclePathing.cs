using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstaclePathing : MonoBehaviour
{
    //a list of type Transform
    [SerializeField] List<Transform> waypoints;
    [SerializeField] float moveSpeed = 5f;
    
    int waypointIndex = 0; //shows in which waypoint the obstacle is in

    // Start is called before the first frame update
    void Start()
    {
        //set the starting position for the obstacle to the 1st waypoint
        transform.position = waypoints[waypointIndex].transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        ObstacleMove();
    }

    void ObstacleMove()
    {
        if (waypointIndex <= waypoints.Count -1)
        {
            //targetPosition - where the obstacle needs to move to next
            var targetPosition = waypoints[waypointIndex].transform.position;

            //make sure that the z position is 0
            targetPosition.z = 0f;

            //set the movement speed per frame
            var obstacleMovement = moveSpeed * Time.deltaTime;

            //move the obstacle from the current position, to the target position, at the movement speed per frame
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, obstacleMovement);

            //if targetPosition is reached
            if (transform.position == targetPosition)
            {
                waypointIndex++;
            }
        }
        //if the enemy reaches the last waypoint
        else
        {
            Destroy(gameObject);
        }
    }
}
