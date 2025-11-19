
using UnityEngine;

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


