using System.Collections;
using UnityEngine;
using UnityEngine.UIElements;

public class EnemyMovementController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] Transform sight;
    public float Speed;

    public IEnumerator Move(Vector3 position)
    {


        while (Vector2.Distance(position, transform.position) > 0.5f)
        {

            Rotate(position);
            Vector2 direction = ((Vector2)position - rb.position).normalized;
            rb.MovePosition(rb.position + direction * Speed);

            yield return new WaitForFixedUpdate();
        }

        yield break;
    }

    public IEnumerator Move<T>(T target) where T : MonoBehaviour
    {


        while (Vector2.Distance(target.transform.position, transform.position) > 0.2f)
        {
            Rotate(target.transform.position);
            Vector2 direction = ((Vector2)target.transform.position - rb.position).normalized;
            rb.MovePosition(rb.position + direction * Speed);

            yield return new WaitForFixedUpdate();
        }


    }

    public void Knockback()
    {
        Vector2 dirFromTarget = (transform.position - sight.position).normalized;
        rb.AddForce(dirFromTarget * UnityEngine.Random.Range(0.1f, 0.3f), ForceMode2D.Impulse);
    }

    void Rotate(Vector3 position)
    {
        rb.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((position.y - transform.position.y),
            (position.x - transform.position.x)) * Mathf.Rad2Deg);
    }
}


