using UnityEngine;

namespace Scripts.Pong
{
    public class KeyboardInputAdapter : MonoBehaviour, IInput
    {
        [SerializeField] KeyCode keyCodeUp = KeyCode.UpArrow;
        [SerializeField] KeyCode keyCodeDown = KeyCode.DownArrow;

        public bool IsButtonUpPressed()
        {
            return (Input.GetKey(keyCodeUp));
        }

        public bool IsButtonDownPressed()
        {
            return (Input.GetKey(keyCodeDown));
        }
    }

}