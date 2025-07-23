using UnityEngine;
using static States;

public class GameStateController
{
    private readonly States stateConfig; // База всех доступных состояний
    private GameStates currentState;   // Локальное состояние

    public GameStateController(States config)
    {
        stateConfig = config;
        currentState = config.gameState; // Получаем стартовое состояние из SO
    }
    /// <summary>
    /// Устанавливает новое состояние игрока.
    /// </summary>
    public void SetState(GameStates newState)
    {
        if (currentState == newState) return;

        currentState = newState;
        Debug.Log($"[PlayerStateController] SetState: {newState}");
    }

    /// <summary>
    /// Проверяет, находится ли игрок в указанном состоянии.
    /// </summary>
    public bool IsState(GameStates stateToCheck)
    {
        return currentState == stateToCheck;
    }

    /// <summary>
    /// Получить текущее состояние.
    /// </summary>
    public GameStates GetCurrentState()
    {
        return currentState;
    }
}