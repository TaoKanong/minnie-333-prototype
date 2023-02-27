using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class AI : MonoBehaviour
{
    // Animator anim;
    public Transform player;
    UnityEngine.AI.NavMeshAgent agent;
    private FieldOfView fieldOfView;
    State currentState;
    public LayerMask targetMask;
    public Animator anim;
    // Start is called before the first frame update
    void Start()
    {
        agent = this.GetComponent<UnityEngine.AI.NavMeshAgent>();
        fieldOfView = GetComponent<FieldOfView>();
        // anim = GetComponent<Animator>();
        // currentState = new Idle(this.gameObject, agent, anim, player);
        currentState = new Idle(this.gameObject, agent, player, anim);
    }

    // Update is called once per frame
    void Update()
    {
        currentState = currentState.Process();
    }
}
