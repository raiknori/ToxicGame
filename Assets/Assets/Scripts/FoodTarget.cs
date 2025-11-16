using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class FoodTarget:MonoBehaviour
{
    private void Start()
    {
        GoalTracker.Instance.FoodToPickUp++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            GoalTracker.Instance.FoodToPickUp--;
            AudioManager.Instance.PlaySound("pickup");
            Destroy(gameObject);
        }

    }
}

