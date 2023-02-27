using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Moving : State
{
    public Moving(GameObject _npc, NavMeshAgent _agent, Transform _player, Animator _anim) : base(_npc, _agent, _player, _anim)
    {
        name = STATE.Moving;
        fieldOfView = _npc.GetComponent<FieldOfView>();
    }

    public override void Enter()
    {
        agent.isStopped = false;
        anim.SetTrigger("isMoving");
        base.Enter();
    }

    public override void Update()
    {
        agent.SetDestination(player.transform.position);
        // Debug.Log("Moving");

        if (fieldOfView.canAttackPlayer == true)
        {
            agent.isStopped = true;
            nextState = new Attacking(npc, agent, player, anim);
            stage = EVENT.Exit;
        }

        else if (fieldOfView.canSeePlayer == false)
        {
            nextState = new Idle(npc, agent, player, anim);
            stage = EVENT.Exit;
        }

        else if (fieldOfView.canFleePlayer == true)
        {
            nextState = new Flee(npc, agent, player, anim);
            stage = EVENT.Exit;
        }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isMoving");
        base.Exit();
    }
}
