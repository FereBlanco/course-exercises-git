using UnityEngine;

namespace Scripts.Animations3DAndImportFromMixamo
{
    public class NoBlendTreeAnimatorController : MonoBehaviour
    {
        Animator animator;
        Rigidbody myRigibody; // Use the new keyword if hiding was intended
        float verticalInput;
        float horizontalInput;
        float walkingSpeed = 5f;
        float runningSpeed = 8f;
        float rotateSpeed = 3f;

        float finalSpeed = 0f;

        private void Awake() {
            animator = GetComponent<Animator>();
            myRigibody= GetComponent<Rigidbody>();
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
            animator.SetBool(Constants.IS_WALKING, IsWalking());
            animator.SetBool(Constants.IS_RUNNING, IsRunning());
        }

        private void UpdateRigidbody()
        {
            finalSpeed = IsWalking() && IsRunning() ? runningSpeed : IsWalking() ? walkingSpeed : 0;
            myRigibody.velocity = verticalInput * finalSpeed * transform.forward;
            myRigibody.angularVelocity = horizontalInput * rotateSpeed * Vector3.up;
        }
    }
}
