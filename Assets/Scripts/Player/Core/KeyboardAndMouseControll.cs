using NTC.MonoCache;
using System;
using UnityEngine;

/// <summary>
/// ��������� ����� � ���������� � ����.
/// ���������� ������� ��� ������� ������ � ������ ����.
/// </summary>
public class KeyboardAndMouseControll: MonoCache
{
    public event Action OnMouseClick;
    public event Action OnMouseHold;
    public event Action OnMoveForward;
    public event Action OnMoveBack;
    public event Action OnMoveLeft;
    public event Action OnMoveRight;

    protected override void Run()
    {
        // ������� ����� ������ ����
        if (Input.GetMouseButtonDown(0))
            OnMouseClick?.Invoke();

        if (Input.GetMouseButton(0))
            OnMouseHold?.Invoke();

        // �������� �� WASD
        if (Input.GetKey(KeyCode.W))
            OnMoveForward?.Invoke();

        if (Input.GetKey(KeyCode.S))
            OnMoveBack?.Invoke();

        if (Input.GetKey(KeyCode.A))
            OnMoveLeft?.Invoke();

        if (Input.GetKey(KeyCode.D))
            OnMoveRight?.Invoke();
    }
}