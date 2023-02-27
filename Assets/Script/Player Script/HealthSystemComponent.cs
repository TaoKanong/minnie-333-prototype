using UnityEngine;
using Roguelike_ptt.StatusSystem;

namespace Roguelike_ptt.HealthSystemCM
{

    public class HealthSystemComponent : MonoBehaviour, IGetHealthSystem
    {

        [Tooltip("Maximum Health amount")]
        public float healthAmountMax = 100f;

        [Tooltip("Starting Health amount, leave at 0 to start at full health.")]
        [SerializeField] private float startingHealthAmount;

        private HealthSystem healthSystem;

        PlayerStatus playerStatusScript;

        void Start()
        {
            playerStatusScript = GetComponent<PlayerStatus>();
            Debug.Log("Health Boot: " + playerStatusScript.healthBoots);
        }


        private void Awake()
        {
            // Create Health System
            healthSystem = new HealthSystem(healthAmountMax);

            if (startingHealthAmount != 0)
            {
                healthSystem.SetHealth(startingHealthAmount);
            }
        }


        public HealthSystem GetHealthSystem()
        {
            return healthSystem;
        }

        public void PlayerTakeDamage(float damage)
        {

        }
    }
}