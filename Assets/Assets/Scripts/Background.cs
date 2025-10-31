using UnityEngine;

public class Background : MonoBehaviour
{
    public Camera cam;
    public Color colorA;
    public Color colorB;
    public float speed = 1.0f;


    private void Start()
    {
        cam = Camera.main;
    }
    void Update()
    {
        float t = (Mathf.Sin(Time.time * speed) + 1f) / 2f;
        cam.backgroundColor = Color.Lerp(colorA, colorB, t);
    }
}