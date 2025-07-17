using NTC.MonoCache;
using UnityEngine;

public class PlayerSpawn : MonoCache
{
    [SerializeField] private CharacterConfig characterConfig;
    [SerializeField] private GameObject playerConvert;
    [SerializeField] private GameObject spawnPoint;

    private GameObject spawnedSkin;
    private GameObject spawnedPlayer;
    private Player Player;
    public void Init()
    {
        // Спавним сам объект игрока
        spawnedPlayer = Instantiate(playerConvert, spawnPoint.transform.position, Quaternion.identity);

        // Спавним внешний вид внутрь уже заспавненного игрока
        spawnedSkin = Instantiate(characterConfig.CharacterPrefab, spawnedPlayer.transform.position, Quaternion.identity, spawnedPlayer.transform);

        Player = spawnedPlayer.GetComponent<Player>();
        Player.GetComponent<MovePlayer>().Init();
        Player.GetComponent<ChargeShoot>().Init();
    }
}