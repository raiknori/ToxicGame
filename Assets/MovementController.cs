using UnityEngine;

public class MovementController : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float speed;
    

    Vector2 inputMoving;
    public void Move()
    {
        Vector2 movevelocity;

        movevelocity = inputMoving.normalized * speed;
        rb.MovePosition(rb.position + movevelocity);
    }

    public void Update()
    {
        inputMoving = new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical"));
    }

    public void FixedUpdate()
    {
        Move();
    }

}

