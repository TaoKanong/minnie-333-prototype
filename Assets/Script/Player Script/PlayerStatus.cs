using UnityEngine;

namespace Roguelike_ptt.StatusSystem {
    
    public class PlayerStatus : MonoBehaviour
    {
        public float healthBoots = 0f;
        public float movementSpeedBoots = 0f;
        public float attackSpeedBoots = 0f;
        public float attackDamageBoots = 0f;
        public float ReduceDamage = 0f;
        public float cooldownSpecialAttackBoots = 0f;
        public float cooldownUltimateAttackBoots = 0f;
    }
}