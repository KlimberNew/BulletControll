using UnityEngine;

public class LevelComplite : HUD
{
    private LevelCompliteTrigger trigger;

    public void Init()
    {
        trigger = FindFirstObjectByType<LevelCompliteTrigger>();
        trigger.OnGameStateChanged += ShowUI;
        Debug.Log("TriggerFind: " + trigger);
    }
    private void OnEnable() => trigger.OnGameStateChanged += ShowUI;
    private void OnDisable() => trigger.OnGameStateChanged -= ShowUI;
    private void OnDestroy() => trigger.OnGameStateChanged -= ShowUI;
}