using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class Stagger : State
{
    public Stagger(GameObject _npc, NavMeshAgent _agent, Transform _player, Animator _anim) : base(_npc, _agent, _player, _anim)
    {
        name = STATE.Stagger;
        fieldOfView = _npc.GetComponent<FieldOfView>();
        monster = _npc.GetComponent<Monster>();
    }

    public override void Enter()
    {
        Debug.Log("Stagger");
        anim.SetTrigger("isStaggering");
        base.Enter();
    }

    public override void Update()
    {
        monster.attackMode = false;
        monster.isAttack = false;
        monster.attackRate = monster.baseRate;
        agent.isStopped = true;

        monster.staggerTime -= Time.deltaTime * 1;
        monster.animStaggerReset -= Time.deltaTime * 1;
        if (monster.staggerTime <= 0)
        {
            // ResetAllTriggers();
            monster.staggerTime = monster.staggerBase;
            // Monster.Instance.staggerTime = Monster.Instance.staggerBase;
            nextState = new Moving(npc, agent, player, anim);
            stage = EVENT.Exit;
        }

        if (monster.animStaggerReset <= 0)   // เวลาที่จะเล่น animation stagger  ถ้า stagger cooldown เสร็จให้เริ่มใหม่  
        {
            monster.animStaggerReset = 0.3f;
            ResetAllTriggers();
        }
        // if (monster.isStagger == false)
        // {
        //     ResetAllTriggers();
        //     nextState = new Moving(npc, agent, player, anim);
        //     stage = EVENT.Exit;
        // }
    }

    public override void Exit()
    {
        anim.ResetTrigger("isStaggering");
        base.Exit();
    }

    private void ResetAllTriggers()
    {
        foreach (var param in anim.parameters)
        {
            anim.ResetTrigger(param.name);
            // if (param.type == AnimatorControllerParameterType.Trigger)
            // {
            //     anim.ResetTrigger(param.name);
            // }
        }
    }
}
