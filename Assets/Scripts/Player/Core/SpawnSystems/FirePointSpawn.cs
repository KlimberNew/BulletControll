using NTC.MonoCache;
using UnityEngine;

public class FirePointSpawn : MonoCache
{
    [SerializeField] private Transform parent;
    [SerializeField] private float distance = 1.5f;
    [SerializeField] private GameObject firePoint; 
    private Player player;
    public void Init() 
    {        
        player = FindFirstObjectByType<Player>();
        Instantiate(firePoint, player.transform.localPosition * distance, Quaternion.identity, parent);
    }
}