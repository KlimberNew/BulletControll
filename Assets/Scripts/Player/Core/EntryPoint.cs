using NTC.MonoCache;
using UnityEngine;

public class EntryPoint : MonoCache
{
    [SerializeField] private FollowerPlayer followerPlayer;
    private PlayerSpawn playerSpawn => GetComponent<PlayerSpawn>();
    private FirePointSpawn firePointSpawn => GetComponent<FirePointSpawn>();
    private void Start()
    {
        playerSpawn.Init();
        followerPlayer.Init();
        firePointSpawn.Init();
    }
}