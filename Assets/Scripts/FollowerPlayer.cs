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
    private MovePlayer movePlayer;
    public void Init()
    {
        if (playerTransform == null)
        {
            var player = FindFirstObjectByType<Player>();
            Player = player;

            if (Player != null)
            {
                playerTransform = player.transform;
                movePlayer = Player.GetComponent<MovePlayer>();
                movePlayer.OnMove += FollowPlayer;
            }
            else
                Debug.LogWarning("Player �� ������! ������� ��� ������� � ����������.");
        }
    }
    private void OnEnable()
    {
        if(movePlayer != null)
            movePlayer.OnMove += FollowPlayer;
    }
    private void OnDisable()
    {
        movePlayer.OnMove -= FollowPlayer;
    }
    private void OnDestroy()
    {
        movePlayer.OnMove -= FollowPlayer;
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