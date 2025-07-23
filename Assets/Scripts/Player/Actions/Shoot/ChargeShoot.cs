using NTC.MonoCache;
using System;
using UnityEngine;

public class ChargeShoot: MonoCache
{
    [SerializeField] private GameObject bulletPrefab;    
    [SerializeField] private float shootForce = 500f;
    private KeyboardAndMouseControll input => GetComponent<KeyboardAndMouseControll>();
    private FirePoint firePoint => FindFirstObjectByType<PlayerFirePoint>();
    private GameStateController GameStateController => GameManager.Instance.GameStateController;

    private GameObject currentBullet;
    private Rigidbody bulletRb;
    private Player player;
    private Transform playerBody; 
    private States states => player.Config.State;

    public void Init()
    {
        input.OnMouseClick += SpawnBullet;
    }
    private void OnDisable()
    {
        input.OnMouseClick -= SpawnBullet;
    }
    private void OnDestroy()
    {
        input.OnMouseClick -= SpawnBullet;
    }
    private void SpawnBullet()
    {
        if (currentBullet != null) 
            return; // ��� ���� �������� ����

        currentBullet = Instantiate(bulletPrefab, firePoint.transform.position, firePoint.transform.rotation);
        bulletRb = currentBullet.GetComponent<Rigidbody>();
        bulletRb.isKinematic = true; // �������� ������������, ���� ������������

        ChargeActive();
    }
    protected override void Run()
    {
        if(GameStateController.IsState(States.GameStates.GameOver))  return;

        // ���� ������ �������� � ���� �������� � �������
        if (Input.GetMouseButtonUp(0) && currentBullet != null)
            ShootStart();

    }
    private void ShootStart()
    {
        if (currentBullet.TryGetComponent(out ScaleUp scaleUp))
            scaleUp.Stop();

        bulletRb.isKinematic = false;
        bulletRb.AddForce(firePoint.transform.forward * shootForce); // ����������� �� forward
        currentBullet = null;
        bulletRb = null;
    }
    private void ChargeActive() 
    {
        // ����� ������
        ScaleUp scaleUp = currentBullet.GetComponent<ScaleUp>();

        if (scaleUp != null)
            scaleUp.Init(currentBullet.transform, transform); // ������� ���� � ������
    }
}