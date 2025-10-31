using UnityEngine;
using UnityEngine.Rendering;

public class LensDistorManager : MonoBehaviour
{
    [SerializeField] Volume lensDistorVolume;
    public float speed;

    private void Start()
    {
        //speed = 2 * Mathf.PI/Timer.Instance.time;
        speed = Mathf.PI / (2f * 120f);
    }
    void Update()
    {
        float t = (Mathf.Sin(Time.time * speed) + 1f) / 2f;
        lensDistorVolume.weight = Mathf.Lerp(0,1,t);
    }
}
