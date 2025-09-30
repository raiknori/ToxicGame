using System.Collections;
using UnityEngine;

public abstract class EnemyState
{
    Coroutine actionCor;
    protected Enemy enemy;
    public EnemyState(Enemy _enemy)
    {
        enemy = _enemy;
    }
        
    public void Enter()
    {
        actionCor = enemy.StartCoroutine(Action());
    }

    public void Exit()
    {
        if(actionCor != null)
            enemy.StopCoroutine(actionCor);
    }

    public abstract IEnumerator Action();
}



public class NeutralEnemyState : EnemyState
{
    Vector3 initialPosition;

    public NeutralEnemyState(Enemy _enemy):base(_enemy) {}
    public override IEnumerator Action()
    {
        initialPosition = enemy.transform.position;

        while (true)
        {
            var allColliders = Physics2D.OverlapCircleAll(enemy.transform.position, enemy.SpotRadius);

            foreach (var col in allColliders)
            {

                if (col.TryGetComponent<Player>(out Player player) == true)
                {
                    enemy.ChangeState(new AggressiveEnemyState(enemy, player)); 
                    yield break;
                }
            }


            yield return null;


            Vector2 newPosition = Utilities.RandomVector2Plus(-2f, 2f, initialPosition);

            yield return enemy.StartCoroutine(enemy.movementController.Move(newPosition));

            yield return new WaitForSeconds(1.5f);
        }
    }
}

public class AggressiveEnemyState : EnemyState
{
    Player player;
    public AggressiveEnemyState(Enemy _enemy, Player _player):base(_enemy)
    {
        player = _player;
    }
    public override IEnumerator Action()
    {
        yield return enemy.StartCoroutine(enemy.movementController.Move(player));

        player.Damage();

        enemy.ChangeState(new NeutralEnemyState(enemy));
    }
}

public class DeathEnemyState : EnemyState
{

    public DeathEnemyState(Enemy _enemy) : base(_enemy) { }

    public override IEnumerator Action()
    {
        enemy.GetComponent<CircleCollider2D>().enabled = false;
        enemy.movementController.Knockback();
        yield return new WaitForSeconds(5f);
        GameObject.Destroy(enemy.gameObject);
    }
}
