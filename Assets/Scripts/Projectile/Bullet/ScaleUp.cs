using NTC.MonoCache;
using System.Collections;
using UnityEngine;

/// <summary>
/// ��������� ��� �������� ���������� ���� (bullet) � �������������� ���������� ������ (player)
/// � ������� ��������� ������� (growTime).
/// ������� ������������� ������� �� ���������� �� ������������� ��������.
/// ��� ���������� ������ ������� ����������� �� ����������� ������.
/// </summary>
public class ScaleUp : MonoCache
{
    // ����� ������� "������" (� ��������), �� ������� ������� ��������� ���������
    [SerializeField] private float growTime;

    // ������������ ������� ���� (player �������������� ����� ������)
    [SerializeField] private float maxScale;

    private Transform bullet; // ������ �� ������ ����
    private Transform player; // ������ �� ������ ������

    private Coroutine scaleRoutine; // �������� ���������������
    private float currentT = 0f; // ������� �������� ������ �� 0 �� 1

    // ��������� � ������� �������� ���������
    private Vector3 startBulletScale;
    private Vector3 targetBulletScale;
    private Vector3 startPlayerScale;
    private Vector3 targetPlayerScale;

    /// <summary>
    /// ������� �������� ��������� ������ (0 � ������ �����, 1 � ��������� ��������).
    /// ����� ������������ ��� �����, �������� � �.�.
    /// </summary>
    public float ChargeProgress => Mathf.Clamp01(currentT); // ����� ���� ������� ��� ����� � �.�.

    /// <summary>
    /// ������������� ��������������� � ��������� ������� �������,
    /// ��������������� �������, ����� �������� ������.
    /// </summary>
    public void Stop()
    {       
        if (scaleRoutine != null)
        {
            StopCoroutine(scaleRoutine); // ������������� ��������
            scaleRoutine = null;

            float t = currentT;

            // ��������� ������� �� ������� t, � �� �������
            bullet.localScale = Vector3.Lerp(startBulletScale, targetBulletScale, t);
            player.localScale = Vector3.Lerp(startPlayerScale, targetPlayerScale, t);
        }
    }

    /// <summary>
    /// ������������� ���������������.
    /// ��������� ������ �� ���� � ������, ����� ����������� ��������.
    /// </summary>
    public void Init(Transform bulletTransform, Transform playerTransform)
    {
        bullet = bulletTransform;
        player = playerTransform;

        // ���������� ��������� ��������
        startBulletScale = bullet.localScale;
        targetBulletScale = Vector3.one * maxScale;

        // ������� ��������
        startPlayerScale = player.localScale;
        targetPlayerScale = startPlayerScale * 0.5f;

        // ��������� ��������
        scaleRoutine = StartCoroutine(ScaleRoutine());
    }

    /// <summary>
    /// ��������, ������ ���������� ������� � ������� ������� growTime.
    /// ������ �������� ����������� ���� � ��������� ������.
    /// </summary>
    private IEnumerator ScaleRoutine()
    {
        float elapsed = 0f;
        currentT = 0f;

        while (elapsed < growTime)
        {
            // �������� �� 0 �� 1
            currentT = elapsed / growTime;

            // ������� ��������������� �� �������� t
            bullet.localScale = Vector3.Lerp(startBulletScale, targetBulletScale, currentT);
            player.localScale = Vector3.Lerp(startPlayerScale, targetPlayerScale, currentT);

            elapsed += Time.deltaTime;
            yield return null;
        }

        // �� ���������� � ����� ������������� ������� �������� � ��������� �����
        currentT = 1f;
        bullet.localScale = targetBulletScale;
        player.localScale = targetPlayerScale;
    }
}