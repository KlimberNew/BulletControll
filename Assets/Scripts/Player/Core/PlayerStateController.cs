using UnityEngine;
using static States;

public class PlayerStateController
{
    private readonly States stateConfig; // База всех доступных состояний
    private PlayerStates currentState;   // Локальное состояние

    public PlayerStateController(States config)
    {
        stateConfig = config;
        currentState = config.state; // Получаем стартовое состояние из SO
    }

    /// <summary>
    /// Устанавливает новое состояние игрока.
    /// </summary>
    public void SetState(PlayerStates newState)
    {
        if (currentState == newState) return;

        currentState = newState;
        Debug.Log($"[PlayerStateController] SetState: {newState}");
    }

    /// <summary>
    /// Проверяет, находится ли игрок в указанном состоянии.
    /// </summary>
    public bool IsState(PlayerStates stateToCheck)
    {
        return currentState == stateToCheck;
    }

    /// <summary>
    /// Получить текущее состояние.
    /// </summary>
    public PlayerStates GetCurrentState()
    {
        return currentState;
    }
}