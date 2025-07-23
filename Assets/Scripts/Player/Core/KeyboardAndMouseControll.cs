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
    protected override void Run()
    {
        // ������� ����� ������ ����
        if (Input.GetMouseButtonDown(0))
            OnMouseClick?.Invoke();

        if (Input.GetMouseButton(0))
            OnMouseHold?.Invoke();
    }
}