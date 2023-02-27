using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotate : MonoBehaviour
{
    public Transform player;
    public float speed;
    // Update is called once per frame
    void Update()
    {
        Vector3 relativePos = player.position - transform.position;

        // // the second argument, upwards, defaults to Vector3.up
        Quaternion rotation = Quaternion.LookRotation(relativePos, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * speed);
        // transform.rotation = rotation;
    }
}
