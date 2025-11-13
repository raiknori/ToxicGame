using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner:MonoBehaviour
{

    private void Awake()
    {
        Instance = this;
    }
    public static Spawner Instance
    {
        get;

        private set;
    }

    [SerializeField] public List<GameObject> enemies;
    [SerializeField] GameObject waterPrefab;
    [SerializeField] GameObject foodPrefab;
    [SerializeField] [Range(1, 10)] public int enemyInCluster;
    [SerializeField] [Range(1,20)] public int clustersAmount;
    [SerializeField] [Range(1, 3)] public int goalsAmount;
 
    public List<Vector2> clusterPositions = new List<Vector2>();
    public List<Vector2> goalsPositions = new List<Vector2>();
    private void Start()
    {
        Debug.Log("Debug spawning started!");
        StartSpawning();
    }
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
        GoalTracker.Instance.ClusterToKill = clustersAmount;

        Vector2 clusterPos;
        do
        {
            clusterPos = Utilities.RandomVector2(Border.Instance.spawnRadius);

        } while (Vector2.Distance(new Vector2(0, 0), clusterPos) < 10f);
        
        Debug.Log($"Cluster with pos: {clusterPos}");

        for (int i = 0; i < UnityEngine.Random.Range(
            1,
            enemyInCluster+1); 
            i++)
        {
            var newPosition = Utilities.RandomVector2(-1,1);
            Debug.Log($"Enemy in {clusterPos} with pos: {clusterPos + newPosition}");

            Instantiate(enemies.GetRandomItem(), clusterPos+newPosition, Quaternion.identity, Game.Instance.CurrentScene.transform);
        }

        clusterPositions.Add(clusterPos);
    
    }

    IEnumerator SpawnGoals()
    {


        for(int i = 0; i < goalsAmount; i++)
        {
            var spawnPos = Utilities.RandomVector2(Border.Instance.spawnRadius);
            Instantiate(foodPrefab, spawnPos, Quaternion.identity, Game.Instance.CurrentScene.transform);
            goalsPositions.Add(spawnPos);
        }


        for (int i = 0; i < goalsAmount; i++)
        {
            var spawnPos = Utilities.RandomVector2(Border.Instance.spawnRadius);
            Instantiate(waterPrefab, spawnPos, Quaternion.identity, Game.Instance.CurrentScene.transform);
            goalsPositions.Add(spawnPos);
        }

        yield break;
    }


}
