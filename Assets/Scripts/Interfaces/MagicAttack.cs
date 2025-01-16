using UnityEngine;

namespace Scripts.Interfaces
{
    public class MagicAttack : IAttackBehaviour
    {
        public void Attack()
        {
            Debug.Log("Interface :: Fireball Attack!");
        }
    }
}