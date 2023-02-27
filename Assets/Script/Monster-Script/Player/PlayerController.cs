using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float speed = 5f;
    private float horizontalInput;
    private float verticalInput;
    public bool playerIsAttack;
    public Animator anim;
    public enum State
    {
        State_Standing,
        State_Ducking,
        State_Jumping
    }

    public State currState = State.State_Standing;

    void Start()
    {

    }

    void Update()
    {
        switch (currState)
        {
            case State.State_Standing:
                Controller();
                if (Input.GetKey(KeyCode.C))
                {
                    currState = State.State_Ducking;
                    Debug.Log(currState);
                }
                break;
            case State.State_Ducking:
                Controller();
                if (Input.GetKeyUp(KeyCode.C))
                {
                    currState = State.State_Standing;
                    Debug.Log(currState);
                }

                break;
        }

        if (Input.GetKey(KeyCode.Mouse0))
        {
            anim.SetTrigger("isAttack");
        }
        else
        {
            anim.ResetTrigger("isAttack");
        }
    }

    void Controller()
    {
        horizontalInput = Input.GetAxis("Horizontal");
        verticalInput = Input.GetAxis("Vertical");

        float xAxis = horizontalInput * Time.deltaTime * speed;
        float zAxis = verticalInput * Time.deltaTime * speed;

        Vector3 movement = new Vector3(xAxis, 0, zAxis);
        if (currState == State.State_Standing)
        {
            transform.localScale = new Vector3(1, 1, 1);
            transform.Translate(movement);
        }
        if (currState == State.State_Ducking)
        {
            transform.localScale = new Vector3(2, 1, 1);
            transform.Translate(movement / 2.5f);
        }
    }

    public void EnableIsAttack()
    {
        playerIsAttack = true;
    }

    public void DisableIsAttack()
    {
        playerIsAttack = false;
    }
}

public class BST
{
    public int value;
    public BST left;
    public BST right;
    public BST(int value)
    {
        this.value = value;
    }
}


public class tree
{
    public int value;

    public tree(int value)
    {
        this.value = value;
    }
}


