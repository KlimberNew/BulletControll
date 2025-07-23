using NTC.MonoCache;
using UnityEngine;

/// <summary>
/// Двигает игрока автоматически вперед.
/// </summary>
public class MovePlayer : MonoCache
{
    [SerializeField] private float moveSpeed = 5f;

    private Vector3 moveDirection;    
    private Rigidbody rb;
    private Player Player;
    private PlayerStateController PlayerStateController;
    private GameStateController GameStateController => GameManager.Instance.GameStateController;

    public void Init(Player player)
    {
        Player = player;
        rb = Player.GetComponent<Rigidbody>();
        PlayerStateController = Player.StateController;
        PlayerStateController.SetState(States.PlayerStates.Move);
        //Debug.Log("player " + Player + " rb " + rb);
    } 
    private void FixedUpdate()
    {
        if (GameStateController.IsState(States.GameStates.Play))
            Move();
        else
            StopMoving();
    }
    private void Move() 
    {        
        if (rb == null && PlayerStateController.IsState(States.PlayerStates.Move)) return;
               
        // Двигаем игрока
        moveDirection = Vector3.forward;
        rb.linearVelocity = moveDirection.normalized * moveSpeed;
    }
    private void StopMoving()
    {
        moveDirection = Vector3.zero;
    }
}