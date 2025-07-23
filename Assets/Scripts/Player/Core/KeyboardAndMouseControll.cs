using NTC.MonoCache;
using System;
using UnityEngine;

/// <summary>
/// Обработка ввода с клавиатуры и мыши.
/// Генерирует события при нажатии клавиш и кнопки мыши.
/// </summary>
public class KeyboardAndMouseControll: MonoCache
{
    public event Action OnMouseClick;
    public event Action OnMouseHold;
    protected override void Run()
    {
        // Нажатие левой кнопки мыши
        if (Input.GetMouseButtonDown(0))
            OnMouseClick?.Invoke();

        if (Input.GetMouseButton(0))
            OnMouseHold?.Invoke();
    }
}