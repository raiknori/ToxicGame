using System;
using TMPro;
using UnityEngine;


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
        
    }

    public void ChangeState(GameStatesType stateType)
    {
        switch (stateType)
        {
            case GameStatesType.StartGame:
                state = new StartGameState(this);
                break;
            case GameStatesType.DieGame:
                state = new StartGameState(this);
                break;
            case GameStatesType.WinGame:
                state = new StartGameState(this);
                break;
            case GameStatesType.EndGame:
                state = new StartGameState(this);
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

public class MenuGameState:GameState
{
    public override void Action()
    {

    }
    public override void Exit()
    {

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
        
        GameObject.Instantiate(game.scenePrefab);
        
        
        
        
        
        
        
        //Single entry point перемещаем всю сцену в префаб, удаляем со сцены,
        //тут загружаем, запускаем все нужные системы 
        // Желательно чтоб все нужные системы были монобехом на сцене

    }




    public override void Exit()
    {
        throw new NotImplementedException(); 
    }
}

public enum GameStatesType
{
    StartGame,
    DieGame,
    WinGame,
    EndGame
}
