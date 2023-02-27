using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MonsterProjectile : MonoBehaviour
{
    public float speed;
    float time = 3f;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        time -= Time.deltaTime;
        transform.Translate(Vector3.forward * Time.deltaTime * speed);

        if (time <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")  // รอ player health ต้องเปลี่ยนเป็นเช็ค script player แล้วดึง funtion ลดเลือด
        {
            Destroy(gameObject);
        }
    }
}
