using UnityEngine;

public class RotationController:MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;

    Vector3 mousePosition;

    private void FixedUpdate()
    {
        Rotate();
    }
    void Rotate()
    {
        mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y,
            Input.mousePosition.z - Camera.main.transform.position.z));

        rb.transform.eulerAngles = new Vector3(0, 0, Mathf.Atan2((mousePosition.y - transform.position.y),
            (mousePosition.x - transform.position.x)) * Mathf.Rad2Deg);
    }


}