using NTC.MonoCache;
using System;
using UnityEngine;

/// <summary>
/// ������� ������ �� ������ ������� KeyboardAndMouseControll.
/// </summary>
public class MovePlayer : MonoCache
{
    [SerializeField] private float moveSpeed = 5f;
    private Vector3 moveDirection;
    private KeyboardAndMouseControll input => GetComponent<KeyboardAndMouseControll>();
    private Rigidbody rb;

    public event Action OnMove;

    public void Init()
    {
        rb = GetComponent<Rigidbody>();
        input.OnMoveForward += () => moveDirection += Vector3.forward;
        input.OnMoveBack += () => moveDirection += Vector3.back;
        input.OnMoveLeft += () => moveDirection += Vector3.left;
        input.OnMoveRight += () => moveDirection += Vector3.right;
    }
    private void Uninit() 
    {
        input.OnMoveForward -= () => moveDirection += Vector3.forward;
        input.OnMoveBack -= () => moveDirection += Vector3.back;
        input.OnMoveLeft -= () => moveDirection += Vector3.left;
        input.OnMoveRight -= () => moveDirection += Vector3.right;
    }
    private void OnEnable() => Init();
    private void OnDisable() => Uninit();
    private void OnDestroy()
    {
        Uninit();
    }
    private void FixedUpdate()
    {
        Move();
    }
    private void Move() 
    {
        if (rb == null) return;

        // ������� ������
        rb.linearVelocity = moveDirection.normalized * moveSpeed;
        moveDirection = Vector3.zero; // ���������� ����� ����������

        OnMove?.Invoke();
    }
}