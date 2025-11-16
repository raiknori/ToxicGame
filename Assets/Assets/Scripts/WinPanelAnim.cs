using System.Collections;
using TMPro;
using UnityEngine;

public class WinPanelAnim : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI winPanelTopText;
    [SerializeField] TextMeshProUGUI winPanelMainText;


    private void OnEnable()
    {
        Debug.Log("DeathPanelAnim");
        StartAnimation();
    }

    void StartAnimation()
    {
        StartCoroutine(Animation());
    }

    IEnumerator Animation()
    {
        //Play anim
        winPanelMainText.text = $"Your raid lasted {Timer.Instance.StartTime-Timer.Instance.time} seconds\n" +
            $"You have picked up {Spawner.Instance.goalsAmount-GoalTracker.Instance.WaterToPickUp} bottles of water\n" +
            $"You have picked up {Spawner.Instance.goalsAmount - GoalTracker.Instance.FoodToPickUp} cans of food";

        yield return new WaitForSeconds(5f);
        Game.Instance.ChangeState(GameStatesType.EndGame);
    }



}
