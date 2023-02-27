﻿using UnityEngine;
using UnityEngine.UI;
using Roguelike_ptt.StatusSystem;

namespace Roguelike_ptt.HealthSystemCM
{

    /// <summary>
    /// Deal Damage to the HealthSystem on Click
    /// </summary>
    public class Demo_DamageButton : MonoBehaviour
    {
        [SerializeField] private GameObject getHealthSystemGameObject;
        private void Start()
        {
            HealthSystem.TryGetHealthSystem(getHealthSystemGameObject, out HealthSystem healthSystem, true);

            GetComponent<Button>().onClick.AddListener(() =>
            {
                healthSystem.Damage(10);
            });
        }

    }

}