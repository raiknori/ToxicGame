using System.Collections;
using UnityEngine;

public class AttackController : MonoBehaviour
{
    [SerializeField] Transform firePoint;


    bool isCooldown = false;
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && !isCooldown)
            Attack();
    }

    [SerializeField] float rangeDistance;
    [SerializeField] LayerMask hitMask;
    void Attack()
    {
        AudioManager.Instance.PlaySound("shot",true);
        StartCoroutine(CoolDown());

        RaycastHit2D hit = Physics2D.Raycast(firePoint.position, firePoint.right, rangeDistance, hitMask);
        Vector2 endPos= firePoint.position + firePoint.right*rangeDistance;


        if (hit.collider != null)
        {
            endPos = hit.point;

            IDamageable damageable = hit.collider.GetComponent<IDamageable>();
            if(damageable != null)
            {
                damageable.Damage();
                AudioManager.Instance.PlaySound("death_impact", true);
                Debug.Log($"Hit");
            }


            SparkEffect();
        }

        StartCoroutine(VisualizeLine(firePoint.position, endPos));

    }

    [SerializeField] ParticleSystem sparkParticle;
    void SparkEffect()
    {
        //sparkParticle.Play();
    }

    [SerializeField] LineRenderer lineRenderer;
    IEnumerator VisualizeLine(Vector3 start, Vector3 end)
    {
        lineRenderer.SetPosition(0, start);
        lineRenderer.SetPosition(1, end);

        lineRenderer.enabled = true;
        yield return new WaitForSeconds(0.05f);
        lineRenderer.enabled = false;
    }

    [SerializeField] float coolDownTime;
    public IEnumerator CoolDown()
    {
        isCooldown = true;
        yield return new WaitForSecondsRealtime(coolDownTime);
        AudioManager.Instance.PlaySound("reload");
        isCooldown = false;
    }
}

