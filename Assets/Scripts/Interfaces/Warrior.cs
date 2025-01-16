using UnityEngine;

namespace Scripts.Interfaces
{
    public class Warrior : Character
    {
        public override void Attack()
        {
            Debug.Log("Inheritance :: Sword Attack!");
        }
    }
}
