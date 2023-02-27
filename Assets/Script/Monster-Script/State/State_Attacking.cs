using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Attacking : State
{
    public Attacking(GameObject _npc, NavMeshAgent _agent, Transform _player, Animator _anim) : base(_npc, _agent, _player, _anim)
    {
        name = STATE.Attacking;
        fieldOfView = _npc.GetComponent<FieldOfView>();
        monster = _npc.GetComponent<Monster>();
    }

    public override void Enter()
    {
        // anim.SetTrigger("isAttacking");     //Original method
        monster.Attack();
        base.Enter();
    }

    public override void Update()
    {
        if (fieldOfView.canAttackPlayer == false && monster.isAttack == false) // Change state to move
        {
            agent.isStopped = false;
            nextState = new Moving(npc, agent, player, anim);
            stage = EVENT.Exit;
        }

        if (monster.attackMode == false)
        {
            agent.isStopped = false;
            nextState = new Idle(npc, agent, player, anim);
            stage = EVENT.Exit;
        }

        if (monster.attackMode == false && fieldOfView.canFleePlayer == true)
        {
            agent.isStopped = false;
            nextState = new Flee(npc, agent, player, anim);
            stage = EVENT.Exit;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isAttacking");
        base.Exit();
    }
}
