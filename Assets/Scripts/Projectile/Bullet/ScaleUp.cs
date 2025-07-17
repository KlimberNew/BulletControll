using NTC.MonoCache;
using System.Collections;
using UnityEngine;

public class ScaleUp : MonoCache
{
    [SerializeField] private float growTime;
    [SerializeField] private float maxScale;

    private Transform bullet;
    private Transform player;

    private bool stopRequested = false;
    public void Stop() => stopRequested = true;


    public void Init(Transform bulletTransform, Transform playerTransform)
    {
        bullet = bulletTransform;
        player = playerTransform;
        StartCoroutine(ScaleRoutine());
    }

    private IEnumerator ScaleRoutine()
    {
        float elapsed = 0f;
        Vector3 startBulletScale = bullet.localScale;
        Vector3 targetBulletScale = Vector3.one * maxScale;

        Vector3 startPlayerScale = player.localScale;
        Vector3 targetPlayerScale = startPlayerScale * 0.5f; // уменьшить вдвое

        while (elapsed < growTime && !stopRequested)
        {
            float t = elapsed / growTime;

            // Плавно масштабируем пулю и игрока
            bullet.localScale = Vector3.Lerp(startBulletScale, targetBulletScale, t);
            player.localScale = Vector3.Lerp(startPlayerScale, targetPlayerScale, t);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // Гарантированное финальное значение
        bullet.localScale = targetBulletScale;
        player.localScale = targetPlayerScale;
    }
}