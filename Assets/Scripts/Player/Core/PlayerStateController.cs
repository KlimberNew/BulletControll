using UnityEngine;
using static States;

public class PlayerStateController
{
    private readonly States stateConfig; // ���� ���� ��������� ���������
    private PlayerStates currentState;   // ��������� ���������

    public PlayerStateController(States config)
    {
        stateConfig = config;
        currentState = config.state; // �������� ��������� ��������� �� SO
    }

    /// <summary>
    /// ������������� ����� ��������� ������.
    /// </summary>
    public void SetState(PlayerStates newState)
    {
        if (currentState == newState) return;

        currentState = newState;
        Debug.Log($"[PlayerStateController] SetState: {newState}");
    }

    /// <summary>
    /// ���������, ��������� �� ����� � ��������� ���������.
    /// </summary>
    public bool IsState(PlayerStates stateToCheck)
    {
        return currentState == stateToCheck;
    }

    /// <summary>
    /// �������� ������� ���������.
    /// </summary>
    public PlayerStates GetCurrentState()
    {
        return currentState;
    }
}