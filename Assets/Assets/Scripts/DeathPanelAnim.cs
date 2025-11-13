using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;

public class DeathPanelAnim : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI deathTopText;
    [SerializeField] TextMeshProUGUI deathBottomText;
    [SerializeField] Image scullIcon;


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
        yield return new WaitForSeconds(5f);
        Game.Instance.ChangeState(GameStatesType.EndGame);
    }

    

}
