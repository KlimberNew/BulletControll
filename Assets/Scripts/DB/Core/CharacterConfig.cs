using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Scriptable Objects/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private GameObject _characterPrefab;
    [SerializeField] private States states;
    public GameObject CharacterPrefab => _characterPrefab;
    public States State => states;
}