using UnityEngine;

namespace Scripts.Interfaces
{
    public class Mage : Character
    {
        public override void Attack()
        {
            Debug.Log("Inheritance :: Fireball Attack!");
            // base.Attack();
        }
    }    
}
