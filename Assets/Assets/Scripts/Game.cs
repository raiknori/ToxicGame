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

    public bool IsTutorial = true;

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


    }

    IEnumerator StartGame()
    {

        GameObject.Destroy(game.sceneUi);
        game.CurrentScene = GameObject.Instantiate(game.scenePrefab);

        AudioManager.Instance.PlaySound("glitch");
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

    IEnumerator Tutorial()
    {
        UI.Instance.WarningPanel(true, "You stepped out into a toxic world. You have less than a minute");
        yield return new WaitForSeconds(3f);
        UI.Instance.WarningPanel(true, "Try to complete at least one objective");
        yield return new WaitForSeconds(3f);
        UI.Instance.WarningPanel(true, "The sensor in your mask glows red, pointing toward something worth checking out");
        yield return new WaitForSeconds(4.5f);
        UI.Instance.WarningPanel(false, "");
        game.IsTutorial = false;
    }

    public override void Action()
    {
        if (game.IsTutorial)
        {
            Timer.Instance.time += 10;
            game.StartCoroutine(Tutorial());
        }
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
        UI.Instance.WarningPanel(false, "");
        UI.Instance.WinPanel(true);
        var player = GameObject.FindAnyObjectByType<Player>();
        player.gameObject.SetActive(false);

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
        UI.Instance.WarningPanel(false, "");
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
        UI.Instance.WarningPanel(false,"");
        UI.Instance.WinPanel(false);
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
