using UnityEngine;

namespace Scripts.Interfaces
{
    public class CompositionExample : MonoBehaviour
    {
        IAttackBehaviour attackBehaviour;

        private void Awake() {
            SetAttackBehavior(new BasicAttack());
            attackBehaviour.Attack();
            SetAttackBehavior(new SwordAttack());
            attackBehaviour.Attack();
            SetAttackBehavior(new MagicAttack());
            attackBehaviour.Attack();
        }
        public void SetAttackBehavior(IAttackBehaviour attackBehaviour)
        {
            this.attackBehaviour = attackBehaviour;
        }
    }

    public interface IAttackBehaviour
    {
        void Attack();
    }
}
