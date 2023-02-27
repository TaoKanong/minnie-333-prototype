using UnityEngine;
using UnityEngine.UI;
using Roguelike_ptt.StatusSystem;

namespace Roguelike_ptt.HealthSystemCM {

    /// <summary>
    /// Heal the HealthSystem on Click
    /// </summary>
    public class Demo_HealButton : MonoBehaviour {

        [SerializeField] private GameObject getHealthSystemGameObject;

        private void Start() {
            HealthSystem.TryGetHealthSystem(getHealthSystemGameObject, out HealthSystem healthSystem, true);

            GetComponent<Button>().onClick.AddListener(() => {
                healthSystem.Heal(10);
            });
        }

    }

}