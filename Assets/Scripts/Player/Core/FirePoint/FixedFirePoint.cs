using NTC.MonoCache;
using UnityEngine;

public class FixedFirePoint : MonoCache
{
    [SerializeField] private float distance = 5f;
    private Player player => FindFirstObjectByType<Player>();
    private Transform playerBody => player.GetComponent<Transform>();
    private Transform firePoint => GetComponent<Transform>();

    protected override void Run()
    {
        if (firePoint == null || playerBody == null)
            return;

        // �������: ������ ������������ ���� ������
        firePoint.position = new Vector3(playerBody.position.x, playerBody.position.y, playerBody.position.z);

        // �������: ��������� �� Y, ��������� ���������
        Vector3 euler = playerBody.eulerAngles;
        firePoint.rotation = Quaternion.Euler(euler.x, euler.y, euler.z);
    }
}