using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class WaterTarget : TargetThing
{
    private void Start()
    {
        GoalTracker.Instance.WaterToPickUp++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            GoalTracker.Instance.WaterToPickUp--;

            gameObject.GetComponent<TargetPointer>().enabled = false;
        }

    }
}
