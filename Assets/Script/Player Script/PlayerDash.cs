using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDash : MonoBehaviour
{

    PlayerMovement moveScript;
    public float dashSpeed =20f;
    public float dashTime = .25f;
    private float dashCD;

    // Start is called before the first frame update
    void Start()
    {
        moveScript = GetComponent<PlayerMovement>();
        dashCD = 0;
    }

    // Update is called once per frame
    void Update()
    {
        dashCD -= Time.deltaTime;
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (dashCD <= 0)
            {
                StartCoroutine(Dash());
            }
        }
    }
    IEnumerator Dash()
    {
        float startTime = Time.time;

        while (Time.time < startTime + dashTime)
        {
            moveScript.controller.Move(moveScript.moveDir * dashSpeed * Time.deltaTime);
            dashCD = 1;
            Debug.Log("dashed");
            yield return null;
        }
    }
}