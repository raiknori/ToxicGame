using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FoodTarget:TargetThing
{
    private void Start()
    {
        GoalTracker.Instance.FoodToPickUp++;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            GoalTracker.Instance.FoodToPickUp--;
            gameObject.GetComponent<TargetPointer>().enabled = false;   
        }

    }
}
