using UnityEngine;
using UnityEngine.Playables;

public class PlayerIdleState : PlayerState
{
    public PlayerIdleState(Player _player, PlayerStateMachine _stateMachine, string _animBooName) : base(_player, _stateMachine, _animBooName)
    {
    }

    public override void Enter()
    {
        base.Enter();
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        base.Update();

        if(xInput !=0)
            stateMachine.ChangeState(player.moveState);
        if(Input.GetKeyDown(KeyCode.Space))
            stateMachine.ChangeState(player.moveState);

    }
}
