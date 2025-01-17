using UnityEngine;

namespace Scripts.Animations3DAndImportFromMixamo
{
    public class OneDBlendTreeAnimatorController : MonoBehaviour
    {
        Animator animator;
        Rigidbody myRigibody; // Use the new keyword if hiding was intended
        float verticalInput;
        float horizontalInput;
        float walkingSpeed = 5.0f;
        float runningSpeed = 8.0f;
        float rotateSpeed = 200.0f;

        private void Awake() {
            animator = GetComponent<Animator>();
            myRigibody= GetComponent<Rigidbody>();

            GUIStyle style = new GUIStyle();
            style.fontSize = 12;            
        }

        private void Update() {
            verticalInput = Input.GetAxis(Constants.VERTICAL_INPUT);
            horizontalInput = Input.GetAxis(Constants.HORIZONTAL_INPUT);

            UpdateAnimation();
            UpdateRigidbody();
        }

        private bool IsWalking()
        {
            return verticalInput > 0.05f;
        }
        private bool IsRunning()
        {
            return IsWalking() && (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift));
        }

        private void UpdateAnimation()
        {
            if (verticalInput > 0 )
            {
                animator.SetFloat(Constants.ANIMATOR_PARAM_SPEED, verticalInput);
            }
        }

        private void UpdateRigidbody()
        {
            var finalTranslateSpeed = IsWalking() && IsRunning() ? runningSpeed : IsWalking() ? walkingSpeed : 0;

            myRigibody.velocity = (verticalInput > 0) ? verticalInput * finalTranslateSpeed * transform.forward : Vector3.zero;
            myRigibody.angularVelocity = (verticalInput > 0) ? horizontalInput * rotateSpeed * Vector3.up * Mathf.Deg2Rad : Vector3.zero;
        }

        private void OnGUI()
        {
            GUI.Label(new Rect(10, 0, 1000, 100), $"verticalInput: {verticalInput}");
            GUI.Label(new Rect(10, 15, 1000, 100), $"horizontalInput: {horizontalInput}");
        }
    }
}
