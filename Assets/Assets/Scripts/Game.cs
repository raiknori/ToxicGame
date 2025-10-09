using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UIElements;


public class Game:MonoBehaviour
{
    GameState state;
    public GameObject scenePrefab;

    public static Game Instance
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
        state = new MenuGameState(this);
    }

    public void ChangeState(GameStatesType stateType)
    {
        switch (stateType)
        {
            case GameStatesType.StartGame:
                state.Exit();
                state = new StartGameState(this);
                state.Enter();
                break;
            case GameStatesType.DieGame:
                state.Exit();
                state = new StartGameState(this);
                state.Enter();
                break;
            case GameStatesType.WinGame:
                state.Exit();
                state = new StartGameState(this);
                state.Enter();
                break;
            case GameStatesType.EndGame:
                state.Exit();
                state = new StartGameState(this);
                state.Enter();
                break;
        }
    }



}

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


    void SetText(TextMeshProUGUI text, string newText)
    {
        //do tween
    }

    private void Awake()
    {
        Instance = this;
    }

}

public abstract class GameState
{
    public void Enter()
    {
        Action();
    }
    public abstract void Action();
    public abstract void Exit();
}


public static class Signal
{
    public static bool StartPressed = false;
}
public class MenuGameState:GameState
{
    Game game;
    public MenuGameState(Game _game)
    {
        game = _game;
    }

    Coroutine menuCoroutine;
    public override void Action()
    {
        Signal.StartPressed = false;
        menuCoroutine = game.StartCoroutine(Menu());

    }

    IEnumerator Menu()
    {
        UI.Instance.StartMenu();

        while (!Signal.StartPressed)
        {
            yield return null;
        }

        game.ChangeState(GameStatesType.StartGame);
    }
    public override void Exit()
    {
        if(menuCoroutine!=null)
            game.StopCoroutine(menuCoroutine);
    }
}

public class StartGameState:GameState
{
    Game game;
    public StartGameState(Game _game) 
    {
        game = _game;
    }

    public override void Action()
    {
        game.StartCoroutine(StartGame());

        
        
        
        
        
        
        
        //Single entry point перемещаем всю сцену в префаб, удаляем со сцены,
        //тут загружаем, запускаем все нужные системы 
        // Желательно чтоб все нужные системы были монобехом на сцене

    }

    IEnumerator StartGame()
    {



        GameObject.Instantiate(game.scenePrefab);
        yield return null;
    }



    public override void Exit()
    {
        throw new NotImplementedException(); 
    }
}

public class WinGameState : GameState
{
    Game game;
    public WinGameState(Game _game)
    {
        game = _game;
    }

    public override void Action()
    {
        Timer.Instance.StopTimer();
        UI.Instance.DeathPanel();
        game.ChangeState(GameStatesType.EndGame);
    }

    public override void Exit()
    {
        
    }
}
public class DieGameState : GameState
{
    Game game;
    public DieGameState(Game _game)
    {
        game = _game;
    }

    public override void Action()
    {
        Timer.Instance.StopTimer();
        UI.Instance.DeathPanel();
        game.ChangeState(GameStatesType.EndGame);

    }
    

    public override void Exit()
    {
        
    }
}

public class EndGameState : GameState
{
    Game game;
    public EndGameState(Game _game)
    {
        game= _game;
    }
    public override void Action()
    {
        game.StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {
        yield return new WaitForSeconds(5f);
        UI.Instance.EndGamePanel();
    }

    public override void Exit()
    {

    }
}
public enum GameStatesType
{
    StartGame,
    DieGame,
    WinGame,
    EndGame
}
