using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class PlayerState
{
    protected PlayerStateMachine stateMachine;
    protected Player player;


    protected float xInput;
    private string animBooName;

    public PlayerState(Player _player, PlayerStateMachine _stateMachine, string _animBooName)
    {
        this.player = _player;
        this.stateMachine = _stateMachine;
        this.animBooName = _animBooName;
    }

    public virtual void Enter()
    {
        player.anim.SetBool(animBooName, true);
    
    }

    public virtual void Update()
    {
        xInput = Input.GetAxisRaw("Horizontal");
    }

    public virtual void Exit()
    {
        player.anim.SetBool(animBooName, false);

    }

}
