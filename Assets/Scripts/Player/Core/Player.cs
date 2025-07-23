using NTC.MonoCache;
using UnityEngine;

public class Player : MonoCache
{
    [SerializeField] private CharacterConfig characterConfig;
    public CharacterConfig Config => characterConfig;
    public PlayerStateController StateController => new PlayerStateController(Config.State);
}