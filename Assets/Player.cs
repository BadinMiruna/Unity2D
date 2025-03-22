using UnityEngine;

public class Player : MonoBehaviour
{
    #region Components

    public Animator anim {  get; private set; }
    public Rigidbody rb { get; private set; }

    #endregion

    #region States
    public PlayerStateMachine stateMachine { get; private set; }
    public PlayerIdleState idleState { get; private set; }
    public PlayerMoveState moveState { get; private set; }

    #endregion

    private void Awake()
    {
        stateMachine = new PlayerStateMachine();

        idleState = new PlayerIdleState(this, stateMachine, "Idle");
        moveState = new PlayerMoveState(this, stateMachine, "Move");
    }

    private void Start()
    {
        anim = GetComponentInChildren<Animator>();
        rb= GetComponent<Rigidbody>();

        stateMachine.Initialize(idleState);
    }

    private void Epdate()
    {
        stateMachine.currentState.Update();

    }

    public void SetVelocity(float _xVelocity,float _yVelocity)
    {
        rb.velocity=new Vector3(_xVelocity, _yVelocity);
    }
}
