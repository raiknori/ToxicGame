
using System.Collections;
using UnityEngine;
using UnityEngine.Events;

public class Timer:MonoBehaviour
{
    public UnityEvent onTime30Percent;
    public UnityEvent onTime50Percent;
    public UnityEvent onTime75Percent;
    public UnityEvent onTime90Percent;
    public UnityEvent onTime95Percent;

    [SerializeField][Range(10f, 240f)] public float time;

    Coroutine timerCoroutine;
    Coroutine timeDecrasingCoroutine;
    public static Timer Instance
    {
        get;

        private set;
    }

    private void Awake()
    {
        Instance = this;
    }

    public void StartTimer()
    {
        timerCoroutine = StartCoroutine(TimerCore());
    }

    public void StopTimer()
    {
        if (timerCoroutine != null)
            StopCoroutine(timerCoroutine);

        if(timeDecrasingCoroutine != null)
            StopCoroutine(timeDecrasingCoroutine);
    }

    IEnumerator TimerCore()
    {
        timeDecrasingCoroutine = StartCoroutine(TimeDecreasing());

        yield return new WaitForSeconds(time*0.1f); //10%
        EnableMarkers();
        yield return new WaitForSeconds(time * 0.2f); //20%
        onTime30Percent?.Invoke();
        yield return new WaitForSeconds(time * 0.2f); //50%
        onTime50Percent?.Invoke();
        yield return new WaitForSeconds(time * 0.25f); //70%
        onTime75Percent?.Invoke();
        yield return new WaitForSeconds(time * 0.2f); //90%
        onTime90Percent?.Invoke();
        yield return new WaitForSeconds(time * 0.05f); //90%
        onTime95Percent?.Invoke();
        yield return new WaitForSeconds(time * 0.05f); //100%
        Game.Instance.ChangeState(GameStatesType.DieGame);

    }

    IEnumerator TimeDecreasing()
    {

        while(time>0)
        {
            time--;
            UI.Instance.UpdateTime(time);
            yield return new WaitForSeconds(1f);
        }
    }

    void EnableMarkers()
    {
        var targetThings = FindObjectsByType<TargetThing>(FindObjectsSortMode.None);
        foreach (var tt in targetThings)
        {
            tt.CreateTargetPointer();
        }
    }

    private void Start()
    {
        Debug.LogWarning("DEBUG: Timer started by debug");
        StartTimer();

        //remove when game start ready
    }
}

