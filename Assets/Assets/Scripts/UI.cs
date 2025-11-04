using System.Collections;
using System.Text;
using TMPro;
using UnityEngine;

public class UI:MonoBehaviour
{
    public static UI Instance
    {
        get;

        private set;
    }

    float endGameSlider = 0.0f;
    public float EndGameSlider
    {
        set { endGameSlider = value; }

        get { return endGameSlider; }
        
    }

    [SerializeField] TextMeshProUGUI waterPickUpText;
    [SerializeField] TextMeshProUGUI foodPickUpText; 
    [SerializeField] TextMeshProUGUI clusterToKillText;
    [SerializeField] TextMeshProUGUI timeLeftText;


    public string WaterPickUpText
    {
        set 
        {
            SetText(waterPickUpText, value);
        }
        get {  return waterPickUpText.text; }
    }

    public string FoodPickUpText
    {
        set
        {
            SetText(foodPickUpText, value);
        }
        get { return foodPickUpText.text; }
    }


    public string ClusterToKillText
    {
        set
        {
            SetText(clusterToKillText, value);
        }
        get { return clusterToKillText.text; }
    }


    public void UpdateTime(float time)
    {
        SetText(timeLeftText, $"O2: {time}",0.3f);
    }


    public void StartMenu()
    {

    }

    public void DeathPanel()
    {

    }

    public void WinPanel()
    {

    }

    public void EndGamePanel()
    {

    }


    void SetText(TextMeshProUGUI text, string newText, float duration = 1.5f)
    {
        StartCoroutine(ShakeEffect(duration,text,newText));

            
    }

    IEnumerator ShakeEffect(float duration, TextMeshProUGUI text, string newText)
    {
        var rect = text.rectTransform;
        var startPos = rect.anchoredPosition;

        float time = 0f;

        text.text = newText;

        while (time < duration)
        {

            rect.anchoredPosition = startPos + new Vector2(
                Random.Range(-2f, 2f),
                Random.Range(-2f, 2f)
            );

            time += 0.05f;
            yield return new WaitForSeconds(0.05f);
        }
        rect.anchoredPosition = startPos;
    }

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        Timer.Instance.onTime75Percent.AddListener(AlarmMoment);
    }

    void AlarmMoment()
    {
        timeLeftText.color = new Color(1f, 0.364f, 0.329f);
    }

}


