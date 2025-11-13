using System;
using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.UIElements;


public class Game:MonoBehaviour
{
    GameState state;
    public GameObject scenePrefab;
    public GameObject sceneUi;

    GameObject currentScene;
    public GameObject CurrentScene
    {
        get {  return currentScene; }

        set
        {
            if(currentScene != null)
            {
                Destroy(currentScene);
            }

            currentScene = value;   
        }
    }

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
        state.Enter();

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
            case GameStatesType.PlayingGame:
                state.Exit();
                state = new PlayingGameState(this);
                state.Enter();
                break;
            case GameStatesType.DieGame:
                state.Exit();
                state = new DieGameState(this);
                state.Enter();
                break;
            case GameStatesType.WinGame:
                state.Exit();
                state = new WinGameState(this);
                state.Enter();
                break;
            case GameStatesType.EndGame:
                state.Exit();
                state = new EndGameState(this);
                state.Enter();
                break;
        }
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
        menuCoroutine = game.StartCoroutine(Menu());

    }

    IEnumerator Menu()
    {

        while (!(Input.anyKeyDown))
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

        GameObject.Destroy(game.sceneUi);
        game.CurrentScene = GameObject.Instantiate(game.scenePrefab);

        game.ChangeState(GameStatesType.PlayingGame);
        yield return null;
    }



    public override void Exit()
    {

    }
}

public class PlayingGameState:GameState
{
    Game game;
    public PlayingGameState(Game _game)
    {
        game = _game;
    }

    public override void Action()
    {

    }

    public override void Exit()
    {

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
        Debug.Log("WinGame state");
        Timer.Instance.StopTimer();
        UI.Instance.DeathPanel(true);
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
        UI.Instance.DeathPanel(true);
        var player = GameObject.FindAnyObjectByType<Player>();
        player.gameObject.SetActive(false);

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
        UI.Instance.DeathPanel(false);
        UI.Instance.EndGamePanel(true);
        game.StartCoroutine(EndGame());
    }

    IEnumerator EndGame()
    {

        while (!(Input.anyKeyDown))
        {
            yield return null;
        }

        game.ChangeState(GameStatesType.StartGame);
    }

    public override void Exit()
    {

    }
}
public enum GameStatesType
{
    StartGame,
    PlayingGame,
    DieGame,
    WinGame,
    EndGame
}
