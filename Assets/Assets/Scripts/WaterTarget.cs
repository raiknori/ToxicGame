using UnityEngine;

[RequireComponent(typeof(Collider2D))]
public class WaterTarget: MonoBehaviour
{
    private void Start()
    {
        GoalTracker.Instance.WaterToPickUp++;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<Player>() != null)
        {
            GoalTracker.Instance.WaterToPickUp--;
            Destroy(gameObject);



        }
    }
}
