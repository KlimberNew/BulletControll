using System;
using UnityEngine;
using static States;

public class LevelCompliteTrigger : MonoBehaviour
{
    public event Action OnGameStateChanged;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.TryGetComponent<Player>(out Player player))
        {
            GameManager.Instance.LevelEndedTrig = true;            
            Debug.Log("Level end!");
            OnGameStateChanged?.Invoke();
        }
    }
}