using UnityEngine;

[CreateAssetMenu(fileName = "States", menuName = "Scriptable Objects/States")]
public class States : ScriptableObject
{
    public enum PlayerStates
    {
        Stop,
        Move,
        Charging
    }
    public PlayerStates state;
    public enum GameStates
    {
        Play,
        LevelEnd,
        GameOver
    }
    public GameStates gameState;
}