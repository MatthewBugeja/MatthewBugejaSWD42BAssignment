using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Obstacle Wave Config")]

public class ObstacleWaveConfig : ScriptableObject
{
    //the obstacle
    [SerializeField] GameObject obstaclePrefab;
    //the path on which to move on
    [SerializeField] GameObject pathPrefab;
    //number of obstacles in the wave
    [SerializeField] int numberOfObstacles = 3;
    //obstacle move speed
    [SerializeField] float obstacleMoveSpeed = 3f;

    //encapsulation methods
    public GameObject GetObstaclePrefab() { return obstaclePrefab; }
    public List<Transform> GetWaypoints()
    {
        //each wave can have different waypoints
        var waveWayPoints = new List<Transform>();

        //go into the Path prefab and for each child, add it to the List waveWaypoints
        foreach (Transform child in pathPrefab.transform)
        {
            waveWayPoints.Add(child);
        }

        return waveWayPoints;
    }
    public int GetNumberOfObstacles() { return numberOfObstacles; }
    public float GetObstacleMoveSpeed() { return obstacleMoveSpeed; }

}
