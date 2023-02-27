using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gorilla : Monster
{
    public override void Attack()
    {
        base.Attack();
    }
    protected override void Start()
    {
        Instance = this;
        baseRate = attackRate;
        staggerBase = staggerTime;
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        currentState = new Idle(this.gameObject, agent, player, anim);
    }
    protected override void Update()
    {
        Cooldown();
        currentState = currentState.Process();
    }

    public void Cooldown()
    {
        if (attackRate >= 0)
        {
            attackRate -= Time.deltaTime * 1;
        }

        if (attackRate <= 0 && attackMode == false)
        {
            attackMode = true;

        }
    }

    public override void TakeDamage(float damage)
    {
        base.TakeDamage(damage);
    }

    public void EnableIsAttacking()
    {
        // Debug.Log("Enable");
        isAttack = true;
    }
    public void DisableIsAttacking()
    {
        // Debug.Log("Disable");
        attackMode = false;
        isAttack = false;
        attackRate = baseRate;
    }
}
