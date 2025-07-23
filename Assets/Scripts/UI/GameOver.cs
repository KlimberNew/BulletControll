using UnityEngine;

public class GameOver : HUD
{
    public void Init()
    {
        GameManager.Instance.OnGameOver += ShowUI;
    }
    private void OnEnable()
    {
        GameManager.Instance.OnGameOver += ShowUI;
    }
    private void OnDisable()
    {
        GameManager.Instance.OnGameOver -= ShowUI;
    }
    private void OnDestroy()
    {
        GameManager.Instance.OnGameOver -= ShowUI;
    }
}