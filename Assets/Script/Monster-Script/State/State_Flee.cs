using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Flee : State
{
    // int multiplier = 1;
    public Flee(GameObject _npc, NavMeshAgent _agent, Transform _player, Animator _anim) : base(_npc, _agent, _player, _anim)
    {
        name = STATE.Flee;
        fieldOfView = _npc.GetComponent<FieldOfView>();
        monster = _npc.GetComponent<Monster>();
    }

    public override void Enter()
    {
        // anim.SetTrigger("isAttacking");
        Debug.Log("Flee");
        base.Enter();
    }

    public override void Update()
    {
        Vector3 runTo = npc.transform.position + ((npc.transform.position - player.position));
        float distance = Vector3.Distance(npc.transform.position, player.position);
        // float dist = agent.remainingDistance;

        agent.isStopped = false;


        if (fieldOfView.canFleePlayer == true)  // เช็ค player เข้าระยะ ให้ agent วิ้งไปหา destination
        {
            agent.SetDestination(runTo);
        }

        if (!agent.pathPending)  // ถ้าถึง destination ให้กลับไป state moving
        {
            if (agent.remainingDistance <= agent.stoppingDistance)
            {
                if (!agent.hasPath || agent.velocity.sqrMagnitude == 0f)
                {
                    nextState = new Moving(npc, agent, player, anim);
                    stage = EVENT.Exit;
                }
            }
        }

        // if (fieldOfView.canFleePlayer == false)
        // {
        //     nextState = new Moving(npc, agent, player, anim);
        //     stage = EVENT.Exit;
        // }
    }

    public override void Exit()
    {
        // anim.ResetTrigger("isAttacking");
        base.Exit();
    }

    IEnumerator FleeDistant()
    {
        yield return new WaitForSeconds(3f);
        nextState = new Moving(npc, agent, player, anim);
        stage = EVENT.Exit;
    }
}
