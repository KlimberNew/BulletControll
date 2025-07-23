using UnityEngine;
using static States;

public class GameStateController
{
    private readonly States stateConfig; // ���� ���� ��������� ���������
    private GameStates currentState;   // ��������� ���������

    public GameStateController(States config)
    {
        stateConfig = config;
        currentState = config.gameState; // �������� ��������� ��������� �� SO
    }
    /// <summary>
    /// ������������� ����� ��������� ������.
    /// </summary>
    public void SetState(GameStates newState)
    {
        if (currentState == newState) return;

        currentState = newState;
        Debug.Log($"[PlayerStateController] SetState: {newState}");
    }

    /// <summary>
    /// ���������, ��������� �� ����� � ��������� ���������.
    /// </summary>
    public bool IsState(GameStates stateToCheck)
    {
        return currentState == stateToCheck;
    }

    /// <summary>
    /// �������� ������� ���������.
    /// </summary>
    public GameStates GetCurrentState()
    {
        return currentState;
    }
}