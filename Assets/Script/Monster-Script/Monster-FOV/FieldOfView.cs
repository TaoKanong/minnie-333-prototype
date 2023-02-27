using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FieldOfView : MonoBehaviour
{
    public float radius;
    public float attackRadius;
    public float fleeRadius;
    [Range(0, 360)]
    public float angle;
    [Range(0, 360)]
    public float attackAngle;
    [Range(0, 360)]
    public float fleeAngle;
    public GameObject playerRef;

    public LayerMask targetMask;
    public LayerMask obstructionMask;

    public bool canSeePlayer;
    public bool canAttackPlayer;
    public bool canFleePlayer;

    private void Start()
    {
        playerRef = GameObject.FindGameObjectWithTag("Player");
        StartCoroutine(FOVRoutine());
    }

    private IEnumerator FOVRoutine()
    {
        WaitForSeconds wait = new WaitForSeconds(0.2f);

        while (true)
        {
            yield return wait;
            FieldOfViewCheck();
        }
    }

    private void FieldOfViewCheck()
    {
        Collider[] rangeChecks = Physics.OverlapSphere(transform.position, radius, targetMask);
        Collider[] attackRangeChecks = Physics.OverlapSphere(transform.position, attackRadius, targetMask);
        Collider[] fleeRangeChecks = Physics.OverlapSphere(transform.position, fleeRadius, targetMask);

        //CanseePlayer
        if (rangeChecks.Length != 0)
        {
            Transform target = rangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < angle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canSeePlayer = true;
                else
                    canSeePlayer = false;
            }
            else
                canSeePlayer = false;
        }
        else if (canSeePlayer)
            canSeePlayer = false;

        //CanAttackPlayer
        if (attackRangeChecks.Length != 0)
        {
            Transform target = attackRangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < attackAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canAttackPlayer = true;
                else
                    canAttackPlayer = false;
            }
            else
                canAttackPlayer = false;
        }
        else if (canAttackPlayer)
            canAttackPlayer = false;

        //CanFleePlayer
        if (fleeRangeChecks.Length != 0)
        {
            Transform target = fleeRangeChecks[0].transform;
            Vector3 directionToTarget = (target.position - transform.position).normalized;

            if (Vector3.Angle(transform.forward, directionToTarget) < fleeAngle / 2)
            {
                float distanceToTarget = Vector3.Distance(transform.position, target.position);

                if (!Physics.Raycast(transform.position, directionToTarget, distanceToTarget, obstructionMask))
                    canFleePlayer = true;
                else
                    canFleePlayer = false;
            }
            else
                canFleePlayer = false;
        }
        else if (canFleePlayer)
            canFleePlayer = false;

    }
}
