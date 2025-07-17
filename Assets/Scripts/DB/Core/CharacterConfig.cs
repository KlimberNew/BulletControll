using UnityEngine;

[CreateAssetMenu(fileName = "CharacterConfig", menuName = "Scriptable Objects/CharacterConfig")]
public class CharacterConfig : ScriptableObject
{
    [SerializeField] private GameObject _characterPrefab;

    public GameObject CharacterPrefab => _characterPrefab;
}