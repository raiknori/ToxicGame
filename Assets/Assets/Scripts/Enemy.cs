using UnityEngine;

public abstract class Enemy : MonoBehaviour, IDamageable
{
    protected EnemyState state;
    public EnemyMovementController movementController;
    public float SpotRadius;
    public ClusterTarget clusterTarget;
    private void Start()
    {
        state = new NeutralEnemyState(this);
        state.Enter();
    }
    public void ChangeState(EnemyState newState)
    {
        state.Exit();
        state = newState;
        state.Enter();
    }
    public void Damage()
    {
        ChangeState(new DeathEnemyState(this));
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position,SpotRadius);
    }

    public void DoDestroy()
    {
        Destroy(gameObject);
    }
}
