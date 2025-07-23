using NTC.MonoCache;
using System;
using UnityEngine;

public class GameManager : MonoCache
{
    public static GameManager Instance { get; private set; }

    [SerializeField] private States states;
    public GameStateController GameStateController {  get; set; }
    public bool LevelEndedTrig {  get; set; }
    public bool GameOverTrig { get; set; }

    private PlayerStateController PlayerStateController;
    private Player Player;
    private ScaleHP scaleHP;

    public event Action OnGameOver;

    public void Init(Player player)
    {
        InitSingleton();

        Player = player;
        scaleHP = Player.GetComponent<ScaleHP>();
        GameStateController = new GameStateController(states);
        PlayerStateController = Player.StateController;

        //Debug.Log("Scale HP in GameManager: " + scaleHP);
        //Debug.Log("States " + states.gameState);
    }
    private void InitSingleton()
    {
        // Singleton инициализация
        if (Instance != null && Instance != this)
        {
            Debug.LogWarning("GameManager already exists! Destroying duplicate.");
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
    }

    protected override void Run()
    {
        if (!LevelEndedTrig)
            ObserveHP();
        else
            VictoryTrigger();        
    }
    private void ObserveHP()
    {
        if (scaleHP == null) return;

        if (scaleHP.HP <= scaleHP.CriticalEdge || GameOverTrig)
        {
            GameStateController.SetState(States.GameStates.GameOver);
            PlayerStateController.SetState(States.PlayerStates.Stop);
            OnGameOver?.Invoke();
        }
        else
        {
            GameStateController.SetState(States.GameStates.Play);
            PlayerStateController.SetState(States.PlayerStates.Move);
        }


        //Debug.Log("Player HP in GameManager: " + scaleHP.HP);
    }
    private void VictoryTrigger()
    {
        GameStateController.SetState(States.GameStates.LevelEnd);
    }
    
}