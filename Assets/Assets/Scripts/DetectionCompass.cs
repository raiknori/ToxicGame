
using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.UI;

public class DetectionCompass:MonoBehaviour
{
    [SerializeField] Image imageTop;
    [SerializeField] Image imageBottom;
    [SerializeField] Image imageRight;
    [SerializeField] Image imageLeft;
    [SerializeField][Range(0.1f,2f)] float flashSpeed = 0.1f;

    public List<Vector2> pointOfInterests = new List<Vector2>();

    IEnumerator Flashing()
    {
        while(true)
        {

            if (pointOfInterests.Count < 1)
                yield break;

            var nearestPoint = pointOfInterests.OrderBy(x => Vector2.Distance(transform.position, x)).FirstOrDefault();

            Vector2 direction = nearestPoint - (Vector2)transform.position;

            if (Mathf.Abs(direction.x) > Mathf.Abs(direction.y))
            {
                if (direction.x > 0)
                    yield return Flash(imageRight);
                else
                    yield return Flash(imageLeft);
            }
            else
            {
                if (direction.y > 0)
                    yield return Flash(imageTop);
                else
                    yield return Flash(imageBottom);
            }

            yield return new WaitForSeconds(3f);
        }



    }

    YieldInstruction Flash(Image img)
    {
        var baseColor = img.color;

        return DOTween.Sequence().Append(img.DOColor(new Color(0.85f, 0.25f, 0.22f, 0.3f), flashSpeed))
            .Append(img.DOColor(baseColor,flashSpeed)).WaitForCompletion();


    }



    public void StartFlashing(List<Vector2> points)
    {
        pointOfInterests.AddRange(points.ToArray());

        StartCoroutine(Flashing());
    }

}