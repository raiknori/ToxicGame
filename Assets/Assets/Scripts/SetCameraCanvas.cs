using System.Collections;
using UnityEngine;

public class SetCameraCanvas : MonoBehaviour
{

    void Start()
    {
        var canvas = GetComponent<Canvas>();
        canvas.worldCamera = Camera.main;
    }


    void Update()
    {
        
    }
}
