
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalTracker:MonoBehaviour
{
    public static GoalTracker Instance
    {
        get;

        private set;
    }

    private void Awake()
    {
        Instance = this;
    }

    int waterToPickUp = 0;
    int foodToPickUp = 0;
    int clusterToKill = 0;

    Coroutine canWinGame;
    public int WaterToPickUp
    {
        set 
        {
            waterToPickUp = value;
            UI.Instance.WaterPickUpText = $"Water remain: {value}";

            if (waterToPickUp <= 0)
            {
                StartGameWin(); AudioManager.Instance.PlaySound("goalcomplete");
            }

        }

        get { return waterToPickUp; }
    }

    public int FoodToPickUp
    {
        set
        {
            foodToPickUp = value;
            UI.Instance.FoodPickUpText = $"Food remain: {value}";


            if (foodToPickUp <= 0)
            {
                StartGameWin(); AudioManager.Instance.PlaySound("goalcomplete");
            }

        }

        get { return foodToPickUp; }
    }

    public int ClusterToKill
    {
        set
        {
            clusterToKill = value;
            UI.Instance.ClusterToKillText = $"Enemies clusters remain: {value}";


            if (clusterToKill <= 0)
            {
                StartGameWin(); AudioManager.Instance.PlaySound("goalcomplete");
            }

        }

        get { return clusterToKill; }
    }

    void StartGameWin()
    {
        if (canWinGame != null) return;

        canWinGame = StartCoroutine(CheckWinGame());
    }

    IEnumerator CheckWinGame()
    {
        UI.Instance.WarningPanel(true, "You could leave now (Press E)");

        while(true)
        {
            if(Input.GetKeyDown(KeyCode.E))
                Game.Instance.ChangeState(GameStatesType.WinGame);

            yield return null;
        }
    }

}
