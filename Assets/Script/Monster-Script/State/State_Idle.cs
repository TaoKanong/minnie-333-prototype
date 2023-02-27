using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Idle : State
{
    public Idle(GameObject _npc, NavMeshAgent _agent, Transform _player, Animator _anim) : base(_npc, _agent, _player, _anim)
    {
        name = STATE.Idle;
        fieldOfView = _npc.GetComponent<FieldOfView>();
        monster = _npc.GetComponent<Monster>();
    }

    public override void Enter()
    {
        agent.isStopped = true;
        // anim.SetTrigger("isIdle");
        base.Enter();
    }

    public override void Update()
    {

        // Debug.Log(CanSeePlayer());
        if (fieldOfView.canSeePlayer == true && monster.attackMode == true)
        {
            nextState = new Moving(npc, agent, player, anim);
            stage = EVENT.Exit;
        }

        if (fieldOfView.canFleePlayer == true)
        {
            nextState = new Flee(npc, agent, player, anim);
            stage = EVENT.Exit;
        }
    }

    public override void Exit()
    {
        // anim.ResetTrigger("isIdle");
        base.Exit();
    }
}
