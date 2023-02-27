using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShrineController : MonoBehaviour
{
    [SerializeField]
    GameObject showInteractable;
    // Start is called before the first frame update
    void Start()
    {
        GameEventManager.Instance.OnShrineEventTrigger += WaveManager.Instance.GenerateWave;
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (WaveManager.Instance.isWaveComplete == true)
            {
                showInteractable.SetActive(true);
                if (Input.GetKey(KeyCode.Space))
                {
                    WaveManager.Instance.currWave++;
                    // GameEventManager.Instance.ShowUIWaveComplete();
                    WaveManager.Instance.GenerateWave();
                }
            }

        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            if (WaveManager.Instance.isWaveComplete == true)
            {
                showInteractable.SetActive(true);
                if (Input.GetKey(KeyCode.Space))
                {
                    WaveManager.Instance.currWave++;
                    // GameEventManager.Instance.ShowUIWaveComplete();
                    WaveManager.Instance.GenerateWave();
                }
            }
            else
            {
                showInteractable.SetActive(false);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (WaveManager.Instance.isWaveComplete == true)
        {
            showInteractable.SetActive(false);
        }

    }
}
