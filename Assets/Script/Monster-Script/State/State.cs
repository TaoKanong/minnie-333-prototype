using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class State
{
    // Start is called before the first frame update
    public enum STATE
    {
        Idle,
        Moving,
        Attacking,
        Flee,
        Stagger
    }

    public enum EVENT
    {
        Update,
        Enter,
        Exit
    }

    public STATE name;
    protected FieldOfView fieldOfView;
    protected Monster monster;
    protected EVENT stage;
    protected GameObject npc;
    protected Transform player;
    protected State nextState; //ใช้ Consructor ตัวเดียวกับ class
    protected NavMeshAgent agent;
    protected Animator anim;

    public State(GameObject _npc, NavMeshAgent _agent, Transform _player, Animator _anim) // Constructor
    {
        npc = _npc;
        agent = _agent;
        stage = EVENT.Enter;
        player = _player;
        anim = _anim;
    }

    public virtual void Enter() { stage = EVENT.Update; }
    public virtual void Update() { stage = EVENT.Update; }
    public virtual void Exit() { stage = EVENT.Exit; }

    public State Process()
    {
        if (stage == EVENT.Enter) Enter();
        if (stage == EVENT.Update) Update();
        if (stage == EVENT.Exit)
        {
            Exit();
            return nextState;
        }
        return this;
    }
}