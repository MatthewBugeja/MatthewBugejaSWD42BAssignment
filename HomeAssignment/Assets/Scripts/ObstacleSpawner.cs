using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleSpawner : MonoBehaviour
{
    //a list of type ObstacleWaveConfig
    [SerializeField] List<ObstacleWaveConfig> waveConfigs;
    //set looping to flase
    [SerializeField] bool looping = false;

    //always starting from Wave 0
    int startingWave = 0;

    // Start is called before the first frame update
    IEnumerator Start()
    {
        //set the currentWave to 0 (1st Wave)
        var currentWave = waveConfigs[startingWave];

        //loop all waves until looping == true
        do
        {
            //start coroutine that spawns all enemies in waves
            yield return StartCoroutine(SpawnAllWaves());
        }
        while (looping); //while (looping == true)
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private IEnumerator SpawnAllObstaclesInWave(ObstacleWaveConfig waveConfigToSet)
    {
        //spawns an enemy until obstacleCount == GetNumberOfObstacles()
        for (int obstacleCount = 0; obstacleCount < waveConfigToSet.GetNumberOfObstacles(); obstacleCount++)
        {
            //spawn the obstacle from waveConfig at the position specified by the waveConfig waypoints
            var newObstacle = Instantiate(waveConfigToSet.GetObstaclePrefab(), waveConfigToSet.GetWaypoints()[0].transform.position, Quaternion.identity);

            //the wave will be selected from here and the obstacle applied to it
            newObstacle.GetComponent<ObstaclePathing>().SetWaveConfig(waveConfigToSet);

            yield return new WaitForSeconds(waveConfigToSet.GetTimeBetweenSpawns());
        }        
    }

    private IEnumerator SpawnAllWaves()
    {
        foreach (ObstacleWaveConfig currentWave in waveConfigs)
        {
            //the coroutine will wait for all obstacles in Wave to spawn before yielding and going to the next loop
            yield return StartCoroutine(SpawnAllObstaclesInWave(currentWave));
        }
    }
}
