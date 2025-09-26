using System.Collections.Generic;
using System.ComponentModel;
using Unity.VisualScripting;
using UnityEngine;

public class Player : MonoBehaviour, IDamageable
{

    public void Damage()
    {
        Debug.Log("Damage player");
    }

    void Start()
    {

    }


    void Update()
    {

    }
}
