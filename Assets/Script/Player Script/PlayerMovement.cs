using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Roguelike_ptt.StatusSystem;

public class PlayerMovement : MonoBehaviour
{
    Animator animator;
    public CharacterController controller;

    public float speed = 6;
    public float turnSmoothTime = 0.1f;
    float turnSmoothVelocity;
    public Transform cam;

    public bool isAttacking = false;
    public bool isRunning = false;    

    //Movement Raycast
    public Vector3 moveDir;
    public Camera mainCamera;

    PlayerStatus playerStatusScript;

    void Start()
    {
        animator = GetComponent<Animator>();
        controller = GetComponent<CharacterController>();
        playerStatusScript = GetComponent<PlayerStatus>();
    }

    void Update()
    {
        Movement();
        RotateWithRaycast();
    }
    
    public void Movement()
    {
        if (!isAttacking)
        {
            float h = Input.GetAxisRaw("Horizontal");
            float v = Input.GetAxisRaw("Vertical");
            if(h != 0 || v != 0)
            {
                animator.SetBool("run", true);
                isRunning = true;
                Vector3 dir = new Vector3(h, 0, v).normalized;

                if (dir.magnitude >= 0.1f)
                {
                    float targetAngle = Mathf.Atan2(dir.x, dir.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
                    float angle = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAngle, ref turnSmoothVelocity, turnSmoothTime);
                    transform.rotation = Quaternion.Euler(0f, angle, 0f);

                    moveDir = Quaternion.Euler(0, targetAngle, 0) * Vector3.forward;
                    controller.Move(moveDir.normalized * (speed + playerStatusScript.movementSpeedBoots) * Time.deltaTime);
                }
            }
            else
            {
                animator.SetBool("run", false);
                isRunning = false;
            }
        }
    }

    public void RotateWithRaycast()
    {
        Ray cameraRay = mainCamera.ScreenPointToRay(Input.mousePosition);
        Plane groundPlane = new Plane(Vector3.up, Vector3.zero);
        float rayLength;

        if(groundPlane.Raycast(cameraRay, out rayLength))
        {
            Vector3 pointToLook = cameraRay.GetPoint(rayLength);
            Debug.DrawLine(cameraRay.origin, pointToLook, Color.blue);
            
            if (Input.GetMouseButtonDown(0) || (Input.GetMouseButtonDown(1) || (Input.GetKeyDown(KeyCode.E))))
            { 
                transform.LookAt(new Vector3(pointToLook.x, transform.position.y, pointToLook.z));
                isAttacking = true;
            }
        }
    }
}
