using UnityEngine;

public class ClusterTarget
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

    void DestroyCluster()
    {
        GoalTracker.Instance.ClusterToKill--;
    }
}