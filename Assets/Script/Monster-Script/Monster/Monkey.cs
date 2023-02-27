using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monkey : Monster
{
    public float attackTurnSpeed;

    protected override void Start()
    {
        Instance = this;
        baseRate = attackRate;
        staggerBase = staggerTime;
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        currentState = new Idle(this.gameObject, agent, player, anim);
        fieldOfView = GetComponent<FieldOfView>();
    }

    protected override void Update()
    {
        Cooldown();
        AttackTurn();
        currentState = currentState.Process();
    }

    public override void Attack()
    {
        base.Attack();
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

    public void AttackTurn()
    {
        if (attackMode == true && fieldOfView.canAttackPlayer == true)
        {
            Vector3 relativePos = player.position - transform.position;

            // // the second argument, upwards, defaults to Vector3.up
            Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
            // transform.rotation = rotation;
            transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * attackTurnSpeed);
            // transform.rotation = Quaternion.LookRotation(agent.velocity * 1);

            // if (agent.velocity.sqrMagnitude > Mathf.Epsilon)
            // {
            //     transform.rotation = Quaternion.LookRotation(agent.velocity.normalized);
            // }
            // transform.rotation = Quaternion.RotateTowards(transform.rotation, Quaternion.Euler(player.position), 10 * 100 * Time.deltaTime);
        }
    }

    public override void TakeDamage(float damage)
    {
        Debug.Log("Gee");
        base.TakeDamage(damage);
        Stagger();
    }
    public override void Stagger()
    {
        base.Stagger();
    }

    public override void StaggergDone() // For Animation Event 
    {
        base.StaggergDone();
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
