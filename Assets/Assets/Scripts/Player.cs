using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using TMPro;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Splines;
using UnityEngine.UIElements;

public class Player : MonoBehaviour, IDamageable
{


    public void Damage()
    {
        Game.Instance.ChangeState(GameStatesType.DieGame);
    }

    void Start()
    {

    }


    void Update()
    {

    }
}


