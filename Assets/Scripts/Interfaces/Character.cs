using UnityEngine;

namespace Scripts.Interfaces
{
    public class Character
    {
        public virtual void Attack()
        {
            Debug.Log("Inheritance :: Basic Attack!");
        }
    }
}
