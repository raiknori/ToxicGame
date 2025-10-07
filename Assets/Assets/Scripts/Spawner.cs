using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner:MonoBehaviour
{
    [SerializeField] List<GameObject> enemies;
    [SerializeField] GameObject waterPrefab;
    [SerializeField] GameObject foodPrefab;
    [SerializeField] [Range(1, 10)] int enemyInCluster;
    [SerializeField] [Range(1,20)] int clustersAmount;
    [SerializeField] [Range(1, 3)] int goalsAmount;
 
    List<Vector2> clusterPositions;
    List<Vector2> goalsPositions;
    public void StartSpawning()
    {
        StartCoroutine(SpawnProcess());
    }
    IEnumerator SpawnProcess()
    {
        yield return StartCoroutine(SpawnEnemies());
        yield return StartCoroutine(SpawnGoals());
        

    }

    IEnumerator SpawnEnemies()
    {

        for(int i = 0; i < clustersAmount; i++)
        {
            SpawnCluster();
        }

        yield break;
    }

    void SpawnCluster()
    {
        var clusterPos = Utilities.RandomVector2(Border.Instance.spawnRadius);

        for(int i = 0; i < UnityEngine.Random.Range(
            1,
            enemyInCluster); 
            i++)
        {
            var newPosition = Utilities.RandomVector2(-1,1);

            var spawnedObj = Instantiate(enemies.GetRandomItem(), clusterPos+newPosition, Quaternion.identity);
        }

        clusterPositions.Add(clusterPos);
    
    }

    IEnumerator SpawnGoals()
    {


        for(int i = 0; i < goalsAmount; i++)
        {
            var spawnPos = Utilities.RandomVector2(Border.Instance.spawnRadius);
            Instantiate(foodPrefab, spawnPos, Quaternion.identity);
            goalsPositions.Add(spawnPos);
        }


        for (int i = 0; i < goalsAmount; i++)
        {
            var spawnPos = Utilities.RandomVector2(Border.Instance.spawnRadius);
            Instantiate(waterPrefab, spawnPos, Quaternion.identity);
            goalsPositions.Add(spawnPos);
        }

        yield break;
    }


}
