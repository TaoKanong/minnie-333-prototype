using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Monster : MonoBehaviour
{
    protected UnityEngine.AI.NavMeshAgent agent;
    protected State currentState;
    [HideInInspector]
    public FieldOfView fieldOfView;
    //protected CollCheck collCheck; // เปลี่ยน name space ใน collcheck
    public Transform player;
    public Animator anim;
    public bool isAttack; // Check current state   ตัวเช็คระหว่างตีห้ามเดิน
    public bool isStagger; // Check current state 
    public bool attackMode; // เช็คว่าตีได้รึป่าว ทำงานกับ cool down
    public float health;
    [HideInInspector]
    public float baseRate;
    public float attackRate;
    public float staggerTime;
    [HideInInspector]
    public float animStaggerReset = 0.3f;
    [HideInInspector]
    public float staggerBase;
    protected float maxHealth;
    public Material monsterMaterial;
    public Material damageFlash;
    public GameObject monsterObjectMat;

    public static Monster Instance { get; set; }

    protected virtual void Awake()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    protected virtual void Start()
    {
        // fieldOfView = GetComponent<FieldOfView>();
        // player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    // Update is called once per frame
    protected virtual void Update()
    {

    }

    public virtual void TakeDamage(float damage)
    {
        health -= damage;
        monsterObjectMat.GetComponent<Renderer>().material = damageFlash;
        StartCoroutine(Hit());

        if (health <= 0)
        {
            Dead();
        }
    }

    protected virtual IEnumerator Hit()
    {
        yield return new WaitForSeconds(0.15f);
        monsterObjectMat.GetComponent<Renderer>().material = monsterMaterial;
    }

    public virtual void Stagger()
    {
        isStagger = true;
        currentState = new Stagger(this.gameObject, agent, player, anim);
    }

    public virtual void StaggergDone()
    {
        isStagger = false;
    }

    protected virtual void Dead()
    {
        WaveManager.Instance.DecreaseMonsterCount(1);
        Destroy(gameObject);
    }

    protected virtual void OnTriggerEnter(Collider other)
    {
        // Debug.Log("isCollide");
    }

    public virtual void Attack()
    {
        anim.SetTrigger("isAttacking");
    }
}
