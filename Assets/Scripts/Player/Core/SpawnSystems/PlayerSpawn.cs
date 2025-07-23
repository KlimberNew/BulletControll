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
    public Player PlayerLink {  get; private set; }
    public void Init()
    {
        // ������� ��� ������ ������
        spawnedPlayer = Instantiate(playerConvert, spawnPoint.transform.position, Quaternion.identity);

        // ������� ������� ��� ������ ��� ������������� ������
        spawnedSkin = Instantiate(characterConfig.CharacterPrefab, spawnedPlayer.transform.position, Quaternion.identity, spawnedPlayer.transform);

        Player = spawnedPlayer.GetComponent<Player>();
                
        Player.GetComponent<ChargeShoot>().Init();
        Player.GetComponent<ScaleHP>().Init();

        PlayerLink = Player;
    }
}