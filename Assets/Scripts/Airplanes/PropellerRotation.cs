using UnityEngine;

namespace Scripts.Airplanes
{

    public class PropellerRotation : MonoBehaviour
    {
        [SerializeField] private float rotationSpeed = 1500f;
        [SerializeField] private bool inverseOrientation = false;

        private void Awake() {
            if (inverseOrientation) rotationSpeed *= -1f;
        }

        void Update()
        {
            transform.Rotate(rotationSpeed * Time.deltaTime * Vector3.forward);         
        }
    }
}
