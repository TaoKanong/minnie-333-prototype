using System.Collections;
using System.Collections.Generic;
using Roguelike_ptt.StatusSystem;
using UnityEngine;

namespace Roguelike_ptt.HealthSystemCM
{
    public class CollCheck : MonoBehaviour
    {
        public float Damage;
        public bool isHit;
        [SerializeField] private GameObject getHealthSystemGameObject;
        void Start()
        {
            // HealthSystem.TryGetHealthSystem<HealthSystem>(out HealthSystem healthSystem, true);
        }

        void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isHit = true;
                Debug.Log("-" + Damage);
            }

            // if (HealthSystem.TryGetHealthSystem<HealthSystem>(out HealthSystem healthSystem, true) && this.gameObject.tag == "Enemy")
            // {
            //     isHit = true;
            //     Debug.Log("-" + Damage);
            //     healthSystem.Damage(Damage);
            // }

            if (other.gameObject.TryGetComponent<Monster>(out Monster monsterComponent) && this.gameObject.tag == "PlayerHitbox")
            {
                Debug.Log("Hit");
                monsterComponent.TakeDamage(Damage);
            }
        }

        void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Player"))
            {
                isHit = false;
                // Debug.Log("Exit");
            }
        }
    }
}
