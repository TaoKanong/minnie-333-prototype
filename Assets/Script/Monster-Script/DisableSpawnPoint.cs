using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DisableSpawnPoint : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject spawnPoint;
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        // if (other.CompareTag("Obstacle"))
        // {
        //     spawnPoint.SetActive(false);
        // }

        if (other.CompareTag("Obstacle"))
        {
            WaveManager.Instance.RemoveSpawnPoint(spawnPoint);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Obstacle"))
        {
            WaveManager.Instance.RemoveSpawnPoint(spawnPoint);
        }
        // if (other.CompareTag("Obstacle"))
        // {
        //     spawnPoint.SetActive(false);
        // }
    }

    private void OnTriggerExit(Collider other)
    {
        WaveManager.Instance.AddSpawnPoint(spawnPoint);
        // spawnPoint.SetActive(true);
        // Debug.Log("Exit");
    }
}
