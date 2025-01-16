using UnityEngine;

namespace Scripts.Interfaces
{
    public class BasicAttack : IAttackBehaviour
    {
        public void Attack()
        {
            Debug.Log("Interface :: Basic Attack!");
        }
    }
}
