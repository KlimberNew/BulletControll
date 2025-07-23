using NTC.MonoCache;
using UnityEngine;

public class EntryPoint : MonoCache
{
    [SerializeField] private FollowerPlayer followerPlayer;
    [SerializeField] private MovePlayer movePlayer;
    [SerializeField] private GameManager gameManager;
    [SerializeField] private UiDisplay UiDisplay;
    private PlayerSpawn playerSpawn => GetComponent<PlayerSpawn>();
    private FirePointSpawn firePointSpawn => GetComponent<FirePointSpawn>();
    
    private void Start()
    {
        InitPlayer();
        InitPlayerManipulateSystem();
        InitGameSystems();
    }
    private void InitPlayer()
    {
        playerSpawn.Init();
        followerPlayer.Init();
        firePointSpawn.Init();
    }
    private void InitPlayerManipulateSystem()
    {
        var movePlayerInstance = Instantiate(movePlayer);
        movePlayerInstance.Init(playerSpawn.PlayerLink);
    }
    private void InitGameSystems()
    {
        var gameManagerInstance = Instantiate(gameManager);
        gameManagerInstance.Init(playerSpawn.PlayerLink);
        UiDisplay.Init();
    }
}