using NTC.MonoCache;
using System.Collections;
using UnityEngine;

/// <summary>
/// Компонент для плавного увеличения пули (bullet) и одновременного уменьшения игрока (player)
/// в течение заданного времени (growTime).
/// Масштаб увеличивается линейно от начального до максимального значения.
/// При отпускании кнопки масштаб фиксируется на достигнутом уровне.
/// </summary>
public class ScaleUp : MonoCache
{
    // Время полного "заряда" (в секундах), за которое масштаб достигает максимума
    [SerializeField] private float growTime;

    // Максимальный масштаб пули (player масштабируется вдвое меньше)
    [SerializeField] private float maxScale;

    private Transform bullet; // ссылка на объект пули
    private Transform player; // ссылка на объект игрока

    private Coroutine scaleRoutine; // корутина масштабирования
    private float currentT = 0f; // текущий прогресс заряда от 0 до 1

    // Начальные и целевые значения масштабов
    private Vector3 startBulletScale;
    private Vector3 targetBulletScale;
    private Vector3 startPlayerScale;
    private Vector3 targetPlayerScale;

    /// <summary>
    /// Текущее значение прогресса заряда (0 — только начал, 1 — полностью заряжено).
    /// Можно использовать для урона, скорости и т.п.
    /// </summary>
    public float ChargeProgress => Mathf.Clamp01(currentT); // может быть полезно для урона и т.п.

    /// <summary>
    /// Останавливает масштабирование и фиксирует текущий масштаб,
    /// соответствующий моменту, когда отпущена кнопка.
    /// </summary>
    public void Stop()
    {       
        if (scaleRoutine != null)
        {
            StopCoroutine(scaleRoutine); // останавливаем корутину
            scaleRoutine = null;

            float t = currentT;

            // Применяем масштаб на текущем t, а не целевой
            bullet.localScale = Vector3.Lerp(startBulletScale, targetBulletScale, t);
            player.localScale = Vector3.Lerp(startPlayerScale, targetPlayerScale, t);
        }
    }

    /// <summary>
    /// Инициализация масштабирования.
    /// Передаётся ссылка на пулю и игрока, затем запускается корутина.
    /// </summary>
    public void Init(Transform bulletTransform, Transform playerTransform)
    {
        bullet = bulletTransform;
        player = playerTransform;

        // Запоминаем начальные масштабы
        startBulletScale = bullet.localScale;
        targetBulletScale = Vector3.one * maxScale;

        // Целевые масштабы
        startPlayerScale = player.localScale;
        targetPlayerScale = startPlayerScale * 0.5f;

        // Запускаем корутину
        scaleRoutine = StartCoroutine(ScaleRoutine());
    }

    /// <summary>
    /// Корутина, плавно изменяющая масштаб в течение времени growTime.
    /// Каждую итерацию увеличивает пулю и уменьшает игрока.
    /// </summary>
    private IEnumerator ScaleRoutine()
    {
        float elapsed = 0f;
        currentT = 0f;

        while (elapsed < growTime)
        {
            // Прогресс от 0 до 1
            currentT = elapsed / growTime;

            // Плавное масштабирование по текущему t
            bullet.localScale = Vector3.Lerp(startBulletScale, targetBulletScale, currentT);
            player.localScale = Vector3.Lerp(startPlayerScale, targetPlayerScale, currentT);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // По завершении — точно устанавливаем целевые значения и фиксируем заряд
        currentT = 1f;
        bullet.localScale = targetBulletScale;
        player.localScale = targetPlayerScale;
    }
}