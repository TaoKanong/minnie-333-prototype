using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Roguelike_ptt.StatusSystem;


public class PlayerAttack : MonoBehaviour
{
    Animator animator; 

    int cantidad_click; 
    bool puedo_dar_click; 

    private float defaultAttackSpeed = 1f;
    
    PlayerMovement moveScript;
    PlayerStatus playerStatusScript;

    private GameObject normalAttack1;
    private GameObject normalAttack2;
    private GameObject normalAttack3;
    private GameObject specialAttack;
    private GameObject ultimateAttack;

    private GameObject effectNorAttack1;
    private GameObject effectNorAttack2;
    private GameObject effectNorAttack3;
    private GameObject effectSpecialAttack;
    private GameObject effectUltimateAttack;

    //Skill CD
    public float unSetCooldownSpecialAttack;
    public float unSetCooldownUltimateAttack;
    private float nextTimeSpecialAttack = 0;
    private float nextTimeUltimateAttack = 0;

    void Start()
    {
        animator = GetComponent<Animator>();
        cantidad_click = 0;
        puedo_dar_click = true;

        moveScript = GetComponent<PlayerMovement>();
        playerStatusScript = GetComponent<PlayerStatus>();

        FindObjectSkill();
        ResetAttack();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0)) 
        { 
            Iniciar_combo(); 
        }

        SpecialAttack();
        UltimateAttack();
        
        animator.SetFloat("attack_speed", (defaultAttackSpeed + playerStatusScript.attackSpeedBoots));
    }

    void Iniciar_combo()
    {
        if (puedo_dar_click)
        {
            cantidad_click++;
        }

        if (cantidad_click == 1)
        {
            animator.SetInteger("attack", 1);
        }
    }

    public void Verificar_combo()
    {

        puedo_dar_click = false;

        if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack_1") && cantidad_click == 1)
        {
            animator.SetInteger("attack", 0);
            puedo_dar_click = true;
            cantidad_click = 0;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack_1") && cantidad_click >= 2)
        {       
            animator.SetInteger("attack", 2);
            puedo_dar_click = true;
            
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack_2") && cantidad_click == 2)
        {       
            animator.SetInteger("attack", 0);
            puedo_dar_click = true;
            cantidad_click = 0;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack_2") && cantidad_click >= 3)
        {       
            animator.SetInteger("attack", 3);
            puedo_dar_click = true;
        }
        else if (animator.GetCurrentAnimatorStateInfo(0).IsName("attack_3"))
        {      
            animator.SetInteger("attack", 0);
            puedo_dar_click = true;
            cantidad_click = 0;
        }
    }

    // Active Attack Range
      public void ActiveNormalAttack1()
    {
            normalAttack1.SetActive(true);
           //Debug.Log("Attack1");
    }
      public void ActiveNormalAttack2()
    {
            normalAttack2.SetActive(true);
            //Debug.Log("Attack2");
    }
      public void ActiveNormalAttack3()
    {
            normalAttack3.SetActive(true);
            //Debug.Log("Attack3");
    }
    public void ActiveSpecialAttack()
    {
            specialAttack.SetActive(true);
            //Debug.Log("Special Attack");
    }
    public void ActiveUltimateAttack()
    {
            ultimateAttack.SetActive(true);
            //Debug.Log("Ultimate Attack");
    }

    // Active Effect Sword
    public void ActiveEffectNormalAttack1()
    {
        effectNorAttack1.SetActive(true);
    }

    public void ActiveEffectNormalAttack2()
    {
        effectNorAttack2.SetActive(true);
    }

    public void ActiveEffectNormalAttack3()
    {
        effectNorAttack3.SetActive(true);
    }

        public void ActiveEffectSpecialAttack()
    {
        effectSpecialAttack.SetActive(true);
    }

        public void ActiveEffectUltimateAttack()
    {
        effectUltimateAttack.SetActive(true);
    }
    
    //Reset การโจมตี และเอฟเฟค
    public void ResetAttack()
    {
        normalAttack1.SetActive(false);
        effectNorAttack1.SetActive(false);
        normalAttack2.SetActive(false);
        effectNorAttack2.SetActive(false);
        normalAttack3.SetActive(false);
        effectNorAttack3.SetActive(false);
        specialAttack.SetActive(false);
        effectSpecialAttack.SetActive(false);
        ultimateAttack.SetActive(false);
        effectUltimateAttack.SetActive(false);
        moveScript.isAttacking = false;
        //Debug.Log("Attack false");
    }
    
    private void FindObjectSkill()
    {
        normalAttack1 = GameObject.Find("Nor1");
        normalAttack2 = GameObject.Find("Nor2");
        normalAttack3 = GameObject.Find("Nor3");
        specialAttack = GameObject.Find("Spac1");
        ultimateAttack = GameObject.Find("Ultimate");

        effectNorAttack1 = GameObject.Find("EffectAttack1");
        effectNorAttack2 = GameObject.Find("EffectAttack2");
        effectNorAttack3 = GameObject.Find("EffectAttack3");
        effectSpecialAttack = GameObject.Find("SpacialAttack");
        effectUltimateAttack = GameObject.Find("UltimateAttack");
    }

    public void SpecialAttack()
    {
        if(Time.time > (nextTimeSpecialAttack + playerStatusScript.cooldownSpecialAttackBoots))
        {
            if (Input.GetMouseButtonDown(1))
            {
                animator.SetBool("special_attack", true);
            }
            else if (Input.GetMouseButtonUp(1))
            {
                animator.SetBool("special_attack", false);
                nextTimeSpecialAttack = Time.time + unSetCooldownSpecialAttack;
            }
        }
    }

    public void UltimateAttack()
    {
        if(Time.time > (nextTimeUltimateAttack + playerStatusScript.cooldownSpecialAttackBoots))
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                animator.SetBool("ultimate_attack", true);
            }
            else if (Input.GetKeyUp(KeyCode.E))
            {
                animator.SetBool("ultimate_attack", false);
                nextTimeUltimateAttack = Time.time + unSetCooldownUltimateAttack;
            }
        }
    }
}