using System.Collections.Generic;
using UnityEngine;

public class Border:MonoBehaviour
{
    [SerializeField] public Vector2 spawnRadius;
    [SerializeField] Vector2 borderValue;
    [SerializeField] EdgeCollider2D edgeCollider;

    public static Border Instance 
    {
        get;

        private set; 
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Vector2[] points = {
            -borderValue, new Vector2(borderValue.x, -borderValue.y),
            borderValue, new Vector2(-borderValue.x, borderValue.y), -borderValue};

        edgeCollider.points = points;
    }


}