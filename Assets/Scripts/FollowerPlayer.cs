using NTC.MonoCache;
using Unity.VisualScripting;
using UnityEngine;

/// <summary>
/// ��������� ��� ���������� ������ �� �������.
/// �������� ������ � �����.
/// </summary>
public class FollowerPlayer : MonoCache
{
    //�����, ����� �� ����� ������ �������������.    
    [SerializeField] private float followSpeed = 5f;    // ��������� ������ ������ ��������
    [SerializeField] private Vector3 offset = new Vector3(0f, 0f, -10f); // �������� ������ (������� �� Z ��� 2D)

    private Transform playerTransform;
    private Player Player;
    public void Init()
    {
        if (playerTransform == null)
        {
            var player = FindFirstObjectByType<Player>();
            Player = player;

            if (Player != null)
            {
                playerTransform = player.transform;
            }
            else
                Debug.LogWarning("Player �� ������! ������� ��� ������� � ����������.");
        }
    }
    private void Update()
    {
        FollowPlayer();
    }
    private void FollowPlayer() 
    {
        if (playerTransform == null)
            return;

        // ������� �������� � ������� ������ � ������ ��������
        Vector3 targetPosition = playerTransform.position + offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, followSpeed * Time.deltaTime);
    }
}