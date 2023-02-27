using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GameEventManager : MonoBehaviour
{
    public static GameEventManager Instance { get; set; }
    void Awake()
    {
        Instance = this;
    }

    public event Action OnShrineEventTrigger;
    public event Action OnShowWaveCompleteEventTrigger;
    public void StartWave()
    {
        if (OnShrineEventTrigger != null)
        {
            OnShrineEventTrigger();
        }
    }

    public void ShowUIWaveComplete()
    {
        if (OnShowWaveCompleteEventTrigger != null)
        {
            OnShowWaveCompleteEventTrigger();
        }
    }
}
