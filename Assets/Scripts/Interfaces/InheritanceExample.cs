using UnityEngine;
using UnityEngine.Timeline;

namespace Scripts.Interfaces
{
    public class InheritanceExample : MonoBehaviour
    {
        Character character;

        private void Awake() {
            character = new Character();
            character.Attack();
            character = new Warrior();
            character.Attack();
            character = new Mage();
            character.Attack();
        }
    }
}
