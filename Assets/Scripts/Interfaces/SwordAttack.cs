using UnityEngine;

namespace Scripts.Interfaces
{
    public class SwordAttack : IAttackBehaviour
    {
        public void Attack()
        {
            Debug.Log("Interface :: Sword Attack!");
        }
    }
}
