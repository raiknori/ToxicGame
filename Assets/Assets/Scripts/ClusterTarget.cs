using UnityEngine;

public class ClusterTarget:TargetThing
{
    int spawnedEnemies = 0;

    public int SpawnedEnemies
    {
        set 
        { 
            spawnedEnemies = value;

            if(spawnedEnemies<=0)
            {
                DestroyCluster();
            }
        }

        get { return spawnedEnemies; }
    }
    private void Start()
    {
        SpawnCluster();
    }

    void SpawnCluster()
    {
        Vector2 clusterPos;
        do
        {
            clusterPos = Utilities.RandomVector2(Border.Instance.spawnRadius);

        } while (Vector2.Distance(new Vector2(0, 0), clusterPos) < 10f);

        Debug.Log($"Cluster with pos: {clusterPos}");

        for (int i = 0; i < UnityEngine.Random.Range(
            1,
            Spawner.Instance.enemyInCluster + 1);
            i++)
        {
            var newPosition = Utilities.RandomVector2(-1, 1);
            Debug.Log($"Enemy in {clusterPos} with pos: {clusterPos + newPosition}");

            Instantiate(Spawner.Instance.enemies.GetRandomItem(), clusterPos + newPosition, Quaternion.identity)
                .GetComponent<Enemy>().clusterTarget = this;
            spawnedEnemies++;
        }

        Spawner.Instance.clusterPositions.Add(clusterPos);
    }

    void DestroyCluster()
    {
        gameObject.GetComponent<TargetPointer>().enabled = false;
    }
}