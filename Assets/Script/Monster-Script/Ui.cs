using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Ui : MonoBehaviour
{

    TextMeshProUGUI waveCount;

    public GameObject waveComplete;
    public Animator anim;
    float displayTimeWaveComplete = 2f;
    // bool isShow = false;
    void Start()
    {
        waveCount = GetComponent<TextMeshProUGUI>();
        GameEventManager.Instance.OnShowWaveCompleteEventTrigger += showWaveCompleteUI;
    }

    void Update()
    {
        waveCount.text = "Wave: " + WaveManager.Instance.currWave.ToString();
        if (WaveManager.Instance.isWaveComplete == true)
        {
            anim.SetTrigger("isDisplay");
            Debug.Log("anim trigger");
        }
        else if (WaveManager.Instance.isWaveComplete == false)
        {
            ResetTrigger();
        }
    }

    public void ResetTrigger()
    {
        anim.ResetTrigger("isDisplay");
        // StartCoroutine(countDownDisplay());
    }

    public void showWaveCompleteUI()
    {
        if (WaveManager.Instance.isWaveComplete == true)
        {
            StartCoroutine(countDownDisplay());
        }
    }

    IEnumerator countDownDisplay()
    {
        // waveComplete.SetActive(true);
        Debug.Log("Reset");
        yield return new WaitForSeconds(2f);
    }
}
